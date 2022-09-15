using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Core.IOC;
using Core.Utilities.Interceptors;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofact.Caching
{
    public class CacheAspect : MethodInterception
    {
        private int _duration;
        private ICacheManager _cacheManager;

        //Süre verilmezse 60dk cache'de duracak
        public CacheAspect(int duration = 60)
        {
            _duration = duration;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
            //redis kullanılsa bile GetService'e dokunulmaz Sadece CoreModule değiştirilir
        }

        public override void Intercept(IInvocation invocation)
        {
            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");
            //ReflectedType = NameSpace FullName = InterFace + Method ismi  ==> KEY için
            var arguments = invocation.Arguments.ToList();
            //Method'un parametrelerine bakılır ==> KEY için
            var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})";
            //Yukarıdaki iki değer bilerştirilerek key oluşturulur.
            //virgül ile ayrı parametreler tanımlanır eğer parametre yoksa null değeri verilir
            if (_cacheManager.IsAdd(key)) //Cache'de var mı?
            {
                invocation.ReturnValue = _cacheManager.Get(key);
                //Invocation.ReturnValue hiçbir value almadan çık
                return;
            }
            invocation.Proceed(); //Eğer Cache yoksa methodu çalıştır
            _cacheManager.Add(key, invocation.ReturnValue, _duration); //Çalıştırılan method'u Cache'e tası
        }
    }
}
