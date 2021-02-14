using Business.Abstract;
using Core.Utilities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        public IResult Add(User car)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(User car)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<User> GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public IResult Update(User car)
        {
            throw new NotImplementedException();
        }
    }
}
