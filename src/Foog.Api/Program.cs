using Foog.Api;
using Foog.Core.FreeSql;
using Foog.Core.Permission;
using FreeSql;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.OpenApi.Models;
using Foog.Api.Filters;
using Foog.Core.Filter;
using Foog.Api.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Foog.Core.Utilities.Encryption;
using Serilog.Events;
using Serilog;
using Microsoft.AspNetCore.Authorization;
using Foog.Api.Auth;



var builder = WebApplication.CreateBuilder(args);
Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .ReadFrom.Configuration(builder.Configuration)
                .CreateLogger();
builder.Host.UseSerilog();
builder.Services.AddHttpContextAccessor();

#region 批量注册
builder.Services.AddCustomServices();

#endregion

// Add services to the container.

builder.Services.AddControllers(o =>
{

    o.Filters.Add<ApiResponseFilterAttribute>();
    o.Filters.Add<GlobalExceptionFilter>();
}).ConfigureApiBehaviorOptions(option =>
{
    //关闭默认模型验证
    option.SuppressModelStateInvalidFilter = true;
});

#region 跨域

// 添加跨域配置选项
// 获取选项


var corsSettings = builder.Configuration.GetSection(typeof(CorsOptions).GetDescription())
                                                     .Get<CorsOptions>();

// 添加跨域服务
builder.Services.AddCors(options =>
{
    // 添加策略跨域
    options.AddPolicy(name: corsSettings.PolicyName, builder =>
    {
        // 判断是否设置了来源，因为 AllowAnyOrigin 不能和 AllowCredentials一起公用
        var isNotSetOrigins = corsSettings.WithOrigins == null || corsSettings.WithOrigins.Length == 0;

        // 如果没有配置来源，则允许所有来源
        if (isNotSetOrigins) builder.AllowAnyOrigin();
        else builder.WithOrigins(corsSettings.WithOrigins)
                            .SetIsOriginAllowedToAllowWildcardSubdomains();

        // 如果没有配置请求标头，则允许所有表头
        if (corsSettings.WithHeaders == null || corsSettings.WithHeaders.Length == 0) builder.AllowAnyHeader();
        else builder.WithHeaders(corsSettings.WithHeaders);

        // 如果没有配置任何请求谓词，则允许所有请求谓词
        if (corsSettings.WithMethods == null || corsSettings.WithMethods.Length == 0) builder.AllowAnyMethod();
        else builder.WithMethods(corsSettings.WithMethods);

        // 配置跨域凭据
        if (corsSettings.AllowCredentials == true && !isNotSetOrigins) builder.AllowCredentials();

        // 配置响应头
        if (corsSettings.WithExposedHeaders != null && corsSettings.WithExposedHeaders.Length > 0) builder.WithExposedHeaders(corsSettings.WithExposedHeaders);

        // 设置预检过期时间
        if (corsSettings.SetPreflightMaxAge.HasValue) builder.SetPreflightMaxAge(TimeSpan.FromSeconds(corsSettings.SetPreflightMaxAge.Value));
    });
});

// 添加响应压缩
builder.Services.AddResponseCaching();
#endregion
#region Swagger

