using System.Collections.Generic;
using Tulkas.Core.Entities.Concrete;

namespace Tulkas.Core.Helpers.Utilities.Security.Jwt
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}
