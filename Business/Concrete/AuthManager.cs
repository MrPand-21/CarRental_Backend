using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Abstract;
using Core.Utilities.Concrete;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        IUserService _userService;
        ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var result = _tokenHelper.CreateToken(user, claims.Data);
            return new SuccessDataResult<AccessToken>(result, Messages.TokenCreated);
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetUserByMail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(userToCheck.Message);
            }
            Password password = new Password { PasswordHash = userToCheck.Data.PasswordHash, PasswordSalt = userToCheck.Data.PasswordSalt };
            var result = HashingHelper.VerifyPassword(userForLoginDto.Password, password);
            if (!result)
            {
                return new ErrorDataResult<User>(Messages.PasswordIncorrect);
            }
            return new SuccessDataResult<User>(userToCheck.Data, userToCheck.Message);
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto)
        {
            var password = HashingHelper.CreateHash(userForRegisterDto.Password);
            var user = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                Status = true,
                PasswordHash = password.PasswordHash,
                PasswordSalt = password.PasswordSalt
            };
            _userService.Add(user);
            return new SuccessDataResult<User>(user, Messages.UserCreated);

        }

        public IResult UserExists(string email)
        {
            var check = _userService.GetUserByMail(email);
            if (check != null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccessResult();
        }
    }
}
