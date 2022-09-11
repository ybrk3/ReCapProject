using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{

    //Password db'de yok o yüzden Dto oluşturuldu Hem register hem de login için
    //GetClaim içerisine UserName ismi koyulması da gerekebilir. O yüzden de oluşturulur
    public class UserForLoginDto :IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
