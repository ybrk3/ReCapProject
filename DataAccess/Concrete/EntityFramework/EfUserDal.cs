using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, RentalCarContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new RentalCarContext())
            {
                //OperationClaim ile UserOperationClaim'deki aynı id'deki claimlerin
                //UserId'leri eşit lanları çekilip listeye atılır
                var result = from OperationClaim in context.OperationClaims
                             join UserOperationClaim in context.UserOperationClaims
                             on OperationClaim.Id equals UserOperationClaim.Id
                             where UserOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = OperationClaim.Id, Name=OperationClaim.Name };
                return result.ToList(); //w/o list() Iqueryable
            }
        }
    }
}
