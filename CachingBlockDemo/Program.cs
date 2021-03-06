﻿using System;
using System.IO;
using Microsoft.Practices.EnterpriseLibrary.Caching;
using Microsoft.Practices.EnterpriseLibrary.Caching.Expirations;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration.Unity;
using Microsoft.Practices.Unity;

namespace CachingBlockDemo
{
    class Program
    {
        static void Main()
        {
            var container = new UnityContainer()
                .AddNewExtension<EnterpriseLibraryCoreExtension>();

            var cacheManager = container.Resolve<ICacheManager>();

            cacheManager.Add("demo", "demo data");

            //var absoluteTime = new AbsoluteTime(TimeSpan.FromHours(5));
            //var neverExpired = new NeverExpired();
            //var slidingTime = new SlidingTime(TimeSpan.FromSeconds(1000));
            //cacheManager.Add("demo2", "another data", CacheItemPriority.NotRemovable, null, neverExpired);

            //cacheManager.Remove("demo");
            //cacheManager.Flush();

            File.WriteAllText("C:\\temp\\tempfile.txt", "bla bla bla");
            
            //var fileDependency = new FileDependency("C:\\temp\\tempfile.txt");
            //cacheManager.Add("demo2", "aother demo object", CacheItemPriority.NotRemovable, null, fileDependency);

            // * * * * *
            // minute houre day month dayofweek
            // 10 12 * * 0
            var extendedPolicy = new ExtendedFormatTime("* * * *");
            cacheManager.Add("demo2", "aother demo object", CacheItemPriority.NotRemovable, null, extendedPolicy);


            var data = cacheManager.GetData("demo");
            if (data != null) Console.WriteLine(data);

            var data2 = cacheManager.GetData("demo2");
            if (data2 != null) Console.WriteLine(data2);

            File.Delete("C:\\temp\\tempfile.txt");

            data2 = cacheManager.GetData("demo2");
            if (data2 != null) Console.WriteLine(data2);

            //Thread.Sleep(20*1000);

            //data2 = cacheManager.GetData("demo2");
            //if (data2 != null) Console.WriteLine(data2);
            //else Console.WriteLine("data was gone");

            Console.ReadKey();
        }
    }
}
