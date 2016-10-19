using DatabaseTestSetManager.Lib.Razor.Models;
using System;

namespace DatabaseTestSetManager.Lib.ScriptBuilders.CustomTemplateModels
{
    public class SqlServerActionModel : IActionTemplateModel
    {
        public string RenderFromNow(TimeSpan timeSpan)
        {
            // Build the query
            var statement = "GETUTCDATE()";
            if (timeSpan.Milliseconds != 0)
                statement = "DATEADD(millisecond, " + timeSpan.Milliseconds + ", " + statement + ")";
            if (timeSpan.Seconds != 0)
                statement = "DATEADD(second, " + timeSpan.Seconds + ", " + statement + ")";
            if (timeSpan.Minutes != 0)
                statement = "DATEADD(minute, " + timeSpan.Minutes + ", " + statement + ")";
            if (timeSpan.Hours != 0)
                statement = "DATEADD(hour, " + timeSpan.Hours + ", " + statement + ")";
            if (timeSpan.Days != 0)
                statement = "DATEADD(day, " + timeSpan.Days + ", " + statement + ")";

            return statement;
        }

        public string RenderFromNow(DateTimeOffset dateTime)
        {
            //CAST(CAST(DATEADD(day, 12, GETUTCDATE()) AS DATE) AS VARCHAR(20)) + 'T00:00:00Z'

            // Calculate the difference
            var now = DateTimeOffset.Now.ToOffset(dateTime.Offset);
            var timeSpan = dateTime - now;

            // Do some ajustment for the time. This is aprox. 50ms when it runs for the first time.
            var duration = timeSpan.Duration();
            var ms = timeSpan.Milliseconds;
            if (ms != 0 && duration.TotalSeconds >= 1)
            {
                if (timeSpan.TotalMilliseconds > 0)
                    ms = (1000 - timeSpan.Milliseconds);
                else
                    ms *= -1;
                timeSpan = timeSpan.Add(TimeSpan.FromMilliseconds(ms));
            }

            // Apply the timezone offset
            timeSpan += dateTime.Offset;
            
            return RenderFromNow(timeSpan);
        }
    }
}
