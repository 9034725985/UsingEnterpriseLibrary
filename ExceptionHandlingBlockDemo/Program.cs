using System;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration.Unity;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.Unity;

namespace ExceptionHandlingBlockDemo
{
    class Program
    {
        static void Main()
        {
            try
            {
                DoStuff();
            }
            catch (Exception exception)
            {
                Console.WriteLine("Caught an applicationlevel exception");
                Console.WriteLine(exception.ToString());
                Console.ReadKey();
            }    
        }

        private static void DoStuff()
        {
            var container = new UnityContainer()
                .AddNewExtension<EnterpriseLibraryCoreExtension>();

            var exceptionManager = container.Resolve<ExceptionManager>();
            exceptionManager.Process(MyExceptionalCode, "Policy");
        }

        private static void MyExceptionalCode()
        {
            Console.WriteLine("Throwing an Exception");
            throw new Exception("My basic exception");
/*
            Console.WriteLine("exception past");
*/
        }
    }
}
