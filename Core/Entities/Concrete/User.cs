using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete

{

    //User nesnesi Core'a atandı. Çünkü Entities class library'si Core'u kullanırken Core içerisinde TokenHelper sınıfında
    // kullanıcı için token oluşturulurken User nesnesine ihtiyaç var ve bu tersi şekilde using'le eklenemez
    public class User : IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordSalt { get; set; } //kullanıcının şifresinin daha karmaşık hale getirilmesi
                                                 //Rainbow table'da karşılığı bulunamasın diye 
        public byte[] PasswordHash { get; set; } //şifresinin hashlenmiş hali
        public bool Status { get; set; }  //kullanıcı aktif mi pasif mi
    }
}
