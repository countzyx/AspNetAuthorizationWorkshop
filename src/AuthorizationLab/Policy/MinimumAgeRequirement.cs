using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace AuthorizationLab.Policy {
    public class MinimumAgeRequirement : AuthorizationHandler<MinimumAgeRequirement>, IAuthorizationRequirement {
        private readonly int _minimumAge;

        public MinimumAgeRequirement(int minimumAge) {
            _minimumAge = minimumAge;
        }


        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinimumAgeRequirement requirement) {
            if (context.User.HasClaim(c => c.Type == ClaimTypes.DateOfBirth)) {
                var dateOfBirth =
                    Convert.ToDateTime(context.User.FindFirst(c => c.Type == ClaimTypes.DateOfBirth).Value);
                int calculatedAge = DateTime.Today.Year - dateOfBirth.Year;
                if (dateOfBirth > DateTime.Today.AddYears(-calculatedAge)) {
                    calculatedAge--;
                }

                if (calculatedAge >= _minimumAge) {
                    context.Succeed(requirement);
                }
            }

            return Task.CompletedTask;
        }
    }
}
