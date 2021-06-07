using System;
using System.Text.Json;


namespace ChainOfResponsibility
{
    class Handler {
    setNext(handler) {
        this._next = handler;
        return handler;
    }
    handle(request) {
        if (this._next && this._next.handle)
            return this._next.handle(request);
        else
            return null;
    }

}
class LogHandler extends Handler {
    handle(request) {
        console.log(Log\n ${JSON.stringify(request)});
        return super.handle(request);
    }
}
    class Request
    {
        public String Login { get; set; }
        public String Password { get; set; }


        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }

    class NotRobot : AbstractHandler
    {
        public override object Handle(object request)
        {
            Random rnd = new Random();
            int a = rnd.Next(1, 100);
            int b = rnd.Next(1, 100);
            Console.WriteLine($"{a} + {b} = ");
            int sum = a + b;
            int counter = 3;
            for (int i = 0; i < counter; i++)
            {
                int input = Convert.ToInt32(Console.ReadLine());
                if (input == sum)
                {
                    return base.Handle(request);
                }
                else
                {
                    Console.WriteLine("Wrong number.");

                }
            }
            return null;

        }
    }

    class AuthorizeHandler : AbstractHandler
    {
        private bool Check(string Login, string Password)
        {
            return Login == "user" && Password == "user";
        }
        public override object Handle(object request)
        {
            Console.WriteLine("Authorize");

            int counter = 3;
            for (int i = 0; i < counter; i++)
            {
                Console.WriteLine("Enter login ");
                string login = Convert.ToString(Console.ReadLine());
                Console.WriteLine("Enter password ");
                string password = Convert.ToString(Console.ReadLine());
                Request req = new Request();
                req.Login = login;
                req.Password = password;
                if (Check(req.Login, req.Password))
                {
                    return base.Handle(request);
                }
                else
                {
                    Console.WriteLine("Wrong login or password");

                }
            }
            return null;

        }
    }

    
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

