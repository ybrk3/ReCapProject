using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofact.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;

        //validatorType üzerinden "typeof(Validator ismi)" ctor'da girilir.
        //Attribute'de Type'la geçilir.
        public ValidationAspect(Type validatorType)
        {
            //verilen validatorType'ın IValidator olup olmadığı kontrolü yapılır
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("Bu bir doğrulama sınıfı değil");
            }

            //Validator type yakalanır
            _validatorType = validatorType;
        }
        //IInvocation Castle.Dynamic.Proxy'den gelir.
        protected override void OnBefore(IInvocation invocation)
        {
            //Reflection Run-Time'da methodları çalıştırır.
            var validator = (IValidator)Activator.CreateInstance(_validatorType);

            //Validator'ın çalışma tiplerinden (Basetype) ilki yakalanır
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            //Ilgili method'un parametrelerine bakılıp Validator'ın tipine eşit olan parametreler bulunur
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);

            //ValidationTool kullanılarak Validate edilir.
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
