using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Core.Utilities.Security.jwt;

namespace Core.Utilities.Security.Jwt
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
        string getUserNameByToken(string token);

    }
}
