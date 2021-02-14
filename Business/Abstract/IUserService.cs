using Core.Utilities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<User> GetUserById(int id);
        IDataResult<List<User>> GetAll();
        IResult Add(User car);
        IResult Update(User car);
        IResult Delete(User car);
    }
}
