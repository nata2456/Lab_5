using System;
using System.Text.Json;


namespace ChainOfResponsibility
{

    
    class SmsHandler : AbstractHandler
    {
        public override object Handle(object request)
        {
            Random rnd = new Random();
            var num = rnd.Next(100000, 1000000);
            string code = num.ToString("000000");
            Console.WriteLine(code);
            int counter = 3;
            for (int i = 0; i < counter; i++)
            {
                Console.WriteLine("Enter the received code");
                string input = Convert.ToString(Console.ReadLine());
                if (input == code)
                {
                    return base.Handle(request);
                }
                else
                {
                    Console.WriteLine("Wrong code");

                }
            }
            return null;


        }
    }
    class ResponceHandler : AbstractHandler
    {
        public override object Handle(object request)
        {
            Console.WriteLine("Привіт!");
            return "";
        }
    }
}

