//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the Rock.CodeGeneration project
//     Changes to this file will be lost when the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
// <copyright>
// Copyright by the Spark Development Network
//
// Licensed under the Rock Community License (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.rockrms.com/license
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
//
using System;
using System.Collections.Generic;


namespace Rock.Client
{
    /// <summary>
    /// Base client model for AnalyticsSourceDate that only includes the non-virtual fields. Use this for PUT/POSTs
    /// </summary>
    public partial class AnalyticsSourceDateEntity
    {
        /// <summary />
        public int CalendarMonth { get; set; }

        /// <summary />
        public string CalendarMonthName { get; set; }

        /// <summary />
        public string CalendarMonthNameAbbrevated { get; set; }

        /// <summary />
        public string CalendarQuarter { get; set; }

        /// <summary />
        public int CalendarWeek { get; set; }

        /// <summary />
        public int CalendarYear { get; set; }

        /// <summary />
        public string CalendarYearMonth { get; set; }

        /// <summary />
        public string CalendarYearMonthName { get; set; }

        /// <summary />
        public string CalendarYearQuarter { get; set; }

        /// <summary />
        public bool ChristmasIndicator { get; set; }

        /// <summary />
        public bool ChristmasWeekIndicator { get; set; }

        /// <summary />
        public int Count { get; set; }

        /// <summary />
        public DateTime Date { get; set; }

        /// <summary />
        public int DayNumberInCalendarMonth { get; set; }

        /// <summary />
        public int DayNumberInCalendarYear { get; set; }

        /// <summary />
        public int DayNumberInFiscalMonth { get; set; }

        /// <summary />
        public int DayNumberInFiscalYear { get; set; }

        /// <summary />
        public int DayOfWeek { get; set; }

        /// <summary />
        public string DayOfWeekAbbreviated { get; set; }

        /// <summary />
        public string DayOfWeekName { get; set; }

        /// <summary />
        public bool EasterIndicator { get; set; }

        /// <summary />
        public bool EasterWeekIndicator { get; set; }

        /// <summary />
        public string FiscalHalfYear { get; set; }

        /// <summary />
        public string FiscalMonth { get; set; }

        /// <summary />
        public string FiscalMonthAbbrevated { get; set; }

        /// <summary />
        public int FiscalMonthNumberInYear { get; set; }

        /// <summary />
        public string FiscalMonthYear { get; set; }

        /// <summary />
        public string FiscalQuarter { get; set; }

        /// <summary />
        public int FiscalWeek { get; set; }

        /// <summary />
        public int FiscalWeekNumberInYear { get; set; }

        /// <summary />
        public int FiscalYear { get; set; }

        /// <summary />
        public string FiscalYearQuarter { get; set; }

        /// <summary />
        public string FullDateDescription { get; set; }

        /// <summary />
        public int GivingMonth { get; set; }

        /// <summary />
        public string GivingMonthName { get; set; }

        /// <summary />
        public bool HolidayIndicator { get; set; }

        /// <summary />
        public bool LastDayInMonthIndictor { get; set; }

        /// <summary />
        public DateTime SundayDate { get; set; }

        /// <summary />
        public bool WeekHolidayIndicator { get; set; }

        /// <summary />
        public int WeekNumberInMonth { get; set; }

        /// <summary>
        /// Copies the base properties from a source AnalyticsSourceDate object
        /// </summary>
        /// <param name="source">The source.</param>
        public void CopyPropertiesFrom( AnalyticsSourceDate source )
        {
            this.CalendarMonth = source.CalendarMonth;
            this.CalendarMonthName = source.CalendarMonthName;
            this.CalendarMonthNameAbbrevated = source.CalendarMonthNameAbbrevated;
            this.CalendarQuarter = source.CalendarQuarter;
            this.CalendarWeek = source.CalendarWeek;
            this.CalendarYear = source.CalendarYear;
            this.CalendarYearMonth = source.CalendarYearMonth;
            this.CalendarYearMonthName = source.CalendarYearMonthName;
            this.CalendarYearQuarter = source.CalendarYearQuarter;
            this.ChristmasIndicator = source.ChristmasIndicator;
            this.ChristmasWeekIndicator = source.ChristmasWeekIndicator;
            this.Count = source.Count;
            this.Date = source.Date;
            this.DayNumberInCalendarMonth = source.DayNumberInCalendarMonth;
            this.DayNumberInCalendarYear = source.DayNumberInCalendarYear;
            this.DayNumberInFiscalMonth = source.DayNumberInFiscalMonth;
            this.DayNumberInFiscalYear = source.DayNumberInFiscalYear;
            this.DayOfWeek = source.DayOfWeek;
            this.DayOfWeekAbbreviated = source.DayOfWeekAbbreviated;
            this.DayOfWeekName = source.DayOfWeekName;
            this.EasterIndicator = source.EasterIndicator;
            this.EasterWeekIndicator = source.EasterWeekIndicator;
            this.FiscalHalfYear = source.FiscalHalfYear;
            this.FiscalMonth = source.FiscalMonth;
            this.FiscalMonthAbbrevated = source.FiscalMonthAbbrevated;
            this.FiscalMonthNumberInYear = source.FiscalMonthNumberInYear;
            this.FiscalMonthYear = source.FiscalMonthYear;
            this.FiscalQuarter = source.FiscalQuarter;
            this.FiscalWeek = source.FiscalWeek;
            this.FiscalWeekNumberInYear = source.FiscalWeekNumberInYear;
            this.FiscalYear = source.FiscalYear;
            this.FiscalYearQuarter = source.FiscalYearQuarter;
            this.FullDateDescription = source.FullDateDescription;
            this.GivingMonth = source.GivingMonth;
            this.GivingMonthName = source.GivingMonthName;
            this.HolidayIndicator = source.HolidayIndicator;
            this.LastDayInMonthIndictor = source.LastDayInMonthIndictor;
            this.SundayDate = source.SundayDate;
            this.WeekHolidayIndicator = source.WeekHolidayIndicator;
            this.WeekNumberInMonth = source.WeekNumberInMonth;

        }
    }

    /// <summary>
    /// Client model for AnalyticsSourceDate that includes all the fields that are available for GETs. Use this for GETs (use AnalyticsSourceDateEntity for POST/PUTs)
    /// </summary>
    public partial class AnalyticsSourceDate : AnalyticsSourceDateEntity
    {
        /// <summary />
        public int DateKey { get; set; }

    }
}
