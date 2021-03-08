using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Abstract;
using Core.Utilities.Concrete;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.UsersListed);
        }

        public IDataResult<List<UserClaimDto>> GetClaims(User user)
        {
            return new SuccessDataResult<List<UserClaimDto>>(_userDal.GetClaims(user), Messages.ClaimsListed);
        }

        public IDataResult<User> GetUserById(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Id == id), Messages.UserFound);
        }

        public IDataResult<User> GetUserByMail(string email)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Email == email), Messages.UserFound);
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }
    }
}
