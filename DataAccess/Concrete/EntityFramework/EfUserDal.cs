using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Core.Utilities.Security.JWT;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, CarRentalContext>, IUserDal
    {
        public List<UserClaimDto> GetClaims(User user)
        {
            using (var context = new CarRentalContext())
            {
                var result = from OperationClaim in context.OperationClaims
                             join UserOperationClaim in context.UserOperationClaims
                                on OperationClaim.Id equals UserOperationClaim.OpertationClaimId
                             where UserOperationClaim.UserId == user.Id
                             select new UserClaimDto { Id = OperationClaim.Id, Name = OperationClaim.Name };
                return result.ToList();
            }
        }
    }
}
