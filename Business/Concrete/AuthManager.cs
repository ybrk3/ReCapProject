using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        IUserService _userService;
        ITokenHelper _tokenhelper;

        public AuthManager(IUserService userService, ITokenHelper tokenhelper)
        {
            _userService = userService;
            _tokenhelper = tokenhelper;
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            //Kullanıcının varlığı kontrol edilir
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }
            //kullanıcının email ve password bilgileri hashing ile kontrol edilir.
            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordSalt,
                userToCheck.PasswordHash))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }
            return new SuccessDataResult<User>(userToCheck, Messages.SuccessfulLogin);
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordSalt,passwordHash;
            HashingHelper.CreatePasswordHash(password, out passwordSalt, out passwordHash);
            var user = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordSalt = passwordSalt,
                PasswordHash = passwordHash,
                Status = true
            };
            _userService.Add(user);
            return new SuccessDataResult<User>(user, Messages.UserRegistered);
        }

        public IResult UserExists(string email)
        {
            if (_userService.GetByMail(email) != null)
            {
                return new SuccessResult(Messages.UserAlreadyExists);
            }
            return new ErrorResult();
        }
        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenhelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }
    }
}
