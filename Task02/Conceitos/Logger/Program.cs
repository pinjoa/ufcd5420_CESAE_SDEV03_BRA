using System;

namespace Logger
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            MyLogger logger = MyLogger.GetInstance();

            // Logging messages from different components
            logger.LogMessage("Message from Component A");
            logger.LogMessage("Message from Component B");
            logger.LogMessage("Message from Component C");

            // Test: Attempting to create another instance of Logger will return the existing instance
            MyLogger logger2 = MyLogger.GetInstance();
            Console.WriteLine(logger == logger2); // Output: True
            Console.WriteLine(ReferenceEquals(logger, logger2)); // Output: True

            // Test: Multiple threads logging messages simultaneously
            // Create two threads that log messages concurrently
            System.Threading.Tasks.Parallel.Invoke(
                () =>
                {
                    for (int i = 0; i < 10; i++)
                    {
                        logger.LogMessage($"Thread 1: Message {i}");
                    }
                },
                () =>
                {
                    for (int i = 0; i < 10; i++)
                    {
                        logger.LogMessage($"Thread 2: Message {i}");
                    }
                }
            );

            Console.WriteLine("Log messages have been written to the log file.");
        }
    }
}