var documentOptions = builder.Configuration.GetSection(typeof(DocumentOptions).GetDescription())
                                                     .Get<DocumentOptions>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{

    var documentOptionsList = documentOptions.Info;
    if (documentOptionsList != null && documentOptionsList.Length > 0)
    {
        foreach (var documentOptions in documentOptionsList)
        {
            var openApiInfo = new OpenApiInfo
            {
                Version = documentOptions.Version,
                Title = documentOptions.Title,
                Description = documentOptions.Description,
            };
            if (!documentOptions.TermsUrl.IsNullOrEmpty())
            {
                openApiInfo.TermsOfService = new Uri(documentOptions.TermsUrl);
            }
            if (!documentOptions.ContactName.IsNullOrEmpty())
            {
                openApiInfo.Contact = new OpenApiContact
                {
                    Name = documentOptions.ContactName,
                    Url = new Uri(documentOptions.ContactUrl)
                };
            }
            if (!documentOptions.LicenseName.IsNullOrEmpty())
            {
                openApiInfo.License = new OpenApiLicense
                {
                    Name = documentOptions.LicenseName,
                    Url = new Uri(documentOptions.LicenseUrl)
                };
            }
            options.SwaggerDoc(documentOptions.Name, openApiInfo);
        }
    }


    // 添加身份验证
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey
    });

    // 添加授权要求
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                new string[] {}
            }
        });
});
#endregion
#region 认证
var jwtSection = builder.Configuration.GetSection(typeof(JWTOptions).GetDescription());
builder.Services.Configure<JWTOptions>(jwtSection);
var JWTOptions = jwtSection.Get<JWTOptions>();
builder.Services.TryAddSingleton<JWTEncryption>(); 
//注册服务
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = JWTOptions.ValidateIssuer, //是否验证Issuer
        ValidIssuer = JWTOptions.ValidIssuer, //发行人Issuer
        ValidateAudience = true, //是否验证Audience
        ValidAudience = JWTOptions.ValidAudience, //订阅人Audience
        ValidateIssuerSigningKey = JWTOptions.ValidateIssuerSigningKey, //是否验证SecurityKey
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JWTOptions.IssuerSigningKey)), //SecurityKey
        ValidateLifetime = JWTOptions.ValidateLifetime, //是否验证失效时间
        ClockSkew = TimeSpan.FromSeconds(JWTOptions.ClockSkew), //过期时间容错值，解决服务器端时间不同步问题（秒）
    };
});

//自定义授权
builder.Services.AddSingleton<IAuthorizationHandler, FoogAuthorizationHandler>();
#endregion

#region FreeSql
Func<IServiceProvider, IFreeSql> fsqlFactory = r =>
{
    IFreeSql fsql = new FreeSql.FreeSqlBuilder()
        .UseConnectionString(FreeSql.DataType.MySql, @"Data Source=127.0.0.1;Port=3306;User ID=root;Password=123456; Initial Catalog=foog;Charset=utf8mb4; SslMode=none;Min pool size=1")
        .UseMonitorCommand(cmd => Console.WriteLine($"Sql：{cmd.CommandText}"))//监听SQL语句
        .UseAutoSyncStructure(true) //自动同步实体结构到数据库，FreeSql不会扫描程序集，只有CRUD时才会生成表。
        .Build();
    return fsql;
};
builder.Services.AddSingleton<IFreeSql>(fsqlFactory);
builder.Services.TryAddScoped<IUserInfo, UserInfo>();
builder.Services.TryAddScoped(typeof(IRepository<>), typeof(Repository<>));
// 注册仓储
builder.Services.TryAddScoped(typeof(IKeyRepository<,>), typeof(KeyRepository<,>));
builder.Services.TryAddScoped<UnitOfWorkManager>();

#endregion

var app = builder.Build();

#region SwaggerUI
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.DocumentTitle = documentOptions.Title;
        var documentOptionsList = documentOptions.Info;
        if (documentOptionsList != null && documentOptionsList.Length > 0)
        {
            foreach (var documentOptions in documentOptionsList)
            {
                options.SwaggerEndpoint($"/swagger/{documentOptions.Name}/swagger.json", documentOptions.Name);
            }
        }
        options.RoutePrefix = documentOptions.RoutePrefix;
    });
}
#endregion

#region 跨域
app.UseCors(corsSettings.PolicyName);
// 添加压缩缓存
app.UseResponseCaching();
#endregion

#region FreeSql数据同步
//在项目启动时，从容器中获取IFreeSql实例，并执行一些操作：同步表，种子数据,FluentAPI等
//using(IServiceScope serviceScope = app.Services.CreateScope())
//{
//    var fsql = serviceScope.ServiceProvider.GetRequiredService<IFreeSql>();
//    fsql.CodeFirst.SyncStructure(typeof(Topic));//Topic 为要同步的实体类
//}
#endregion

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
