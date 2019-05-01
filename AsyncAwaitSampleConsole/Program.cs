using System;
using System.Threading.Tasks;

namespace AsyncAwaitSampleConsole
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Application Start");

            Task t = Task.Run(async () =>
            {
                var task1 = RunTask(1, 12, 500);
                var task2 = RunTask(2, 12, 400);
                var task3 = RunTask(3, 12, 300);

                //Console.WriteLine($"DurationTime of {nameof(task1)}: {task1.Result}");
                //Console.WriteLine($"DurationTime of {nameof(task2)}: {task2.Result}");
                //Console.WriteLine($"DurationTime of {nameof(task3)}: {task3.Result}");
                
                //Console.WriteLine($"DurationTime of {nameof(task1)}: {await task1}"); 
                //Console.WriteLine($"DurationTime of {nameof(task2)}: {await task2}"); 
                //Console.WriteLine($"DurationTime of {nameof(task3)}: {await task3}");
                
                Console.WriteLine($"DurationTime of {nameof(task3)}: {await task3}"); 
                Console.WriteLine($"DurationTime of {nameof(task2)}: {await task2}"); 
                Console.WriteLine($"DurationTime of {nameof(task1)}: {await task1}");      

                //await task1;
                //await task2;
                //await task3;
            });

            t.Wait();
            Console.WriteLine("Application End");
            //t.Wait();
        }

        static async Task<int> RunTask(int num, int iteration, int sleepMilliSeconds)
        {
            int result = 0;
            
            await Task.Run(async () =>
            {
                for (int i = 0; i < iteration; i++)
                {
                    result += sleepMilliSeconds;

                    Console.WriteLine($"Task{num:00}: Iteration{i + 1:00} Start");
                    //Thread.Sleep(sleepMilliSeconds);
                    //await Task.Delay(sleepMilliSeconds);
                    Task t = Task.Delay(sleepMilliSeconds);
                    await t;
                    
                    Console.WriteLine($"Task{num:00}: Iteration{i:00} End");

                    //await t;
                }
            });

            return result;
        }
    }
}