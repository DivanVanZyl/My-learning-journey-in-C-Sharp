/*
 * You will notice that the incorrect balance is given, with the BankAccount class.
 * This is because the Deposit/Withdraw operations are NOT ATOMIC.
 * It's not atomic as a lot of things are happening in Deposit/Withdraw: 
 *      1. temp <- get_balance() + amount 
 *      2. set_Balance(temp)
 *  Critical to understand: SOMETHING CAN HAPPEN BETWEEN 1. and 2. !! This is the issue that we are getting.
 *  
 *  Easiest way to solver this, is to set up a Critical Section. 
 *  Critical Section is a marker around a piece of code that states that only one thread can enter this particular area.
 *  
 *  Use the BankAccount class to demonstrate the problem, and the BankAccountSafe class to demonstrate the solution.
 */ 

namespace Critical_Selections
{
    public class BankAccount
    {
        public int Balance { get; private set; }

        public void Deposit(int amount)
        {
            Balance += amount;
        }

        public void Withdraw(int amount)
        {
            Balance -= amount;
        }
    }
    public class BankAccountSafe
    {
        private object padlock = new object();
        public int Balance { get; private set; }

        public void Deposit(int amount)
        {
            lock (padlock)
            {
                Balance += amount;
            }
        }

        public void Withdraw(int amount)
        {
            lock (padlock)
            {
                Balance -= amount;                
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var tasks = new List<Task>();
            var ba = new BankAccountSafe();

            Console.WriteLine($"Starting balance: {ba.Balance}");

            for(int i = 0; i < 10; i++)
            {
                tasks.Add(Task.Factory.StartNew(() =>
                {
                    for(int j = 0; j < 1000; j++)
                    {
                        ba.Deposit(100);
                    }
                }));

                tasks.Add(Task.Factory.StartNew(() =>
                {
                    for (int j = 0; j < 1000; j++)
                    {
                        ba.Withdraw(100);
                    }
                }));
            }

            Task.WaitAll(tasks.ToArray());

            Console.WriteLine($"Final balance: {ba.Balance}");
        }
    }
}