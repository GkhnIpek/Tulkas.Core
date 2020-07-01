using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Tulkas.Core.Helpers.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static List<string> ClaimRoles(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal?.Claims(ClaimTypes.Role);
        }
        private static List<string> Claims(this ClaimsPrincipal claimsPrincipal, string claimType)
        {
            var result = claimsPrincipal?.FindAll(claimType)?.Select(x => x.Value).ToList();
            return result;
        }
    }
}
