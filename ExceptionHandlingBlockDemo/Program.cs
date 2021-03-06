﻿using System;
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
                Console.WriteLine("Caught an application level exception");
                Console.WriteLine(exception.ToString());
                Console.ReadKey();
            }    
        }

        private static void DoStuff()
        {
            var container = new UnityContainer()
                .AddNewExtension<EnterpriseLibraryCoreExtension>();

            var exceptionManager = container.Resolve<ExceptionManager>();
            //exceptionManager.Process(MyExceptionalCode, "Policy");
            try
            {
                MyExceptionalCode();
            }
            catch (Exception exception)
            {
                Exception newException;
                var handleException = exceptionManager.HandleException(exception, "Policy", out newException);
                if (handleException)
                    throw newException;
                Console.WriteLine("did not throw exception");
            }
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
