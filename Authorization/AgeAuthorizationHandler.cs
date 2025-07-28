using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace ProductManagementAPI.Authorization;

public class AgeAuthorizationHandler : AuthorizationHandler<AgeGreaterThan25Reuirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AgeGreaterThan25Reuirement requirement)
    {
        var dob = DateTime.Parse(context.User.FindFirstValue("DateOfBirth"));
        
        if(DateTime.Today.Year - dob.Year > 25)
            context.Succeed(requirement);

        return Task.CompletedTask;  
    }
}
