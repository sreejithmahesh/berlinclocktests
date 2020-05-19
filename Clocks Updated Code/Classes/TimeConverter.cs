using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Messaging;
using System.Text;

namespace BerlinClock
{
    public class TimeConverter : ITimeConverter
    {
        public string convertTime(string aTime)
        {
            string[] time = aTime.Split(':');
            int hours = Convert.ToInt32(time[0]);
            int minutes = Convert.ToInt32(time[1]);
            int seconds = Convert.ToInt32(time[2]);

            // Logic for seconds
            string sec = (seconds % 2 == 0) ? "Y" : "O";

            //Logic for hours
            //string first line hours R
            int firstRowHours = hours / 5;
            string firstRowHourRed = string.Empty;
            for (int i = 0; i < 4; i++)
            {
                if (i < firstRowHours)
                    firstRowHourRed += "R";
                else
                    firstRowHourRed += "O";
            }
            //Logic for second Hour row
            int secondRowHours = hours % 5;
            string secondRowHourRed = string.Empty;
            for (int i = 0; i < 4; i++)
            {
                if (i < secondRowHours)
                    secondRowHourRed += "R";
                else
                    secondRowHourRed += "O";
            }

            //Logic for first minute Row
            int firstRowMinute = minutes / 5;
            string firstRowMinuteRed = string.Empty;
            for (int i = 1; i <= 11; i++)
            {
                if (i <= firstRowMinute)
                    if (i % 3 == 0)
                        firstRowMinuteRed += "R";
                    else
                        firstRowMinuteRed += "Y";
                else
                    firstRowMinuteRed += "O";
            }
            //Logic for second minute Row

            int secondRowMinutes = minutes % 5;
            string secondRowMinutesRed = string.Empty;
            for (int i = 0; i < 4; i++)
            {
                if (i < secondRowMinutes)
                    secondRowMinutesRed += "Y";
                else
                    secondRowMinutesRed += "O";
            }

            return new StringBuilder().Append(sec)
                         .AppendLine()
                         .Append(firstRowHourRed)
                         .AppendLine()
                         .Append(secondRowHourRed)
                         .AppendLine()
                         .Append(firstRowMinuteRed)
                         .AppendLine()
                         .Append(secondRowMinutesRed).ToString();
        }
    }
}
