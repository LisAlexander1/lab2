using RandomRusName;

namespace lab2
{
    public class Program
    {
        
        private static void Main(string[] args)
        {
            var rn = new RandomName();
            var r = new Random();
            do
            {
                int height = (Console.WindowHeight - 1) / 2;
                var payments = new Payment[height];

                for (int payment_index = 0; payment_index < payments.Length; payment_index++)
                {
                    payments[payment_index] = new Payment(
                        rn.GetName(),
                        new DateOnly(r.Next(2000, 2023), r.Next(1, 13), r.Next(1, 29)),
                        r.NextDouble() * 200000 - 10000,
                        r.NextDouble() * 100,
                        13,
                        22,
                        r.Next(0, 23));

                    var payment = payments[payment_index];
                    
                    Console.WriteLine($"Имя - {payment.FullName}, Устроился - {payment.Admission.ToString("dd/MM/yyyy")}, Оклад - {payment.Salary:F0}, "+
                        $"Надбавка - {payment.Bonus:F0}%, Налог - {payment.Tax:F0}%\nРабочих дней в месяце - {payment.WorkingDaysInMonth}, " +
                        $"Отработано - {payment.WorkedDaysInMonth}, Начисления - {payment.AccruedAmount:F0}, Удержания - {payment.RetainedAmount:F0}, На руки - {payment.IssuedOnHand():F0}"
                        );
                }
                Console.ReadKey();
            } while (true);
        }
    }
}