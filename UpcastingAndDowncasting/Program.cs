using System;
using UpcastingAndDowncasting.Entities;

namespace UpcastingAndDowncasting
{
    class Program
    {
        static void Main(string[] args)
        {
            Account acc = new Account(1001, "Igor", 0.0);
            BusinessAccount bacc = new BusinessAccount(1002, "Maria", 0.0, 500.0);

            // UPCASTING

            Account acc1 = bacc; //uma var do tipo Account recebe naturalmente o valor de qualquer subclasse dela
            Account acc2 = new BusinessAccount(1003, "Bob", 0.0, 200.0); //usando o new com um tipo de subclasse também funciona
            Account acc3 = new SavingsAccount(1004, "Ana", 0.0, 0.01);


            // DOWNCASTING (é uma operação insegura, usar apenas quando necessário)

            BusinessAccount acc4 = (BusinessAccount)acc2;
            acc4.Loan(100.0);

            //BusinessAccount acc5 = (BusinessAccount)acc3;//acc3 é do tipo SavingsAccount, que não é compatível com o BusinessAccount (dará erro na execução)
            if(acc3 is BusinessAccount) //evita o erro da tentativa acima
            {
                //BusinessAccount acc5 = (BusinessAccount)acc3;
                BusinessAccount acc5 = acc3 as BusinessAccount; //outra forma de fazer o mesmo que acima
                acc5.Loan(200.0);
                Console.WriteLine("Loan!");
            }

            if (acc3 is SavingsAccount)
            {
                //SavingsAccount acc5 = (SavingsAccount)acc3;
                SavingsAccount acc5 = acc3 as SavingsAccount;
                acc5.UpdateBalance();
                Console.WriteLine("Update!");
            }
        }
    }
}