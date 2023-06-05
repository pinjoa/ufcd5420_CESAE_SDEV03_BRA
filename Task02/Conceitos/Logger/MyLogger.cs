// /*
// * 	<copyright file="MyLogger.cs" company="bitminho.com">
// * 	Copyright (c) 2023 All Rights Reserved
// * 	</copyright>
// * 	<author>João Pinto</author>
// * 	<date>20230604H21:19</date>
// * 	<description>Logger/MyLogger.cs</description>
// **/

using System;
using System.IO;

namespace Logger
{
    public class MyLogger
    {
        private static readonly object lockObject = new object();
        private static MyLogger instance;
        private static readonly string logFilePath = "log.txt";

        private MyLogger()
        {
            // Private constructor to prevent instantiation from outside the class
        }

        public static MyLogger GetInstance()
        {
            // thread-safe
            // lock: ensure exclusive access to a shared resource
            // https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/lock
            lock (lockObject)
            {
                if (instance == null)
                {
                    instance = new MyLogger();
                }
                return instance;
            }
        }

        public void LogMessage(string message)
        {
            lock (lockObject)
            {
                using (StreamWriter writer = File.AppendText(logFilePath))
                {
                    writer.WriteLine($"{DateTime.Now}: {message}");
                }
            }
        }
    }
}