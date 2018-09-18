using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace excercise
{
    class Program
    {
        int accbalance = 10000;
        public static void Main(string[] args)
        {
            try
            {
                Program obj = new Program();
                obj.ATMFunction();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ATMFunction()
        {
            int choice;
            Console.WriteLine("ATM Service");
            Console.WriteLine("Press 1 Withdraw");
            Console.WriteLine("Press 2 Balance Check");
            Console.WriteLine("Enter your Choice");

            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    withdraw();
                    break;

                case 2:
                    printbalance();
                    break;

                default:
                    Console.WriteLine("Invalid Choice");
                    HoldScreen();
                    break;
            }
        }

        public void HoldScreen()
        {
            Console.ReadKey();
        }

        public void printbalance()
        {
            Console.WriteLine("Available account balance=" + Convert.ToInt32(accbalance));
            HoldScreen();
        }

        public void withdraw()
        {
            int withdrwal;
            Console.WriteLine("Enter withdrwal amount");
            withdrwal = Convert.ToInt32(Console.ReadLine());
            if (checksufficientbalance(withdrwal))
            {
                withdraw(withdrwal);
                accbalance -= withdrwal;
            }

        }

        public bool checksufficientbalance(int withdraw)
        {
            if (withdraw < 0)
            {
                Console.WriteLine("Invalid Amount to withdraw");
                HoldScreen();
                return false;
            }
            else if (withdraw > accbalance)
            {
                Console.WriteLine("Insufficient balance in account to withdraw");
                HoldScreen();
                return false;
            }
            else if (withdraw % 500 != 0 && withdraw % 100 != 0 && withdraw % 50 != 0 && withdraw % 10 != 0 && withdraw % 5 != 0)
            {
                Console.WriteLine("Withdraw amount should be in multiple of 500,100,50,10,5");
                HoldScreen();
                return false;
            }
            else
            {
                return true;
            }
        }

        public void withdraw(int withdrwal)
        {
            int currencyfivehundred = 0;
            int currencyonehundred = 0;
            int currencyfifty = 0;
            int currencyten = 0;
            int currencyfive = 0;

            while (withdrwal % 500 >= 0 && withdrwal >= 500)
            {
                currencyfivehundred++;
                withdrwal -= 500;
            }
            while (withdrwal % 100 >=0 && withdrwal >= 100)
            {
                currencyonehundred++;
                withdrwal -= 100;
            }
            while (withdrwal % 50 >=0 && withdrwal >= 50)
            {
                currencyfifty++;
                withdrwal -= 50;
            }
            while (withdrwal % 10 >=0 && withdrwal >= 10)
            {
                currencyten++;
                withdrwal -= 10;
            }
            while (withdrwal % 5 >=0 && withdrwal >= 5)
            {
                currencyfive++;
                withdrwal -= 5;
            }
            printcurrencydenomination(currencyfivehundred, currencyonehundred, currencyfifty, currencyten, currencyfive);
        }

        public void printcurrencydenomination(int currencyfivehundred, int currencyonehundred, int currencyfifty, int currencyten = 0, int currencyfive = 0)
        {
            Console.WriteLine("Currency Denomination");
            if(checkcurrencydnomincationzero(currencyfivehundred))
            {
                Console.WriteLine("500 X" + Convert.ToString(currencyfivehundred));
            }
            if (checkcurrencydnomincationzero(currencyonehundred))
            {
                Console.WriteLine("100 X" + Convert.ToString(currencyonehundred));
            }
            if (checkcurrencydnomincationzero(currencyfifty))
            {
                Console.WriteLine("50 X" + Convert.ToString(currencyfifty));
            }
            if (checkcurrencydnomincationzero(currencyten))
            {
                Console.WriteLine("10 X" + Convert.ToString(currencyten));
            }
            if (checkcurrencydnomincationzero(currencyfive))
            {
                Console.WriteLine("5 X" + Convert.ToString(currencyfive));
            }
            HoldScreen();
        }

        public bool checkcurrencydnomincationzero(int count)
        {
            if (count > 0)
                return true;
            else
                return false;
        }
    }
}
