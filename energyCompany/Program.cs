using energyCompany.controllers;
using energyCompany.models;
using System;
using System.IO;

namespace energyCompany
{
    class Program
    {
        static IEndpoint obj = new Endpoint();
        static void Main(string[] args)
        {
            int opt = 0;
            while (opt !=6)
            {
                Console.WriteLine("System Energy Company");
                Console.WriteLine("Choose the option by typing the number:");
                Console.WriteLine("1 - Insert");
                Console.WriteLine("2 - Update");
                Console.WriteLine("3 - Delete");
                Console.WriteLine("4 - List All");
                Console.WriteLine("5 - Find by Serial number");
                Console.WriteLine("6 - exit");

                opt = int.Parse(Console.ReadLine());

                InitOption(opt);

            }
            Console.WriteLine("Pressione qualquer tecla para sair...");
            Console.ReadKey();
        }

        static void InitOption(int opt)
        {
            string SerialNumber, FirmwareVersion, ModelDescription, StateDescription;
            int ModelId = 0, Number = 0, State = 0;
            bool successModel = false, successNumber = false, successState = false;

            switch (opt)
            {   
                case 1:

                    Console.WriteLine("Serial Number:");
                    SerialNumber = Console.ReadLine();

                    while (successModel == false)
                    {
                        Console.WriteLine("Meter Model Id:");
                        Console.WriteLine("16 - NSX1P2W");
                        Console.WriteLine("17 - NSX1P3W");
                        Console.WriteLine("18 - NSX2P3W");
                        Console.WriteLine("19 - NSX2P4W");
                        string keyModel = Console.ReadLine();
                        if (keyModel == "16" || keyModel == "17" || keyModel == "18" || keyModel == "19")
                        {
                            successModel = int.TryParse(keyModel, out ModelId);
                        }
                    }

                    while (successNumber == false)
                    {
                        Console.WriteLine("Meter Number:");
                        string keyNumber = Console.ReadLine();
                        successNumber = int.TryParse(keyNumber, out Number);
                    }
                    

                    Console.WriteLine("Firmware Version:");
                    FirmwareVersion = Console.ReadLine();

                    while(successState == false)
                    {

                        Console.WriteLine("Meter state:");
                        Console.WriteLine("0 - Disconnected");
                        Console.WriteLine("1 - Connected");
                        Console.WriteLine("2 - Armed");
                        string keyState = Console.ReadLine();
                        if (keyState == "0" || keyState == "1" || keyState == "2")
                        {
                            successState = int.TryParse(keyState, out State);
                        }  
                    }
                    
                    obj.Create(SerialNumber, ModelId, Number, FirmwareVersion, State);


                    break;

                case 2:
                    Console.WriteLine("Serial Number:");
                    SerialNumber = Console.ReadLine();

                    Console.WriteLine("New State:");
                    State = Convert.ToInt32(Console.ReadLine());

                    obj.Update(SerialNumber, State);

                    obj.ListAll();

                    break;
                case 3:
                    Console.WriteLine("Serial Number for delete:");
                    SerialNumber = Console.ReadLine();

                    obj.Delete(SerialNumber);

                    obj.ListAll();
                    break;
                case 4:
                    obj.ListAll();

                    break;
                case 5:
                    Console.WriteLine("Serial Number for search:");
                    SerialNumber = Console.ReadLine();

                    obj.FindBy(SerialNumber);

                    break;
                case 6:
                    break;
                default:
                    Console.WriteLine("Unknow command, please try again");
                    break;


            }
        }
    }

}
