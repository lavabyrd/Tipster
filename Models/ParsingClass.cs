using System;

namespace Tipster.Models
{
    public class ParseControl
    {
        public static string DateParse(string DateRan)
        {
            DateTime ParsedDate = DateTime.Parse(DateRan);
            return ParsedDate.ToShortDateString();
        }

        public static decimal AmountParse(string amount)
        {

            try
            {
                amount = amount.Replace("m", "");
                decimal AmountOut = Decimal.Parse(amount);
                return AmountOut;
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid Amount entered: " + amount);
                Console.WriteLine("Try again");
                return 0;
            }
        }

        public static bool ResultBoolCheck(string Result)
        {
            if (Result == "true")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
