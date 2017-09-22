using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace AuthorizationLab.Policy {
    public class HasBadgeHandler : AuthorizationHandler<OfficeEntryRequirement> {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OfficeEntryRequirement requirement) {
            if (context.User.HasClaim(c => c.Type == "BadgeNumber" && c.Issuer == "https://localhost")) {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
