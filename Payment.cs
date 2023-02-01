using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    internal class Payment
    {
        private DateOnly _admission;
        private double _salary;
        private double _bonus;
        private int _workedDaysInMonth;
        private int _workingDaysInMonth;
        private double _accruedAmount;
        private double _retainedAmount;

        public Payment(string fullName, DateOnly admission, double salary, double bonus, int tax, int workingDaysInMonth, int workedDaysInMonth)
        {
            FullName = fullName;
            Admission = admission;
            Salary = salary;
            Bonus = bonus;
            Tax = tax;
            WorkingDaysInMonth = workingDaysInMonth;
            WorkedDaysInMonth = workedDaysInMonth;
        }

        public string FullName { get; set; }
        public int Tax { get; set; }


        public DateOnly Admission
        {
            get => _admission;
            set
            {
                if (value < DateOnly.FromDateTime(DateTime.Now))
                {
                    _admission = value;
                    AccruedAmount = Accruals();
                }
            }
        }

        public double Salary
        {
            get => _salary; set
            {
                if (value > 0)
                {
                    _salary = value;
                    AccruedAmount = Accruals();
                }
            }
        }

        public double Bonus
        {
            get => _bonus; set
            {
                if (value >= 0)
                {
                    _bonus = value;
                    AccruedAmount = Accruals();
                }
            }
        }

        public int WorkedDaysInMonth
        {
            get => _workedDaysInMonth; set
            {
                if (value > 0)
                {
                    _workedDaysInMonth = value;
                    AccruedAmount = Accruals();
                }
            }
        }

        public int WorkingDaysInMonth
        {
            get => _workingDaysInMonth; set
            {
                if (value > 0)
                {
                    _workingDaysInMonth = value;
                    AccruedAmount = Accruals();
                }
            }
        }

        public double AccruedAmount 
        {
            get => _accruedAmount; private set
            { 
                _accruedAmount = value;
                RetainedAmount = Retention();
            }
        }

        public double RetainedAmount { get => _retainedAmount; private set => _retainedAmount = value; }

        public double Accruals()
        {
            if (WorkingDaysInMonth > 0)
            {
                return ((double)WorkedDaysInMonth / WorkingDaysInMonth) * Salary * (1 + Bonus / 100);
            }
            return 0;
        }

        public double Retention()
        {
            return AccruedAmount * 0.01 + AccruedAmount * Tax / 100;
        }

        public int Experience()
        {
            return DateTime.Now.Year - Admission.Year;
        }

        public double IssuedOnHand()
        {
            return AccruedAmount - RetainedAmount;
        }

        public static double operator +(Payment pay1, Payment pay2)
        {
            return pay1.IssuedOnHand() + pay2.IssuedOnHand();
        }

        public static double operator -(Payment pay1, Payment pay2)
        {
            return pay1.IssuedOnHand() - pay2.IssuedOnHand();
        }

        public static double operator -(Payment pay1)
        {
            return -pay1.IssuedOnHand();
        }

        public static double operator *(Payment pay1, Payment pay2)
        {
            return pay1.IssuedOnHand() * pay2.IssuedOnHand();
        }

        public static double operator /(Payment pay1, Payment pay2)
        {
            return pay1.IssuedOnHand() / pay2.IssuedOnHand();
        }

        public static bool operator >(Payment pay1, Payment pay2)
        {
            return pay1.IssuedOnHand() > pay2.IssuedOnHand();
        }

        public static bool operator <(Payment pay1, Payment pay2)
        {
            return pay1.IssuedOnHand() < pay2.IssuedOnHand();
        }

        public static bool operator ==(Payment pay1, Payment pay2)
        {
            return pay1.IssuedOnHand() == pay2.IssuedOnHand();
        }

        public static bool operator !=(Payment pay1, Payment pay2)
        {
            return pay1.IssuedOnHand() != pay2.IssuedOnHand();
        }
    }
}
