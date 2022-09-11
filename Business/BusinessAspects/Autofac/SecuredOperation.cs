using Core.IOC;
using Core.Utilities.Interceptors;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessAspects.Autofac
{
    public class SecuredOperation : MethodInterception
    {
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor;
        //JWT ile yapılan herbir kişiden gelen herbir istek için HttpContext/thread oluşur

        public SecuredOperation(string roles) //roller [SecuredOperation("Product.Add, admin)]
        {
            //metni belirtilen karaktere göre ayırıp array'e atar. Yukarıdaki Product.Add, admin mesela
            _roles = roles.Split(',');
            //ServiceTool kullanılarak ASP.net ve API göremez dependency'leri yakalayabilmek için yazıldı
            //Injection altyapısını okumaya yarar
            //Autofac'de injection değerlerini alır IProductService vb.
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();

        }
    }
}
