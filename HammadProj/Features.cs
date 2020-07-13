using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using HammadProj;

namespace HammadProj
{
    class Features
    {
        DateTime d = DateTime.Now;
        public void Withdraw()
        {
            

            
            //StreamReader sr = new StreamReader("Users.txt", true);
            //string line;
            //string[] values = new string[5];
            //while ((line = sr.ReadLine()) != null)
            //{
            //    values = line.Split(',');
            //}
            //sr.Close();
            
            do
            {
                int temp = 0;
                Console.Clear();
                Program.Main_header();
                try
                {
                    StreamReader srx = new StreamReader("Users.txt", true);
                    string linex;
                    while ((linex = srx.ReadLine()) != null)
                    {
                        string[] valuesx = new string[5];
                        valuesx = linex.Split(',');
                        if (Program.userindx == valuesx[0])
                        {

                            Program.bal = Convert.ToInt32(valuesx[4]);
                        }
                    }
                    srx.Close();

                    Console.Write("\n\n\t\tEnter The Amount To Withdraw ");
                    int wdrwamnt = Convert.ToInt32(Console.ReadLine());
                    if (wdrwamnt <= 1000 && wdrwamnt > 0)
                    {
                        if (wdrwamnt % 100 == 0)
                        {
                            if (wdrwamnt <= Program.bal)
                            {
                                temp = Program.bal - wdrwamnt;
                                Console.WriteLine("\n\t\tRemaining Balance is : " + temp);
                                StreamReader sr1 = new StreamReader("Users.txt", true);
                                StreamWriter sw = new StreamWriter("UserTemp.txt", true);
                                string line1;
                                string[] values1 = new string[5];
                                while ((line1 = sr1.ReadLine()) != null)
                                {
                                    values1 = line1.Split(',');
                                    if (Program.userindx == values1[0])
                                    {
                                        sw.WriteLine(values1[0] + "," + values1[1] + "," + values1[2] + "," + values1[3] + "," + temp);
                                    }
                                    else
                                    {
                                        sw.WriteLine(line1);
                                    }
                                }
                                sw.Close();
                                sr1.Close();
                                File.Delete("Users.txt");
                                File.Move("UserTemp.txt", "Users.txt");

                                StreamWriter check = new StreamWriter(Program.cardnum + ".txt", true);
                                check.Close();


                                StreamWriter writetran = new StreamWriter(Program.cardnum + "temp.txt", true);
                                writetran.WriteLine(wdrwamnt + "," + temp + "," + d.ToString("dd/MM/yy hh:mm:ss tt") + "," + "Withdraw");
                                StreamReader readtran = new StreamReader(Program.cardnum + ".txt", true);
                                string transline;
                                while ((transline = readtran.ReadLine()) != null)
                                {
                                    writetran.WriteLine(transline);
                                }
                                writetran.Close();
                                readtran.Close();

                                File.Delete(Program.cardnum + ".txt");
                                File.Move(Program.cardnum + "temp.txt", Program.cardnum + ".txt");


                                Program.Footer();
                                break;




                            }
                            else
                            {
                                Console.WriteLine("\t\tInsufficient Balance");
                                Console.Write("\t\t" + "Press <any> key to continue:");
                                Console.ReadKey();
                                
                            }
                        }
                        else
                        {
                            Console.WriteLine("\t\tPlease Enter A Multiple Of 100");
                            Console.Write("\t\t" + "Press <any> key to continue:");
                            Console.ReadKey();
                            
                        }
                    }
                    else
                    {
                        Console.WriteLine("\t\tLimit Exceeded");
                        Console.Write("\t\t" + "Press <any> key to continue:");
                        Console.ReadKey();
                        
                    }
                }
                catch (Exception)
                {
                    string w = "Please Enter Money in Numeric Form";
                    Program.ExceptionCatcher(w);
                }
            } while (true);


        }


