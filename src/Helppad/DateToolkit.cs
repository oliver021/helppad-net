﻿using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Helppad
{
    /// <summary>
    /// The method groups to work with Datetime
    /// </summary>
    public static class DateToolkit
    {
        public static bool IsLastDayOfMonth(CultureInfo culture = null)
        {
            var now = DateTime.Now.Day;
            SimpleToolkit.FallbackValue(culture, () => CultureInfo.CurrentCulture);
            return default;
        }

        /// <summary>
        /// Get week number in the Year
        /// </summary>
        /// <param name="date">The target date.</param>
        /// <param name="culture">The culture instance to resolve week.</param>
        /// <param name="fullWeek">Set if the fullweek true or false.</param>
        /// <param name="day">Set the first day on week.</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetWeekOfYear(DateTime date, CultureInfo culture = null, bool fullWeek = false, DayOfWeek day = DayOfWeek.Monday)
        {
            return SimpleToolkit.FallbackValue(culture, () => CultureInfo.CurrentCulture)
                .Calendar
                .GetWeekOfYear(date, fullWeek ?  CalendarWeekRule.FirstFullWeek : CalendarWeekRule.FirstDay, day);
        }

        /// <summary>
        /// Calculate the ago date time.
        /// </summary>
        /// <param name="dateTime">The target date time for calculate.</param>
        /// <param name="weekDetection">If is true then the method make a disction between week and days.</param>
        /// <returns>A struct with count and category unit type.</returns>
        public static DateDisstance Ago(DateTime dateTime, bool weekDetection = true)
        {
            DateDisstance disstance;

            // sbtract the datetime
            var timeSpan = DateTime.Now.Subtract(dateTime);

            // calculate for differents cases
            if (timeSpan <= TimeSpan.FromSeconds(60))
            {
                disstance = new DateDisstance(timeSpan.Seconds, DateUnits.LessMinute);
            }
            else if (timeSpan <= TimeSpan.FromMinutes(60))
            {
                disstance = new DateDisstance(timeSpan.Minutes, DateUnits.Minute);
            }
            else if (timeSpan <= TimeSpan.FromHours(24))
            {
                disstance = new DateDisstance(timeSpan.Hours, DateUnits.Hour);
            }
            else if (timeSpan <= TimeSpan.FromDays(7) && weekDetection)
            {
                disstance = new DateDisstance(timeSpan.Days, DateUnits.Day);
            }
            else if (timeSpan <= TimeSpan.FromDays(30))
            {
                disstance = (weekDetection) ? new DateDisstance(timeSpan.Days / 7, DateUnits.Week)
                    : new DateDisstance(timeSpan.Days, DateUnits.Day );
            }
            else if (timeSpan <= TimeSpan.FromDays(365))
            {
                disstance = new DateDisstance(timeSpan.Days / 30, DateUnits.Month);
            }
            else
            {
                disstance = new DateDisstance(timeSpan.Days / 365, DateUnits.Year);
            }

            // return the final result
            return disstance;
        }
    }
}
