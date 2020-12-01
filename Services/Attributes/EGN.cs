using System;
using System.ComponentModel.DataAnnotations;

namespace eDoc.Services.Attributes
{
    [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = false)]
    public class EGN : ValidationAttribute
    {
        public EGN()
        {
            this.ErrorMessage = "Моля, въведете валидно ЕГН.";
        }
        public override bool IsValid(object value)
        {
            if (value is string personalIDNumber)
            {
                if (personalIDNumber.Length != 10)
                {
                    return false;
                }
                foreach (char digit in personalIDNumber)
                {
                    if (!Char.IsDigit(digit))
                    {
                        return false;
                    }
                }
                int month = int.Parse(personalIDNumber.Substring(2, 2));
                int year = 0;
                if (month < 13)
                {
                    year = int.Parse("19" + personalIDNumber.Substring(0, 2));
                }
                else if (month < 33)
                {
                    month -= 20;
                    year = int.Parse("18" + personalIDNumber.Substring(0, 2));
                }
                else
                {
                    month -= 40;
                    year = int.Parse("20" + personalIDNumber.Substring(0, 2));
                }
                int day = int.Parse(personalIDNumber.Substring(4, 2));
                DateTime dateOfBirth = new DateTime();
                if (!DateTime.TryParse(String.Format("{0}/{1}/{2}", day, month, year), out dateOfBirth))
                {
                    return false;
                }
                int[] weights = new int[] { 2, 4, 8, 5, 10, 9, 7, 3, 6 };
                int totalControlSum = 0;
                for (int i = 0; i < 9; i++)
                {
                    totalControlSum += weights[i] * (personalIDNumber[i] - '0');
                }
                int controlDigit = 0;
                int reminder = totalControlSum % 11;
                if (reminder < 10)
                {
                    controlDigit = reminder;
                }
                int lastDigitFromIDNumber = int.Parse(personalIDNumber[9..]);
                if (lastDigitFromIDNumber != controlDigit)
                {
                    return false;
                }
                return true;
            }
            return false;
        }
    }
}

