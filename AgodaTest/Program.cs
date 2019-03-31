using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using core;


    namespace AgodaTest
    {
        class Program
        {
            static void Main(string[] args)
            {
            string ErrorMessage = "";
            PasswordManager AgodaPasswordSystem = new PasswordManager();
            AgodaPasswordSystem.ChangePassword("Sdfsdf", "asdasfAF@13#SD23!@" ,out ErrorMessage);
            Console.WriteLine(ErrorMessage);
            
            
































        }
    }
    }
