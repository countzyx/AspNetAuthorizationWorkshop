using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace AuthorizationLab.Policy {
    public class MinimumAgeRequirementHandler : AuthorizationHandler<MinimumAgeRequirementHandler>, IAuthorizationRequirement {
        private readonly int _minimumAge;

        public MinimumAgeRequirementHandler(int minimumAge) {
            _minimumAge = minimumAge;
        }


        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinimumAgeRequirementHandler requirementHandler) {
            if (context.User.HasClaim(c => c.Type == ClaimTypes.DateOfBirth)) {
                var dateOfBirth =
                    Convert.ToDateTime(context.User.FindFirst(c => c.Type == ClaimTypes.DateOfBirth).Value);
                int calculatedAge = DateTime.Today.Year - dateOfBirth.Year;
                if (dateOfBirth > DateTime.Today.AddYears(-calculatedAge)) {
                    calculatedAge--;
                }

                if (calculatedAge >= _minimumAge) {
                    context.Succeed(requirementHandler);
                }
            }

            return Task.CompletedTask;
        }
    }
}
