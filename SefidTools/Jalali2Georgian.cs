using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Activities;
using System.Globalization;

namespace SefidTools
{
    public class Jalali2Georgian : CodeActivity
    {
        [Input("Jalali")]
        public InArgument<string> Jalali { get; set; }
        [Output("GeorgianDate")]
        public OutArgument<DateTime> date  { get; set; }
        protected override void Execute(CodeActivityContext executionContext)
        {

            date.Set(executionContext, DateConverter(executionContext.GetValue(Jalali)));
        }

        public DateTime DateConverter(string JalaliDate)
        {
            string Year, Day, Month;
            DateTime dt = DateTime.Now;
            if (JalaliDate.Length == 10)
            {
                Year = JalaliDate.Substring(0, 4);
                Month = JalaliDate.Substring(5, 2);
                Day = JalaliDate.Substring(8, 2);
                PersianCalendar pc = new PersianCalendar();
                dt = new DateTime(Convert.ToInt16(Year), Convert.ToInt16(Month), Convert.ToInt16(Day), pc);
            }
            return dt;
        }
    }
}
