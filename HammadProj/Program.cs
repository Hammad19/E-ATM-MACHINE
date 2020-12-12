using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HammadProj
{
    class Program
    {
        public static string userindx;
        public static string userlogedin = "";
        public static int bal;
        public static string cardnum = "";
        public static string pin = "";

        static void Main(string[] args)
        {
            Front();

        }


        public static void ExceptionCatcher(string x)
        {

            Console.Clear();
            Main_header();
            Console.WriteLine("\n\n\t\t " + x + "\n\n");
            Footer();


        }

        public static void Front()
        {
            Main_header();
            Console.WriteLine("\n\n" + "\t\t\t" + "HUU ATM FACILTIY MAKES");
            Console.WriteLine("\t\t\t" + "LIFE SIMPLE\n\n");
            Footer();
            Console.Write("\t\t" + "Press <any> key to continue:");
            Console.ReadKey();
            Console.Clear();
            Menu();
            Console.ReadKey();

        }

        public static void Menu()
        {
            int i = 0;
            while (i < 3)
            {


                string pin_no = "";
                Main_header();
                Console.Write("\n\t\t   Enter Your Card No: ");
                string card_no = Console.ReadLine();
                Console.Write("\n\t\t   Enter Your Pin No: ");

                do
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    // Backspace Should Not Work
                    if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                    {
                        pin_no += key.KeyChar;
                        Console.Write("*");
                    }
                    else
                    {
                        if (key.Key == ConsoleKey.Backspace && pin_no.Length > 0)
                        {
                            pin_no = pin_no.Substring(0, (pin_no.Length - 1));
                            Console.Write("\b \b");
                        }
                        else if (key.Key == ConsoleKey.Enter)
                        {
                            break;
                        }
                    }
                } while (true);
                pin = pin_no;
                Footer();
                StreamReader sr = new StreamReader("Users.txt", true);
                string line;
                while ((line = sr.ReadLine()) != null)
                {

                    string[] values = new string[5];
                    values = line.Split(',');
                    if (card_no == values[1])
                    {

                        if (pin_no == values[2])
                        {
                            cardnum = card_no;
                            userindx = values[0];
                            i = 0;
                            sr.Close();
                            WelcomeScreen();

                        }

                        else
                        {
                            Console.WriteLine("\t\tIncorrect User or Pin\n");
                            Console.Write("\t\tPress <any> key to Try Again:");
                            Console.ReadKey();
                            Console.Clear();
                            break;

                        }
                    }
                    //else
                    //{
                    //    Console.WriteLine("\t\tIncorrect User or Pin\n");
                    //    Console.Write("\t\tPress <any> key to Try Again:");
                    //    Console.ReadKey();
                    //    Console.Clear();

                    //}


                }
                sr.Close();



                i++;
            }
            if (i == 3)
            {
                Main_header();
                Console.WriteLine("\t\tMachine Has Siezed Your Atm Card");
                Footer();
            }
        }


        public static void Main_header()
        {
            Console.Clear();
            DateTime d = DateTime.Now;


            Console.WriteLine("\n\n\t\tDate:\t\t\t   " + d.ToString("dd/MM/yy") + "\n\t\t====================================");
            Console.WriteLine("\t\t\t\t" + "E-ATM");
            Console.WriteLine("\t\t====================================\n\n");
        }
        public static void Footer()
        {
            Console.WriteLine("\n\t\t====================================");
        }
        public static void WelcomeScreen()
        {

            StreamReader sr1 = new StreamReader("Users.txt", true);
            string line;
            while ((line = sr1.ReadLine()) != null)
            {
                string[] values = new string[5];
                values = line.Split(',');
                if (userindx == values[0])
                {
                    userlogedin = values[3];
                    bal = Convert.ToInt32(values[4]);
                }
            }
            sr1.Close();



            do
            {
                try
                {
                    Console.Clear();
                    Main_header();

                    Console.WriteLine("\n\t\t" + "\t  Welcome: " + userlogedin + "\n\n\n");
                    Console.WriteLine("\t\t" + "1.Withdrawal.\t\t    2.Deposit\n");
                    Console.WriteLine("\t\t" + "3.Bal Inq\t4.Last 5 Transactions\n");
                    Console.Write("\t\t" + "5.Mini Statement\t 6.Change Pin\n\n\n");
                    Console.Write("\t\t\t       7.Log Out\n\n\n");
                    Footer();
                    Console.Write("\t\t");
                    int opt = Convert.ToInt32(Console.ReadLine());


                    Features f = new Features();


                    if (opt >= 1 && opt <= 7)
                    {
                        switch (opt)
                        {
                            case 1:


                                DateTime dateTime = DateTime.Now;
                                string today = dateTime.ToString("MM/dd/yy");

                                //You have to create file manually 

                                StreamReader testread = new StreamReader(Program.cardnum + "limit.txt", true);
                                string testline = testread.ReadLine();
                                string[] testval = new string[2];
                                testval = testline.Split(',');
                                testread.Close();
                                if (today == testval[1])
                                {
                                    if (Convert.ToInt32(testval[0]) <= 10)
                                    {

                                        //sr1.Close();
                                        File.Delete(Program.cardnum + "limit.txt");
                                        StreamWriter updatetime = new StreamWriter(Program.cardnum + "limit.txt", true);
                                        int a = Convert.ToInt32(testval[0]) + 1;
                                        updatetime.WriteLine(a + "," + today);
                                        updatetime.Close();
                                        f.Withdraw();
                                        break;


                                    }
                                    else
                                    {
                                        Console.WriteLine("\t\tTransaction Limit Reached");

                                    }
                                }
                                else
                                {


                                    File.Delete(Program.cardnum + "limit.txt");
                                    StreamWriter updatetime = new StreamWriter(Program.cardnum + "limit.txt", true);
                                    updatetime.WriteLine("1," + today);
                                    updatetime.Close();
                                    f.Withdraw();

                                }

                                break;
                            case 2:


                                DateTime dateTimee = DateTime.Now;
                                string todays = dateTimee.ToString("MM/dd/yy");

                                //You have to create file manually 

                                StreamReader testreads = new StreamReader(Program.cardnum + "limit.txt", true);
                                string testline1 = testreads.ReadLine();
                                string[] testval1 = new string[2];
                                testval = testline1.Split(',');
                                testreads.Close();
                                if (todays == testval[1])
                                {
                                    if (Convert.ToInt32(testval[0]) <= 10)
                                    {

                                        //sr1.Close();
                                        File.Delete(Program.cardnum + "limit.txt");
                                        StreamWriter updatetime = new StreamWriter(Program.cardnum + "limit.txt", true);
                                        int a = Convert.ToInt32(testval[0]) + 1;
                                        updatetime.WriteLine(a + "," + todays);
                                        updatetime.Close();
                                        f.Deposit();
                                        break;

                                    }
                                    else
                                    {
                                        Console.WriteLine("\t\tTransaction Limit Reached");

                                    }
                                }
                                else
                                {


                                    File.Delete(Program.cardnum + "limit.txt");
                                    StreamWriter updatetime = new StreamWriter(Program.cardnum + "limit.txt", true);
                                    updatetime.WriteLine("1," + todays);
                                    updatetime.Close();
                                    f.Withdraw();

                                }

                                break;
                            case 3:
                                f.BalInq();
                                break;
                            case 4:
                                //sr1.Close();

                                f.Transactions();

                                break;
                            case 5:
                                //sr1.Close();
                                Console.WriteLine("Mini Statement");
                                f.MiniStatement();
                                break;

                            case 6:
                                f.ChngPin();
                                Console.ReadKey();
                                break;
                                
                            case 7:
                                f.LogOut();

                                Front();
                                Console.ReadKey();
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("\t\tPlease Choose The Options Given Above");
                    }

                    if (opt == 7)
                    {
                        break;
                    }


                }
                catch (Exception)
                {
                    string a = "Please Use Numbers Only";
                    ExceptionCatcher(a);

                }
                Console.Write("\t\t" + "Press <any> key to continue:");
                Console.ReadKey();

            } while (true);

        }


    }
}
