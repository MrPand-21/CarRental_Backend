using Core.DataAccess;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Security.JWT;

namespace DataAccess.Abstract
{
    public interface IUserDal: IEntityRepository<User>
    {
        List<UserClaimDto> GetClaims(User user);
    }
}
