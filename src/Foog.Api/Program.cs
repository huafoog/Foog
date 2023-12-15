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

#region ����ע��
builder.Services.AddCustomServices();

#endregion

// Add services to the container.

builder.Services.AddControllers(o =>
{

    o.Filters.Add<ApiResponseFilterAttribute>();
    o.Filters.Add<GlobalExceptionFilter>();
}).ConfigureApiBehaviorOptions(option =>
{
    //�ر�Ĭ��ģ����֤
    option.SuppressModelStateInvalidFilter = true;
});

#region ����

// ��ӿ�������ѡ��
// ��ȡѡ��


var corsSettings = builder.Configuration.GetSection(typeof(CorsOptions).GetDescription())
                                                     .Get<CorsOptions>();

// ��ӿ������
builder.Services.AddCors(options =>
{
    // ��Ӳ��Կ���
    options.AddPolicy(name: corsSettings.PolicyName, builder =>
    {
        // �ж��Ƿ���������Դ����Ϊ AllowAnyOrigin ���ܺ� AllowCredentialsһ����
        var isNotSetOrigins = corsSettings.WithOrigins == null || corsSettings.WithOrigins.Length == 0;

        // ���û��������Դ��������������Դ
        if (isNotSetOrigins) builder.AllowAnyOrigin();
        else builder.WithOrigins(corsSettings.WithOrigins)
                            .SetIsOriginAllowedToAllowWildcardSubdomains();

        // ���û�����������ͷ�����������б�ͷ
        if (corsSettings.WithHeaders == null || corsSettings.WithHeaders.Length == 0) builder.AllowAnyHeader();
        else builder.WithHeaders(corsSettings.WithHeaders);

        // ���û�������κ�����ν�ʣ���������������ν��
        if (corsSettings.WithMethods == null || corsSettings.WithMethods.Length == 0) builder.AllowAnyMethod();
        else builder.WithMethods(corsSettings.WithMethods);

        // ���ÿ���ƾ��
        if (corsSettings.AllowCredentials == true && !isNotSetOrigins) builder.AllowCredentials();

        // ������Ӧͷ
        if (corsSettings.WithExposedHeaders != null && corsSettings.WithExposedHeaders.Length > 0) builder.WithExposedHeaders(corsSettings.WithExposedHeaders);

        // ����Ԥ�����ʱ��
        if (corsSettings.SetPreflightMaxAge.HasValue) builder.SetPreflightMaxAge(TimeSpan.FromSeconds(corsSettings.SetPreflightMaxAge.Value));
    });
});

// �����Ӧѹ��
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


    // ��������֤
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey
    });

    // �����ȨҪ��
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
#region ��֤
var jwtSection = builder.Configuration.GetSection(typeof(JWTOptions).GetDescription());
builder.Services.Configure<JWTOptions>(jwtSection);
var JWTOptions = jwtSection.Get<JWTOptions>();
builder.Services.TryAddSingleton<JWTEncryption>(); 
//ע�����
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = JWTOptions.ValidateIssuer, //�Ƿ���֤Issuer
        ValidIssuer = JWTOptions.ValidIssuer, //������Issuer
        ValidateAudience = true, //�Ƿ���֤Audience
        ValidAudience = JWTOptions.ValidAudience, //������Audience
        ValidateIssuerSigningKey = JWTOptions.ValidateIssuerSigningKey, //�Ƿ���֤SecurityKey
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JWTOptions.IssuerSigningKey)), //SecurityKey
        ValidateLifetime = JWTOptions.ValidateLifetime, //�Ƿ���֤ʧЧʱ��
        ClockSkew = TimeSpan.FromSeconds(JWTOptions.ClockSkew), //����ʱ���ݴ�ֵ�������������ʱ�䲻ͬ�����⣨�룩
    };
});

//�Զ�����Ȩ
builder.Services.AddSingleton<IAuthorizationHandler, FoogAuthorizationHandler>();
#endregion

#region FreeSql
Func<IServiceProvider, IFreeSql> fsqlFactory = r =>
{
    IFreeSql fsql = new FreeSql.FreeSqlBuilder()
        .UseConnectionString(FreeSql.DataType.MySql, @"Data Source=127.0.0.1;Port=3306;User ID=root;Password=123456; Initial Catalog=foog;Charset=utf8mb4; SslMode=none;Min pool size=1")
        .UseMonitorCommand(cmd => Console.WriteLine($"Sql��{cmd.CommandText}"))//����SQL���
        .UseAutoSyncStructure(true) //�Զ�ͬ��ʵ��ṹ�����ݿ⣬FreeSql����ɨ����򼯣�ֻ��CRUDʱ�Ż����ɱ�
        .Build();
    return fsql;
};
builder.Services.AddSingleton<IFreeSql>(fsqlFactory);
builder.Services.TryAddScoped<IUserInfo, UserInfo>();
builder.Services.TryAddScoped(typeof(IRepository<>), typeof(Repository<>));
// ע��ִ�
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

#region ����
app.UseCors(corsSettings.PolicyName);
// ���ѹ������
app.UseResponseCaching();
#endregion

#region FreeSql����ͬ��
//����Ŀ����ʱ���������л�ȡIFreeSqlʵ������ִ��һЩ������ͬ������������,FluentAPI��
//using(IServiceScope serviceScope = app.Services.CreateScope())
//{
//    var fsql = serviceScope.ServiceProvider.GetRequiredService<IFreeSql>();
//    fsql.CodeFirst.SyncStructure(typeof(Topic));//Topic ΪҪͬ����ʵ����
//}
#endregion

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
