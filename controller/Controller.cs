using System;
 
namespace jolly_pirate
{
    class Controller
    {
        public void initMasterController()
        {
            UserDAL uDAL = new UserDAL();
            View v = new View();

            do
            {
                Console.Clear();
                v.startMenu();
                int input;
                
                try
                {            
                    if (int.TryParse(Console.ReadLine(), out input) && input >= 0 && input <= 2)
                    {
                        switch (input)
                        {
                            case 0:
                                Console.WriteLine();
                                return;
                            case 1:
                                
                                Console.WriteLine("Case: {0}",input);
                                // Call login method from LonginController

                                break;
                            case 2:
                                RegisterModel rm = new RegisterModel(uDAL, v);
                                rm.TryRegister(v.RegNumber(),v.regFullName());
                                break;            
                        }
                    }

                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("You need to enter a number between 0 and 2!\nPress any key to continue, ESC exits ");
                        Console.ResetColor();
                        }
                    }

                catch (Exception e)
                {
                    Console.WriteLine("{0} Exception caught.", e);
                }
            }
            while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        } 
    }
}