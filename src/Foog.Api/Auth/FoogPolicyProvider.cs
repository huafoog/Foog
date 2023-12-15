using Foog.Core.Permission;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace Foog.Api.Auth
{
    public class FoogPolicyProvider : IAuthorizationPolicyProvider
    {
        const string POLICY_PREFIX = "Foog";
        public DefaultAuthorizationPolicyProvider FallbackPolicyProvider { get; }
        public FoogPolicyProvider(IOptions<AuthorizationOptions> options)
        {
            FallbackPolicyProvider = new DefaultAuthorizationPolicyProvider(options);
        }
        public Task<AuthorizationPolicy> GetDefaultPolicyAsync() =>
                                FallbackPolicyProvider.GetDefaultPolicyAsync();
        public Task<AuthorizationPolicy?> GetFallbackPolicyAsync() =>
                                FallbackPolicyProvider.GetFallbackPolicyAsync();

        public Task<AuthorizationPolicy?> GetPolicyAsync(string policyName)
        {
            if (policyName.StartsWith(POLICY_PREFIX, StringComparison.OrdinalIgnoreCase) &&
                int.TryParse(policyName.Substring(POLICY_PREFIX.Length), out var age))
            {
                var policy = new AuthorizationPolicyBuilder(
                                                    JwtBearerDefaults.AuthenticationScheme);
                //policy.AddRequirements(new PermissionAttribute(age));
                return Task.FromResult<AuthorizationPolicy?>(policy.Build());
            }

            return Task.FromResult<AuthorizationPolicy?>(null);
        }
    }
}
