using Core.Entities.Concrete;
using Core.Utilities.Abstract;
using Core.Utilities.Security.JWT;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<User> GetUserByMail(string email);
        IDataResult<User> GetUserById(int Id);
        IDataResult<List<User>> GetAll();
        IResult Add(User car);
        IResult Update(User car);
        IResult Delete(User car);
        IDataResult<List<UserClaimDto>> GetClaims(User user);
    }
}
