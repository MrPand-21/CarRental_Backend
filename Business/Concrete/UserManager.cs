using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
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

        [ValidationAspect(typeof(UserValidator))]
        [CacheRemoveAspect("IUserService.Get")]
        [TransactionScopeAspect]
        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }
        [CacheRemoveAspect("IUserService.Get")]
        [TransactionScopeAspect]
        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }
        [CacheAspect()]
        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.UsersListed);
        }
        [CacheAspect(duration: 5)]
        [PerformanceAspect(interval: 7)]
        public IDataResult<List<UserClaimDto>> GetClaims(User user)
        {
            return new SuccessDataResult<List<UserClaimDto>>(_userDal.GetClaims(user), Messages.ClaimsListed);
        }
        [CacheAspect()]
        [PerformanceAspect(interval: 1)]
        public IDataResult<User> GetUserById(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Id == id), Messages.UserFound);
        }

        [CacheAspect(duration:5)]
        [PerformanceAspect(interval: 2)]
        public IDataResult<User> GetUserByMail(string email)
        {
            var result = _userDal.Get(u => u.Email == email);
            if (result == null)
            {
                return null;
            }
            return new SuccessDataResult<User>(result, Messages.UserFound);
        }

        [ValidationAspect(typeof(UserValidator))]
        [TransactionScopeAspect]
        [PerformanceAspect(interval: 12)]
        [CacheRemoveAspect("IUserService.Get")]
        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }
    }
}
