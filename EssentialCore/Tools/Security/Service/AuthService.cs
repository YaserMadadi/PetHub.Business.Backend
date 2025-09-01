using EssentialCore.Tools.Logging;
using EssentialCore.Tools.Result;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Security.JWT;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
//using System.DirectoryServices;
using System.Threading.Tasks;
//using DirectoryEntry = System.DirectoryServices.DirectoryEntry;

namespace EssentialCore.Tools.Security.Service
{
    public class AuthService : IAuthService
    {
        private ITokenHelper tokenHelper;

        private IUserService userService;

        private IConfiguration configuration;

        public AuthService(ITokenHelper tokenHelper, IUserService userService, IConfiguration configuration)
        {
            this.tokenHelper = tokenHelper;

            this.userService = userService;

            this.configuration = configuration;
        }


        public async Task<IDataResult<AccessToken>> Login(LoginUser loginUser)
        {
            var result = await CheckInActiveDirectory(loginUser);

            if (!result.IsSucceeded)

                return new ErrorDataResult<AccessToken>(-1, result.Message);

            var userCheck = await this.CheckInDataBase(loginUser.UserName);

            if (userCheck == null || !userCheck.IsSucceeded)
            {
                return new ErrorDataResult<AccessToken>(-1, userCheck == null ? "Error on Finding User!" : userCheck.Message);
            }

            //if (!HashingHelper.VerifyPasswordHash(loginDto.Password, userCheck.PasswordHash, userCheck.PasswordSalt))
            //{
            //    return new ErrorDataResult<User>(Messages.PasswordError, Messages.PasswordErrorId);
            //}

            var accessToken = this.tokenHelper.CreateToken(userCheck.Data);

            if (accessToken == null || accessToken == default)

                return new ErrorDataResult<AccessToken>(accessToken);

            return new SuccessfulDataResult<AccessToken>(accessToken);
        }

        private async Task<Result.Result> CheckInActiveDirectory(LoginUser loginUser)
        {
#if !DEBUG 

            return new SuccessfulResult();
#endif

            try
            {
                //string domainName = this.configuration.GetValue<string>("DC:DomainName");

                //string dcPath = this.configuration.GetValue<string>("DC:Path");

                //using (DirectoryEntry entry = new DirectoryEntry($"LDAP://{domainName}/{dcPath}", $"{loginUser.UserName}@{domainName}", loginUser.Password))
                //{
                //    using (DirectorySearcher searcher = new DirectorySearcher(entry))
                //    {
                //        searcher.Filter = String.Format("(SAMAccountName={0})", loginUser.UserName);

                //        searcher.PropertiesToLoad.Add("DisplayName");

                //        searcher.PropertiesToLoad.Add("SAMAccountName");

                //        var result = searcher.FindOne();

                //        if (result == null)

                //            throw new Exception($"User Not Exists in the {domainName} Domain!");

                //        var displayName = result.Properties["DisplayName"];

                //        var samAccountName = result.Properties["SAMAccountName"];

                //        if (displayName?.Count > 0)

                //            return new SuccessfulResult();
                    //}
                //}
            }
            catch (Exception ex)
            {
                await LogManager.Save<Exception>(ex, "Check User In ActiveDirectory", Serializer.JsonSerializerManager.Serialize(loginUser));

                return new ErrorResult(-1, "Error in CheckInDomain Exception : " + ex.Message);
            }

            return new ErrorResult(-1, "Error : Not Return any Value");
        }



        public async Task<IDataResult<UserCredit>> CheckInDataBase(string userName)
        {
            var dataResult = await this.userService.RetrieveByUserName(userName);

            if (!dataResult.IsSucceeded)
            {
                return new ErrorDataResult<UserCredit>(-1, "User not Found in DataBase!");
            }

            return dataResult;
        }

        public IDataResult<AccessToken> CreateAccsessToken(UserCredit userCredit)
        {
            //var cliam = authService.GetClaims(user);

            var acssessToken = this.tokenHelper.CreateToken(userCredit);

            return new SuccessfulDataResult<AccessToken>(acssessToken);
        }



        //public IDataResult<User> Register(UserForRigsterDto rigsterDto, string password)
        //{
        //    byte[] passwordHash, passwordSalt;
        //    HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);

        //    var user = new User
        //    {
        //        Email = rigsterDto.Email,
        //        FirstName = rigsterDto.FirstName,
        //        LastName = rigsterDto.LostName,
        //        PasswordHash = passwordHash,
        //        PasswordSalt = passwordSalt,
        //        Status = true,
        //    };
        //    _userService.Add(user);

        //    return new SuccsessDataResult<User>(user, Messages.UserRegistered, Messages.UserRegisteredId);
        //}



    }
}
