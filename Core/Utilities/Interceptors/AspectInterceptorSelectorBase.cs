using Castle.DynamicProxy;
using System.Reflection;

namespace Core.Utilities.Interceptors
{

    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            //class'ın attribute'larını okur
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>
                (true).ToList();
            //method'un attribute'larını okur
            var methodAttributes = type.GetMethod(method.Name)
                .GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            //Ve onları Listeye koyar
            classAttributes.AddRange(methodAttributes);

            // classAttributes.Add(new ExceptionLogAspect(typeof(FileLogger))); (Sistemde herşeyi loglar)

            //Attribute'ları önem sırasına göre sıralar. MethodInterceptionBaseAttribute içerisindeki Priority üzerinden
            return classAttributes.OrderBy(x => x.Priority).ToArray();
        }
    }
}