using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Activities;
using System.Globalization;

namespace SefidTools
{
    public class Georgian2Jalali : CodeActivity
    {
        [Input("Date")]
        public InArgument<DateTime> date { get; set; }
        [Output("Jalali")]
        public OutArgument<string> Jalali{ get; set; }
        protected override void Execute(CodeActivityContext executionContext)
        {
            Jalali.Set(executionContext, DateConverter(executionContext.GetValue(date)));
        }

        public string DateConverter(DateTime GeorgianDate)
        {
            PersianCalendar PerCal = new PersianCalendar();
            string Year, Day, Month;
            Year = PerCal.GetYear(GeorgianDate).ToString();
            Month = PerCal.GetMonth(GeorgianDate).ToString();
            Day = PerCal.GetDayOfMonth(GeorgianDate).ToString();
            if (Day.Length == 1)
            {
                Day = PerCal.GetDayOfMonth(GeorgianDate).ToString().Insert(0, "0");
            }
            if (Month.Length == 1)
            {
                Month = PerCal.GetMonth(GeorgianDate).ToString().Insert(0, "0");
            }
            return Year + '/' + Month + '/' + Day;
        }
    }
}
