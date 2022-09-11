using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.JWT
{

    //JWT değişebilir o yüzden interface oluşturulur
    public interface ITokenHelper
    {
        //User'a ve claimlerine göre token üretecek
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}