        public void Deposit()
        {
            do
            {
                int temp = 0;
                //StreamReader sr = new StreamReader("Users.txt", true);
                //string line;
                //string[] values = new string[5];
                //while ((line = sr.ReadLine()) != null)
                //{
                //    values = line.Split(',');
                //}
                //sr.Close();
                Console.Clear();

                Program.Main_header();
                try
                {
                    StreamReader srx = new StreamReader("Users.txt", true);
                    string linex;
                    while ((linex = srx.ReadLine()) != null)
                    {
                        string[] valuesx = new string[5];
                        valuesx = linex.Split(',');
                        if (Program.userindx == valuesx[0])
                        {

                            Program.bal = Convert.ToInt32(valuesx[4]);
                        }
                    }
                    srx.Close();
                    Console.Write("\n\n\t\tEnter The Amount To Deposit :");
                    int depamount = Convert.ToInt32(Console.ReadLine());
                    if (depamount > 0 && depamount <= 1000)
                    {
                        if (depamount % 100 == 0)
                        {
                            temp = Program.bal + depamount;
                            Console.WriteLine("\n\t\tYour Balance is : " + temp);
                            StreamReader sr1 = new StreamReader("Users.txt", true);
                            StreamWriter sw = new StreamWriter("UserTemp.txt", true);
                            string line1;
                            string[] values1 = new string[5];
                            while ((line1 = sr1.ReadLine()) != null)
                            {
                                values1 = line1.Split(',');
                                if (Program.userindx == values1[0])
                                {
                                    sw.WriteLine(values1[0] + "," + values1[1] + "," + values1[2] + "," + values1[3] + "," + temp);
                                }
                                else
                                {
                                    sw.WriteLine(line1);
                                }
                            }
                            sw.Close();
                            sr1.Close();
                            File.Delete("Users.txt");
                            File.Move("UserTemp.txt", "Users.txt");

                            StreamWriter check = new StreamWriter(Program.cardnum + ".txt", true);
                            check.Close();


                            StreamWriter writetran = new StreamWriter(Program.cardnum + "temp.txt", true);
                            writetran.WriteLine(depamount + "," + temp + "," + d.ToString("dd/MM/yy hh:mm:ss tt") + "," + "Deposit");
                            StreamReader readtran = new StreamReader(Program.cardnum + ".txt", true);
                            string transline;
                            while ((transline = readtran.ReadLine()) != null)
                            {
                                writetran.WriteLine(transline);
                            }
                            writetran.Close();
                            readtran.Close();

                            File.Delete(Program.cardnum + ".txt");
                            File.Move(Program.cardnum + "temp.txt", Program.cardnum + ".txt");

                            Program.Footer();
                            
                            
                            break;


                        }
                        else
                        {
                            Console.WriteLine("\t\tPlease Enter A Multiple Of 100");
                            Console.Write("\t\t" + "Press <any> key to continue:");
                            Console.ReadKey();
                            
                        }
                    }
                    else
                    {
                        Console.WriteLine("\t\tLimit Exceeded");
                        Console.Write("\t\t" + "Press <any> key to continue:");
                        Console.ReadKey();
                        
                    }
                }
                catch (Exception)
                {
                    string w = "Please Enter Money in Numeric Form";
                    Program.ExceptionCatcher(w);
                }
            } while (true);


        }

        public void Transactions()
        {


            Console.Clear();
            Program.Main_header();
            try
            {
                StreamReader sr = new StreamReader(Program.cardnum + ".txt", true);

                string line;
                string[] values = new string[5];
                int count = 0;
                while (((line = sr.ReadLine()) != null) && count < 5)
                {
                    values = line.Split(',');
                    Console.WriteLine("\tDate: " + values[2] + "\tTransaction Type: " + values[3] + "\tAmount: " + values[0]);
                    count++;
                }
                sr.Close();
                Program.Footer();
            }
            
            catch (Exception) 
            {
                string q = "No Transactions Recorded";
                Program.ExceptionCatcher(q);
            }
            

        }

        public void MiniStatement()
        {
            Console.Clear();
            Program.Main_header();
            try
            {
                StreamReader sr = new StreamReader(Program.cardnum + ".txt", true);
                string line;
                string[] values = new string[5];

                while (((line = sr.ReadLine()) != null))
                {
                    values = line.Split(',');
                    Console.WriteLine("\tDate: " + values[2] + "\tTransaction Type: " + values[3] + "\tAmount: " + values[0]);

                }
                sr.Close();

                StreamReader sr2 = new StreamReader("Users.txt", true);
                string linex;
                while ((linex = sr2.ReadLine()) != null)
                {
                    string[] valuesx = new string[5];
                    valuesx = linex.Split(',');
                    if (Program.userindx == values[0])
                    {

                        Program.bal = Convert.ToInt32(values[4]);
                        
                    }
                    
                }
                sr2.Close();

                Console.WriteLine("\n\t\tYour Remaining Balance is " + Program.bal + "\n\n");



                Program.Footer();
            }
            
            catch (Exception) 
            {
                string q = "No Transactions Recorded";
                Program.ExceptionCatcher(q);
            }
            



        }
        public  void LogOut()
        {
            Program.Main_header();
            Console.WriteLine("\n\n\t\tYou have Been Logged Out");
            Console.WriteLine("\t\tThank You For Visiting HUU EATM");
            Program.Footer();
            Console.Write("\t\t" + "Press <any> key to continue:");
            Console.ReadKey();


        }

        public void BalInq()
        {
            StreamReader sr1 = new StreamReader("Users.txt", true);
            string line;
            while ((line = sr1.ReadLine()) != null)
            {
                string[] values = new string[5];
                values = line.Split(',');
                if (Program.userindx == values[0])
                {
                    
                    Program.bal = Convert.ToInt32(values[4]);
                }
            }
            sr1.Close();
            Program.Main_header();
            Console.WriteLine("\t\tYour Remaining Balance is " + Program.bal + "\n\n");
            Program.Footer();
        }

        public void ChngPin()
        {
            Console.Clear();
            Program.Main_header();

            Console.Write("\n\n\t\tEnter Existing Pin\t");
            string pinx = Console.ReadLine();
            StreamReader sr2 = new StreamReader("Users.txt", true);
            StreamWriter sw = new StreamWriter("UserTemp.txt", true);
            string line1;
            string[] valuesx = new string[5];
            while ((line1 = sr2.ReadLine()) != null)
            {
                valuesx = line1.Split(',');
                if (pinx == valuesx[2])
                {
                    Console.Write("\t\tEnter New Pin\t\t");
                    string newpin = Console.ReadLine();
                    sw.WriteLine(valuesx[0] + "," + valuesx[1] + "," + newpin + "," + valuesx[3] + "," + valuesx[4]);
                    Console.WriteLine("\t\tPin Has Been Changed Successfully");
                    Program.Footer();
                    
                }
                else
                {
                    sw.WriteLine(line1);
                }
            }
            sw.Close();
            sr2.Close();
            File.Delete("Users.txt");
            File.Move("UserTemp.txt", "Users.txt");
        }

        
    }
}
