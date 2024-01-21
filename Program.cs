using System;
using System.Collections.Generic;

namespace PassTask3
{
    class Program
    {
        static void Main(string[] args)
        {
            void ManagerMenu(){
                Console.WriteLine("Menu: ");
                Console.WriteLine("1. Filtering of trading cards");
                Console.WriteLine("2. View booking details");
                Console.WriteLine("3. View sales");
                Console.WriteLine("4. View listing of loyal customer");
                Console.WriteLine("5. Exit");
                Console.Write("\nPlease enter (1/2/3/4/5): ");
            }

            void ShopAdminMenu(){
                Console.WriteLine("Menu: ");
                Console.WriteLine("1. Add/Edit/Delete Customer Account");
                Console.WriteLine("2. Add/Edit/Delete Inventory (Cards)");
                Console.WriteLine("3. View inventory");
                Console.WriteLine("4. Record customer's purchase");
                Console.WriteLine("5. Add/edit/cancel booking details");
                Console.WriteLine("6. View booking details");
                Console.WriteLine("7. Oversee customer base");
                Console.WriteLine("8. Exit");

                Console.Write("\nPlease enter (1/2/3/4/5/6/7/8): ");
            }

            Console.WriteLine("\nPlease login:");
            Console.Write("ID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Password: ");
            string password = Console.ReadLine();

            int custnext = 2;
            int cardnext = 2;
            int pnext = 2;
            int bnext = 2;

            List<Customer> customerlist = new List<Customer>();
            Customer[] customers = {
                new Customer(0523, "Alex", Membership.Member, 5000),
                new Customer(0778, "Bob", Membership.Normal, 50),
                new Customer(0034, "John", Membership.Member, 10000)
            };
            customerlist.AddRange(customers);

            List<Cards> cardlist = new List<Cards>();
            Cards[] cards = {
                new Cards("Machimp",068,"Common","Blue",CardType.Non_foil,100),
                new Cards("MeowOne",150,"Rare","Purple",CardType.Foil,2),
                new Cards("Rat",019,"Common","Purple",CardType.Non_foil,250)
            };
            cardlist.AddRange(cards);

            List<Booking> booklist = new List<Booking>();
            Booking[] bookings = {
                new Booking(3,"01/05/2021",13,2,customerlist[1]),
                new Booking(2,"01/05/2021",9,6,customerlist[2]),
                new Booking(3,"28/05/2021",20,4,customerlist[0])
            };
            booklist.AddRange(bookings);

            List<Purchases> purchaselist = new List<Purchases>();
            Purchases[] purchases = {
                new Purchases(1111,"01/05/2021",50, customerlist[1]),
                new Purchases(2222,"01/05/2021",200, customerlist[0]),
                new Purchases(3333,"10/05/2021",3000, customerlist[2])
            };
            purchaselist.AddRange(purchases);
            purchases[0].Cards.Add(cardlist[2]);
            purchases[1].Cards.Add(cardlist[0]);
            purchases[2].Cards.Add(cardlist[0]);
            purchases[2].Cards.Add(cardlist[1]);
            




            if (id == 5001 && password == "manager123"){
                Staff manager1 = new Staff(5001, "manager123", StaffPosition.Manager);
                Console.WriteLine("\nWelcome, Manager (5001)\n");

                ManagerMenu();

                int loop = 0;

                do{
                    loop = 0;
                    string userinput = Console.ReadLine();

                    if (userinput == "1"){
                        Console.WriteLine();
                        manager1.ViewInventory(cardlist);
                        Console.WriteLine("\nPress Enter to continue\n");
                        loop = 1;

                    } else if (userinput == "2"){
                        Console.WriteLine();
                        manager1.ViewBooking(booklist,customerlist);
                        Console.WriteLine("\nPress Enter to continue\n");
                        loop = 1;

                    } else if (userinput == "3"){
                        Console.WriteLine();
                        Console.WriteLine("View sales by (daily/monthly)?");
                        Console.Write("Your option: ");
                        string option = Console.ReadLine();
                        manager1.ViewSales(option, purchaselist, booklist);
                        Console.WriteLine("\nPress Enter to continue\n");
                        loop = 1;

                    } else if (userinput == "4"){
                        Console.WriteLine();
                        manager1.ViewLoyalCustomer(customerlist);
                        Console.WriteLine("\nPress Enter to continue\n");
                        loop = 1;

                    }else if (userinput == "5"){
                        Console.WriteLine();
                        Console.WriteLine("Thank you for trying my program. I hope you liked it\n");
                        System.Environment.Exit(0);

                    } else {
                        ManagerMenu();
                        loop = 1;
                    }
                } while (loop == 1);



            

                
            } else if (id == 1001 && password == "admin123"){
                Staff shopadmin1 = new Staff(1001, "admin123", StaffPosition.ShopAdmin);
                Console.WriteLine("\nWelcome Shop Admin (1001)\n");

                ShopAdminMenu();

                int loop = 0;

                do{
                    loop = 0;
                    string userinput = Console.ReadLine();

                    if (userinput == "1"){
                        Console.WriteLine();
                        Console.WriteLine("Would you like to (add/edit/delete) customer account?");
                        Console.Write("Your option: ");
                        string option = Console.ReadLine();

                        if (option == "add"){
                            custnext += 1;
                            shopadmin1.AddCustomer(customerlist, custnext);

                        } else if (option == "edit"){
                            shopadmin1.EditCustomer(customerlist);

                        } else if (option == "delete"){
                            shopadmin1.RemoveCustomer(customerlist);
                            custnext -= 1;
                        }

                        Console.WriteLine("\nPress Enter to continue\n");
                        loop = 1;

                    } else if (userinput == "2"){
                        Console.WriteLine("\nWould you like to (add/edit/delete) cards?");
                        Console.Write("Your option: ");
                        string option = Console.ReadLine();

                        if (option == "add"){
                            cardnext += 1;
                            shopadmin1.AddInventory(cardlist, cardnext);

                        } else if (option == "edit"){
                            shopadmin1.EditInventory(cardlist);

                        } else if (option == "delete"){
                            shopadmin1.RemoveInventory(cardlist);
                            cardnext -= 1;
                        }


                        Console.WriteLine("\nPress Enter to continue\n");
                        loop = 1;

                    } else if (userinput == "3"){
                        shopadmin1.ViewInventory(cardlist);
                        Console.WriteLine("\nPress Enter to continue\n");
                        loop = 1;

                    } else if (userinput == "4"){
                        Console.WriteLine();
                        Purchases newpurchases = new Purchases(0000, "", 0, customerlist[custnext]);
                        purchaselist.Add(newpurchases);
                        pnext += 1;
                        shopadmin1.AddPurchases(purchaselist[pnext],customerlist);
                        Console.WriteLine("\nPress Enter to continue\n");
                        loop = 1;

                    } else if (userinput == "5"){
                        Console.WriteLine();
                        Console.Write("\nWould you like to (add/edit/cancel) this booking?: ");
                        string option = Console.ReadLine();

                        if (option == "add"){
                            Booking newbooking = new Booking(0,"",0,0,customerlist[custnext]);
                            booklist.Add(newbooking);
                            bnext += 1;
                            shopadmin1.AddBooking(booklist[bnext], customerlist);

                        } else if (option == "edit"){
                            shopadmin1.EditBooking(booklist);

                        } else if (option == "cancel"){
                            shopadmin1.CancelBooking(booklist);
                            bnext -= 1;
                        }

                        Console.WriteLine("\nPress Enter to continue\n");
                        loop = 1;

                    } else if (userinput == "6"){
                        Console.WriteLine();
                        shopadmin1.ViewBooking(booklist,customerlist);
                        Console.WriteLine("\nPress Enter to continue\n");
                        loop = 1;

                    } else if (userinput == "7"){
                        shopadmin1.OverseeCustomerBase(customerlist);
                        Console.WriteLine("\nPress Enter to continue\n");
                        loop = 1;

                    } else if (userinput == "8"){
                        Console.WriteLine();
                        Console.WriteLine("Thank you for trying my program. I hope you liked it\n");
                        System.Environment.Exit(0);






                    } else {
                        ShopAdminMenu();
                        loop = 1;
                    }
                } while (loop == 1);


            } else {
                Console.WriteLine("\nIncorrect login.\n");
            }
        }
    }
}