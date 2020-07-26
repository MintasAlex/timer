using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Threading;

namespace TimeCount
{
    public class Timer
    {
        public Stopwatch StartTimer()
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            return stopWatch;
        }

        public string GetCurrentTime(Stopwatch stopWatch, string s)
        {
            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopWatch.Elapsed;

            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);

            int seconds = int.Parse(s.Substring(17, 2)) + ts.Seconds;
            int minutes = int.Parse(s.Substring(14, 2)) +ts.Minutes;
            int hours = int.Parse(s.Substring(11, 2)) + ts.Hours;
            int day = int.Parse(s.Substring(8, 2));
            int month = int.Parse(s.Substring(5, 2));
            int year = int.Parse(s.Substring(0, 4));

            //afisare
            if (seconds >= 60)
            {
                seconds = seconds - 60; minutes++;
                if (minutes >= 60)
                {
                    minutes = minutes - 60; hours++;
                    if (hours >= 24)
                    {
                        hours = hours - 24; day++;
                        if (day > 31 && (month==1 || month==3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12))
                        {
                            day = day - 31; month++;
                            if (day > 30 && (month == 4 || month == 6 || month == 9 || month == 7 || month == 8 || month == 11))
                            {
                                day = day - 30; month++;
                                if (day > 28 && month == 2) //De adaugat: cazul anilor bisecti
                                {
                                    day = day - 28; month++;
                                    if (month > 12)
                                    {
                                        month = month - 12; year++;
                                    }
                                }
                            }

                        }
                    }
                }
            }

            return ($"{year}-{month}-{day}T{hours}:{minutes}:{seconds}Z");
            //2020-07-24T13:30:19Z

        }

        public void WriteLineWithTimer(string consoleFormatedText, string datetime)
        {
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t"+datetime);
            Console.WriteLine(consoleFormatedText);
        }

        //public string ElapsedMillisecondsSinceInitialization { get; }

        public string ElapsedMillisecondsSinceInitialization(Stopwatch stopWatch)
        {
            TimeSpan ts = stopWatch.Elapsed;
            int msElapsed = ts.Hours * 3600000 + ts.Minutes * 60000 + ts.Seconds * 1000 + ts.Milliseconds;
            return ("Milisecunde de la creearea instantei: " + msElapsed);
        }
    }
}
