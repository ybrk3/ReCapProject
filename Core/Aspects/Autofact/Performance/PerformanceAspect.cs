using Castle.DynamicProxy;
using Core.IOC;
using Core.Utilities.Interceptors;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofact.Performance
{
    public class PerformanceAspect : MethodInterception
    {
        //Eğer MethodInterception'a attribute olarak eklenirse sistemdeki her şeyi kontrol eder

        private int _interval;
        private Stopwatch _stopwatch; //Calculator of elapsed time aka timer


        public PerformanceAspect(int interval) //Performans değerlendirmesinde kriter olarak verilecek zaman
        {
            _interval = interval;
            _stopwatch = ServiceTool.ServiceProvider.GetService<Stopwatch>();
            //Stopwatch instance'ı için CoreModule'a eklenir.
            //GetService bu instance'ı kontrol edip _stopwatch'a aktarır
        }


        protected override void OnBefore(IInvocation invocation)
        {
            _stopwatch.Start(); //Methodla birlikte timer başlar
        }

        protected override void OnAfter(IInvocation invocation)
        {
            if (_stopwatch.Elapsed.TotalSeconds > _interval)
            {
                Debug.WriteLine($"Performance : {invocation.Method.DeclaringType.FullName}.{invocation.Method.Name}-->{_stopwatch.Elapsed.TotalSeconds}");
                //Eğer geçen zaman interval olarak verilen zamandan büyükse; method'un full name'i ile birlikte uyarı verilir
            }
            _stopwatch.Reset();
        }
    }
}
