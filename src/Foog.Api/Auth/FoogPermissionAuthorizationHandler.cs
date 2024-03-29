﻿using Foog.Core.Permission;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Globalization;
using System.Security.Claims;

namespace Foog.Api.Auth
{
    /// <summary>
    /// 自定义鉴权
    /// 文档地址：https://learn.microsoft.com/zh-cn/aspnet/core/security/authorization/iard?view=aspnetcore-8.0
    /// </summary>
    public class FoogPermissionAuthorizationHandler : AuthorizationHandler<PermissionAttribute>
    {
        private readonly ILogger<FoogPermissionAuthorizationHandler> _logger;

        public FoogPermissionAuthorizationHandler(ILogger<FoogPermissionAuthorizationHandler> logger)
        {
            _logger = logger;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionAttribute requirement)
        {
             // Log as a warning so that it's very clear in sample output which authorization
        // policies(and requirements/handlers) are in use.
        _logger.LogWarning("Evaluating authorization requirement for age >= {age}",
                                                                    requirement.Code);

        // Check the user's age.
        var dateOfBirthClaim = context.User.FindFirst(c => c.Type == 
                                                                 ClaimTypes.DateOfBirth);
        if (dateOfBirthClaim != null)
        {
            // If the user has a date of birth claim, check their age.
            var dateOfBirth = Convert.ToDateTime(dateOfBirthClaim.Value,
                                                           CultureInfo.InvariantCulture);
            var age = DateTime.Now.Year - dateOfBirth.Year;
            if (dateOfBirth > DateTime.Now.AddYears(-age))
            {
                // Adjust age if the user hasn't had a birthday yet this year.
                age--;
            }

            // If the user meets the age criterion, mark the authorization requirement
            // succeeded.
            if (age >= requirement.Age)
            {
                _logger.LogInformation(
                    "Minimum age authorization requirement {age} satisfied", 
                      requirement.Age);
                context.Succeed(requirement);
            }
            else
            {
                _logger.LogInformation("Current user's DateOfBirth claim ({dateOfBirth})"
                   + " does not satisfy the minimum age authorization requirement {age}",
                    dateOfBirthClaim.Value,
                    requirement.Age);
            }
        }
        else
        {
            _logger.LogInformation("No DateOfBirth claim present");
        }

        return Task.CompletedTask;
        }
    }
}
