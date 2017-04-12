using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Protocols.WSTrust;
using System.Text;
using System.ServiceModel.Security.Tokens;

namespace DigisensePlatformAPIs.JWTTokenGenration
{
    public class JWTTokenGenration
    {

        #region Genrate Token
        public static string GetJWToken(string userName)
        {
            // Create Jwt Security Token Handler Object
            var tokenHandler = new JwtSecurityTokenHandler();
            // Symmetric key must be atleast 128 bits long
            string symmetricKey = "MahindraDigisense Mobile API";
            // Declare Time Out variable, value is in minutes.
            double tokenTimeOut = 30;
            // Get Current Date Time for expiry Date
            var currentDT = DateTime.Now;
            // Creating Token Description part
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                            {
                            new Claim(ClaimTypes.Name, userName),
                            new Claim(ClaimTypes.Role, "DigiSense Roles"),
                            }),
                TokenIssuerName = "DigiSense Tech Mahindra",
                AppliesToAddress = "http://www.techmahindra.com",
                // define lifetime of the token
                Lifetime = new Lifetime(currentDT, currentDT.AddMinutes(tokenTimeOut)),
                // Create Signing Credentials 
                // Param 1 : signing key
                // Param 2 : signature algorithm
                // Param 3 : digest algorithm
                SigningCredentials = new SigningCredentials(
                    new InMemorySymmetricSecurityKey(Encoding.ASCII.GetBytes(symmetricKey)),
                    "http://www.w3.org/2001/04/xmldsig-more#hmac-sha256",
                    "http://www.w3.org/2001/04/xmlenc#sha256")
            };
            // Create Token
            var token = tokenHandler.CreateToken(tokenDescriptor);
            // convert Token to string
            var tokenString = tokenHandler.WriteToken(token);
            return tokenString;
        }
        #endregion

        #region Verify JWT_Token
        public static bool VerifyJWT(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            // Create symmetric key with the random number and prefix in web.config
            var symmetricKey = "MahindraDigisense Mobile API";


            // validation parameters, JWtValidator requires this object to validate the token.
            var validationParameters = new TokenValidationParameters()
            {
                ValidAudience = "http://www.techmahindra.com", // Same as AppliesToAddress 
                IssuerSigningToken = new BinarySecretSecurityToken(Encoding.ASCII.GetBytes(symmetricKey)),
                ValidIssuer = "DigiSense Tech Mahindra", // same as Token Issuer Name
                RequireExpirationTime = true,
                ValidateLifetime = true,
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidateIssuerSigningKey = true,
            };

            SecurityToken validatedToken;
            try
            {
                // if token is valid, it will output the validated token that contains the JWT information
                // otherwise it will throw an exception
                var principal = tokenHandler.ValidateToken(token, validationParameters, out validatedToken);

            }
            catch (Exception ex)
            {
                //TODO: Logger we need to create
                return false;
            }

            return true;
        }
        #endregion
    }
}