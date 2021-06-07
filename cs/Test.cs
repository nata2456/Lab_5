using System;
using System.Collections.Generic;
using ChainOfResponsibility;

namespace Test
{
    class BehavioralPatterns
    {
        public static void TestChainOfResponsibility()
        {
           var Chain = new LogHandler();
            Chain
                .SetNext(new NotRobot())
                .SetNext(new AuthorizeHandler())
                .SetNext(new SmsHandler())
                .SetNext(new ResponceHandler());
                
            Console.WriteLine(Chain.Handle(new Request()));

           
        }


    }
}