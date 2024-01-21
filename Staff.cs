using System;
using System.Collections.Generic;

namespace PassTask3{
    /// <summary>
    /// This is a Staff class which contains 7 fields
    /// </summary>
    public class Staff{
        private int _id;
        private string _password;
        private StaffPosition _position;
        private List<Purchases> _purchases;
        private List<Cards> _cards;
        private List<Booking> _booking;
        private List<Customer> _customer;

        /// <summary>
        /// This is a default constructor which sets their respective values from the field and parameter. The Purchases, Cards, Booking and Customer lists were also set
        /// </summary>
        /// <param name="id"></param>
        /// <param name="password"></param>
        /// <param name="position"></param>
        public Staff(int id, string password, StaffPosition position){
            _id = id;
            _password = password;
            _position = position;
            _purchases = new List<Purchases>();
            _cards = new List<Cards>();
            _booking = new List<Booking>();
            _customer = new List<Customer>();
        }

        /// <summary>
        /// This is a property for ID that set and get the value of the ID
        /// </summary>
        /// <value></value>
        public int ID{
            get{return _id;}
            set{_id = value;}
        }

        /// <summary>
        /// This is a property for Password that set and get the value of the Password
        /// </summary>
        /// <value></value>
        public string Password{
            get{return _password;}
            set{_password = value;}
        }

        /// <summary>
        /// This is a property for Position that set and get the value of the Staff's Position
        /// </summary>
        /// <value></value>
        public StaffPosition Position{
            get{return _position;}
            set{_position = value;}
        }

        /// <summary>
        /// This is a property for Puchases List that get the list of _purchases
        /// </summary>
        /// <value></value>
        public List<Purchases> Purchases{
            get{ return _purchases; }
        }

        /// <summary>
        /// This is a property for Cards List that set and get the list of _cards
        /// </summary>
        /// <value></value>
        public List<Cards> Cards{
            get{return _cards;}
            set{_cards = value;}
        }

        /// <summary>
        /// This is a property for Bookings List that set and get the list of _booking
        /// </summary>
        /// <value></value>
        public List<Booking> Bookings{
            get{return _booking;}
            set{_booking = value;}
        }

        /// <summary>
        /// This is a property for Customer List that set and get the list of _customer
        /// </summary>
        /// <value></value>
        public List<Customer> Customer{
            get{return _customer;}
            set{_customer = value;}
        }

        /// <summary>
        /// This is a method that lets the Manager view the total sales in a day or a month
        /// </summary>
        /// <param name="option"></param>
        /// <param name="_purchases"></param>
        /// <param name="_booking"></param>
        public void ViewSales(string option, List<Purchases> _purchases, List<Booking> _booking){
            if (option == "daily"){
                Console.WriteLine("\nDAILY SALES - Today is 01/05/2021\n");
                Console.WriteLine("Cards: ");
                int totalamount = 0;
                foreach (Purchases p in _purchases){
                    if (p.Date == "01/05/2021"){
                        foreach (Cards c in p.Cards){
                            Console.Write(c.Name + ", ");
                        }
                        Console.WriteLine("RM" + p.Amount);
                        totalamount += p.Amount;
                    }
                }

                Console.WriteLine("\nBooking: ");
                foreach (Booking b in _booking){
                    if (b.Date == "01/05/2021"){
                        b.UpdateAmount(b);
                        Console.WriteLine(b.Date + ", " + b.Customer.Name + ", RM" + b.Amount);
                        totalamount += b.Amount;
                    }
                }
                Console.WriteLine("\nTotal Sales: RM" + totalamount);
            }

            if (option == "monthly"){
                Console.WriteLine("\nMONTHLY SALES - This month is 05 - May, 2021\n");
                Console.WriteLine("Cards: ");
                int totalamount = 0;
                foreach (Purchases p in _purchases){
                string date = p.Date.Substring(3);
                    if (p.Date.Contains("05/2021") == true){
                        foreach (Cards c in p.Cards){
                            Console.Write(c.Name + ", ");
                        }
                        Console.WriteLine("RM" + p.Amount);
                        totalamount += p.Amount;
                    }
                }
                Console.WriteLine("\nBooking: ");
                foreach (Booking b in _booking){
                    if (b.Date.Contains("05/2021") == true){
                        b.UpdateAmount(b);
                        Console.WriteLine(b.Date + ", " + b.Customer.Name + ", RM" + b.Amount);
                        totalamount += b.Amount;
                    }
                }
                Console.WriteLine("\nTotal Sales: RM" + totalamount);
            }
        }

        /// <summary>
        /// This is a method that lets the Manager view loyal customers with more than RM1000 in total purchases
        /// </summary>
        /// <param name="_customer"></param>
        public void ViewLoyalCustomer(List<Customer> _customer){
            if (_position == StaffPosition.Manager){
                Console.WriteLine("\nLoyal Customers (>RM1,000): ");
                foreach (Customer c in _customer){
                    if (c.TotalPurchase > 1000){
                        c.UpdatePoints();
                        Console.WriteLine("ID: " + c.No + ", " + c.Name + ", Points: " + c.Points + ", RM" + c.TotalPurchase);
                    }
                }
            }
        }

        /// <summary>
        /// This is a method that lets Shop Admin oversee customer base
        /// </summary>
        /// <param name="customer"></param>
        public void OverseeCustomerBase(List<Customer> _customer){
            Console.WriteLine();
            int i = 0;
            Console.WriteLine("\nWhich Customer base would you like to oversee?\n");
            foreach (Customer c in _customer){
                Console.WriteLine(i + ". Customer ID: " + c.No + "\n");
                i += 1;
            }
            Console.Write("Your option (0/1/2...): ");
            int option2 = Convert.ToInt32(Console.ReadLine());

            if (_position == StaffPosition.ShopAdmin){
                _customer[option2].UpdatePoints();
                Console.WriteLine("\nID: " + _customer[option2].No + "\nName: " + _customer[option2].Name + "\nMembership: " + _customer[option2].Status + "\nPoints: " + _customer[option2].Points);
            }
        }

        /// <summary>
        /// This is a method that lets Shop Admin add customers into the list
        /// </summary>
        /// <param name="customer"></param>
        public void AddCustomer(List<Customer> _customer, int custnext){
            Customer newcustomer = new Customer(0000, "", Membership.Normal, 0);
            _customer.Add(newcustomer);

            Console.WriteLine("\nYou will be adding the Customer details line-by-line.");

            Console.WriteLine("\nNow adding: Number");
            Console.Write("Enter a number: ");
            int number = Convert.ToInt32(Console.ReadLine());
            _customer[custnext].No = number;

            Console.WriteLine("\nNow adding: Name");
            Console.Write("Enter a name: ");
            string name = Console.ReadLine();
            _customer[custnext].Name = name;

            Console.WriteLine("\nNow adding: Membership Status");
            Console.Write("Enter a Membership Status (Normal/Member): ");
            string status = Console.ReadLine();
            if (status == "Normal"){
                _customer[custnext].Status = Membership.Normal;
            } else if (status == "Member"){
                _customer[custnext].Status = Membership.Member;
            }

            Console.WriteLine("\nYou added:\nCustomerNo: " + _customer[custnext].No + "\nName: " + _customer[custnext].Name + "\nMembership: " + _customer[custnext].Status);
        }

        /// <summary>
        /// This is a method that lets Shop Admin edit customer details from the list
        /// </summary>
        /// <param name="customer"></param>
        public void EditCustomer(List<Customer> _customer){
            int i = 0;
            Console.WriteLine("\nWhich customer would you like to edit?\n");
            foreach (Customer c in _customer){
                Console.WriteLine(i + ". CustomerNo: " + c.No + "\nName: " + c.Name + "\nMembership: " + c.Status + "\n");
                i += 1;
            }
            Console.Write("Your option (0/1/2...): ");
            int option2 = Convert.ToInt32(Console.ReadLine());
            
            Console.WriteLine("You will be editing the Customer details line-by-line.");

            Console.WriteLine("Number: " + _customer[option2].No);
            Console.WriteLine("Name: " + _customer[option2].Name);
            Console.WriteLine();

            Console.WriteLine("\nNow editing: Number: " + _customer[option2].No);
            Console.Write("Enter a Number to replace it with: ");
            int number = Convert.ToInt32(Console.ReadLine());
            _customer[option2].No = number;

            Console.WriteLine("\nNow editing: Name: " + _customer[option2].Name);
            Console.Write("Enter a Name to replace it with: ");
            string name = Console.ReadLine();
            _customer[option2].Name = name;

            Console.WriteLine("\nNow editing: Membership Status: " + _customer[option2].Status);
            Console.Write("Enter a Membership Status to replace it with (Normal/Member): ");
            string status = Console.ReadLine();
            if (status == "Normal"){
                _customer[option2].Status = Membership.Normal;
            } else if (status == "Member"){
                _customer[option2].Status = Membership.Member;
            }

            Console.WriteLine("\nEditing complete!");
        }

        /// <summary>
        /// This is a method that lets Manager and Shop Admin filter and search for cards from the inventory
        /// </summary>
        /// <param name="_cards"></param>
        public void ViewInventory(List<Cards> _cards){
            if (_position == StaffPosition.Manager){
                Console.WriteLine("Filter trading cards: ");
                Console.Write("Filter by (name/seriesno/rarity/colour/type): ");
                string userinput = Console.ReadLine();

                if (userinput == "name"){
                    Console.Write("\nNow enter Name of card: ");
                    string filter = Console.ReadLine();
                    foreach (Cards c in _cards){
                        if (c.Name == filter){
                            c.PrintDetails();
                        }
                    }

                } else if (userinput == "seriesno"){
                    Console.Write("\nNow enter Series No. of card: ");
                    int filter = Convert.ToInt32(Console.ReadLine());
                    foreach (Cards c in _cards){
                        if (c.SeriesNo == filter){
                            c.PrintDetails();
                        }
                    }

                } else if (userinput == "rarity"){
                    Console.Write("\nNow enter Rarity of card: ");
                    string filter = Console.ReadLine();
                    foreach (Cards c in _cards){
                        if (c.Rarity == filter){
                            c.PrintDetails();
                        }
                    }

                } else if (userinput == "colour"){
                    Console.Write("\nNow enter Colour of card: ");
                    string filter = Console.ReadLine();
                    foreach (Cards c in _cards){
                        if (c.Colour == filter){
                            c.PrintDetails();
                        }
                    }

                } else if (userinput == "type"){
                    Console.Write("\nNow enter Type of card (Foil/Non_foil): ");
                    string filter = Console.ReadLine();
                    foreach (Cards c in _cards){
                        if (c.Type.ToString() == filter){
                            c.PrintDetails();
                        }
                    }

                } else {
                    Console.WriteLine("Please enter exactly from the options.");
                }

            } else if (_position == StaffPosition.ShopAdmin){
                Console.WriteLine("\n1. Search for related inventory \n2. View low inventory stock");
                Console.Write("\nYour option (1/2): ");
                string userinput = Console.ReadLine();

                if (userinput == "1"){
                    Console.WriteLine("\nSearch for related inventory: ");
                    Console.Write("Search by (name/seriesno/rarity/colour/type): ");
                    userinput = Console.ReadLine();

                    if (userinput == "name"){
                        Console.Write("\nNow enter Name of card: ");
                        string filter = Console.ReadLine();
                        foreach (Cards c in _cards){
                            if (c.Name == filter){
                                c.PrintDetails();
                            }
                        }

                    } else if (userinput == "seriesno"){
                        Console.Write("\nNow enter Series No. of card: ");
                        int filter = Convert.ToInt32(Console.ReadLine());
                        foreach (Cards c in _cards){
                            if (c.SeriesNo == filter){
                                c.PrintDetails();
                            }
                        }

                    } else if (userinput == "rarity"){
                        Console.Write("\nNow enter Rarity of card: ");
                        string filter = Console.ReadLine();
                        foreach (Cards c in _cards){
                            if (c.Rarity == filter){
                                c.PrintDetails();
                            }
                        }

                    } else if (userinput == "colour"){
                        Console.Write("\nNow enter Colour of card: ");
                        string filter = Console.ReadLine();
                        foreach (Cards c in _cards){
                            if (c.Colour == filter){
                                c.PrintDetails();
                            }
                        }
                    } else if (userinput == "type"){
                        Console.Write("\nNow enter Type of card (Foil/Non_foil): ");
                        string filter = Console.ReadLine();
                        foreach (Cards c in _cards){
                            if (c.Type.ToString() == filter){
                                c.PrintDetails();
                            }
                        }

                    } else {
                        Console.WriteLine("Please enter exactly from the options.");
                    }

                } else if (userinput == "2"){
                    Console.WriteLine("\nLow Inventory Stock: ");
                    foreach (Cards c in _cards){
                        if (c.Quantity <= 10){
                            c.PrintDetails();
                        }
                    }
                } else {
                    Console.WriteLine("Please enter either 1 or 2.");
                }
            }
        }

        /// <summary>
        /// This is a method that lets Manager and Shop Admin view booking details
        /// </summary>
        /// <param name="_booking"></param>
        /// <param name="_customer"></param>
        public void ViewBooking(List<Booking> _booking, List<Customer> _customer){
            if (_position == StaffPosition.Manager){
                Console.WriteLine("View booking by: \n 1. Day \n 2. Date");
                Console.Write("Enter option (1/2): ");
                string userinput = Console.ReadLine();
                
                if (userinput == "1"){
                    Console.WriteLine("\nPlease enter the day of the booking.\n");
                    Console.Write("List of days: ");
                    foreach (Booking b in _booking){
                        Console.Write(b.Day + ", ");
                    }
                    Console.WriteLine();
                    Console.Write("Enter day from list: ");
                    int bday = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();

                    foreach (Booking b in _booking){
                        if (bday == b.Day){
                            b.UpdateAmount(b);
                            Console.WriteLine("Customer Name: " + b.Customer.Name);
                            Console.WriteLine("Date: " + b.Date);
                            b.UpdateAmount(b);
                            b.PrintDetails();
                        }
                    }

                } else if (userinput == "2"){
                    Console.WriteLine("\nPlease enter the date of the booking (dd/mm/yyyy)\n");
                    Console.Write("List of dates: ");
                    foreach (Booking b in _booking){
                        Console.Write(b.Date + ", ");
                    }
                    Console.WriteLine();
                    Console.Write("Enter date from list (dd/mm/yyyy): ");
                    string bdate = Console.ReadLine();
                    Console.WriteLine();

                    foreach (Booking b in _booking){
                        if (bdate == b.Date){
                            b.UpdateAmount(b);
                            Console.WriteLine("Customer Name: " + b.Customer.Name);
                            Console.WriteLine("Day: " + b.Day);
                            b.UpdateAmount(b);
                            b.PrintDetails();
                        }
                    }
                }

            } else if (_position == StaffPosition.ShopAdmin){
                Console.WriteLine("View booking by: \n 1. Name \n 2. Date");
                Console.Write("Enter option (1/2): ");
                string userinput = Console.ReadLine();

                if (userinput == "1"){
                    Console.WriteLine("\nPlease enter the name of the customer.\n");
                    Console.Write("List of customer names: ");
                    foreach (Customer c in _customer){
                        Console.Write(c.Name + ", ");
                    }
                    Console.WriteLine();
                    Console.Write("Enter name: ");
                    string custname = Console.ReadLine();
                    Console.WriteLine();
                    
                    foreach (Booking b in _booking){
                        if (custname == b.Customer.Name){
                            Console.WriteLine("Date: " + b.Date);
                            Console.WriteLine("Day: " + b.Day);
                            b.UpdateAmount(b);
                            b.PrintDetails();
                        }
                    }

                } else if (userinput == "2"){
                    Console.WriteLine("\nPlease enter the date of the booking (dd/mm/yyyy)\n");
                    Console.Write("List of dates: ");
                    foreach (Booking b in _booking){
                        Console.Write(b.Date + ", ");
                    }
                    Console.WriteLine();
                    Console.Write("Enter date: ");
                    string bdate = Console.ReadLine();
                    Console.WriteLine();

                    foreach (Booking b in _booking){
                        if (bdate == b.Date){
                            b.UpdateAmount(b);
                            Console.WriteLine("Customer Name: " + b.Customer.Name);
                            Console.WriteLine("Day: " + b.Day);
                            b.UpdateAmount(b);
                            b.PrintDetails();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// This is a method that lets Shop Admin add booking into the list
        /// </summary>
        /// <param name="booking"></param>
        /// <param name="_customer"></param>
        public void AddBooking(Booking booking, List<Customer> _customer){
            Console.WriteLine("\nYou will be adding the Booking details line-by-line.");

            Console.WriteLine("\nNow adding: Day");
            Console.Write("Enter Days (1/2/3...): ");
            int day = Convert.ToInt32(Console.ReadLine());
            booking.Day = day;

            Console.WriteLine("\nNow adding: Date");
            Console.Write("Enter Date (dd/mm/yyyy): ");
            string date = Console.ReadLine();
            booking.Date = date;

            Console.WriteLine("\nNow adding: Starting hour");
            Console.Write("Enter Starting Hour (6/12/15...): ");
            int shour = Convert.ToInt32(Console.ReadLine());
            booking.StartHour = shour;

            Console.WriteLine("\nNow adding: Hours");
            Console.Write("Enter Duration (hours): ");
            int hours = Convert.ToInt32(Console.ReadLine());
            booking.Hours = hours;

            Console.WriteLine("\nNow adding: Customer");
            int i = 0;
            foreach (Customer c in _customer){
                Console.WriteLine(i + ". CustomerNo: " + c.No + "\nName: " + c.Name + "\nMembership: " + c.Status + "\n");
                i += 1;
            }
            Console.Write("Enter a Customer (1/2/3...): ");
            int option = Convert.ToInt32(Console.ReadLine());
            booking.Customer = _customer[option];

            _booking.Add(booking);

            Console.WriteLine("\nBooking added sucessfully!");
        }

        /// <summary>
        /// This is a method that lets Shop Admin edit booking details from the list
        /// </summary>
        /// <param name="booking"></param>
        public void EditBooking(List<Booking> _booking){
            int i = 0;
            Console.WriteLine("\nWhich Booking would you like to edit?\n");
            foreach (Booking b in _booking){
                Console.WriteLine(i + ". Booking Day: " + b.Day + "\nDate: " + b.Date + "\nStarting Hour: " + b.StartHour + "\nDuration (Hours): " + b.Hours + "\nBy Customer: " + b.Customer.Name + "\n");
                i += 1;
            }
            Console.Write("Your option (0/1/2...): ");
            int option2 = Convert.ToInt32(Console.ReadLine());

            string userinput = "";
            Console.WriteLine("\nYou will be editing the Booking details line-by-line.\n");
            Console.WriteLine("By Customer: " + _booking[option2].Customer.Name);
            Console.WriteLine("Date: " + _booking[option2].Date);
            Console.WriteLine("Day: " + _booking[option2].Day);
            _booking[option2].UpdateAmount(_booking[option2]);
            _booking[option2].PrintDetails();
            Console.WriteLine();

            Console.WriteLine("Now editing: Date: " + _booking[option2].Date);
            Console.Write("Enter new Date: ");
            userinput = Console.ReadLine();
            string date = _booking[option2].Date; date.Replace(date, userinput);

            Console.WriteLine("\nNow editing: Day: " + _booking[option2].Day);
            Console.Write("Enter new Days: ");
            userinput = Console.ReadLine();
            _booking[option2].Day = Convert.ToInt32(userinput);

            Console.WriteLine("\nNow editing: Starting Hour: " + _booking[option2].StartHour);
            Console.Write("Enter new Starting Hour: ");
            userinput = Console.ReadLine();
            _booking[option2].StartHour = Convert.ToInt32(userinput);

            Console.WriteLine("\nNow editing: Duration (Hours): " + _booking[option2].Hours);
            Console.Write("Enter new Duration (Hours): ");
            userinput = Console.ReadLine();
            _booking[option2].Hours = Convert.ToInt32(userinput);

            Console.WriteLine("\nEditing complete!");
        }

        /// <summary>
        /// This is a method that lets Shop Admin add cards into the inventory
        /// </summary>
        /// <param name="cards"></param>
        public void AddInventory(List<Cards> _cards, int cardnext){
            Cards newcards = new Cards("", 000, "", "", CardType.Non_foil, 0);
            _cards.Add(newcards);

            Console.WriteLine("\nYou will be adding the Card details line-by-line.");

            Console.WriteLine("\nNow adding: Name");
            Console.Write("Enter a Name: ");
            string name = Console.ReadLine();
            _cards[cardnext].Name = name;

            Console.WriteLine("\nNow adding: Series No.");
            Console.Write("Enter a Series No.: ");
            int seriesno = Convert.ToInt32(Console.ReadLine());
            _cards[cardnext].SeriesNo = seriesno;

            Console.WriteLine("\nNow adding: Rarity");
            Console.Write("Enter a Rarity: ");
            string rarity = Console.ReadLine();
            _cards[cardnext].Rarity = rarity;

            Console.WriteLine("\nNow adding: Colour");
            Console.Write("Enter a Colour: ");
            string colour = Console.ReadLine();
            _cards[cardnext].Colour = colour;

            Console.WriteLine("\nNow adding: Card Type");
            Console.Write("Enter a Card Type (Foil/Non_foil): ");
            string status = Console.ReadLine();
            if (status == "Foil"){
                _cards[cardnext].Type = CardType.Foil;
            } else if (status == "Non_foil"){
                _cards[cardnext].Type = CardType.Non_foil;
            }

            Console.WriteLine("\nNow adding: Quantity");
            Console.Write("Enter a Quantity: ");
            int quantity = Convert.ToInt32(Console.ReadLine());
            _cards[cardnext].Quantity = quantity;

            Console.WriteLine("\nYou added:\nName: " + _cards[cardnext].Name + "\nSeries No.: " + _cards[cardnext].SeriesNo + "\nRarity: " + _cards[cardnext].Rarity + "\nColour: " + _cards[cardnext].Colour + "\nType: " + _cards[cardnext].Type + "\nQuantity: " + _cards[cardnext].Quantity);
        }

        /// <summary>
        /// This is a method that lets Shop Admin edit cards from the inventory
        /// </summary>
        /// <param name="cards"></param>
        public void EditInventory(List<Cards> _cards){
            int i = 0;
            Console.WriteLine("\nWhich card would you like to edit?\n");
            foreach (Cards c in _cards){
                Console.WriteLine(i + ". Card Name: " + c.Name + "\nSeries No.: " + c.SeriesNo + "\nRarity: " + c.Rarity + "\nColour: " + c.Colour + "\nType: " + c.Type + "\nQuantity: " + c.Quantity + "\n");
                i += 1;
            }
            Console.Write("Your option (0/1/2...): ");
            int option2 = Convert.ToInt32(Console.ReadLine());

            string userinput = "";
            Console.WriteLine("You will be editing the Cards line-by-line.");
            Console.WriteLine("Name: " + _cards[option2].Name);
            Console.WriteLine("Series No.: " + _cards[option2].SeriesNo);
            Console.WriteLine("Rarity: " + _cards[option2].Rarity);
            Console.WriteLine("Colour: " + _cards[option2].Colour);
            Console.WriteLine("Type: " + _cards[option2].Type);
            Console.WriteLine();

            Console.WriteLine("\nNow editing: Name: " + _cards[option2].Name);
            Console.Write("Enter Name to replace it with: ");
            userinput = Console.ReadLine();
            _cards[option2].Name = userinput;

            Console.WriteLine("\nNow editing: Series No.: " + _cards[option2].SeriesNo);
            Console.Write("Enter Series No. to replace it with: ");
            userinput = Console.ReadLine();
            _cards[option2].SeriesNo = Convert.ToInt32(userinput);

            Console.WriteLine("\nNow editing: Rarity: " + _cards[option2].Rarity);
            Console.Write("Enter Rarity to replace it with: ");
            userinput = Console.ReadLine();
            _cards[option2].Rarity = userinput;

            Console.WriteLine("\nNow editing: Colour: " + _cards[option2].Colour);
            Console.Write("Enter Colour to replace it with: ");
            userinput = Console.ReadLine();
            _cards[option2].Colour = userinput;

            Console.WriteLine("\nNow editing: Type: " + _cards[option2].Type);
            Console.Write("Enter either (Foil/Non_Foil): ");
            userinput = Console.ReadLine();
            if (userinput == "Foil"){
                _cards[option2].Type = CardType.Foil;
            } else if (userinput == "Non_Foil"){
                _cards[option2].Type = CardType.Non_foil;
            }

            Console.WriteLine("\nNow editing: Quantity: " + _cards[option2].Quantity);
            Console.Write("Enter Quantity to replace it with: ");
            userinput = Console.ReadLine();
            _cards[option2].Quantity = Convert.ToInt32(userinput);

            Console.WriteLine("\nEditing complete!");
        }

        /// <summary>
        /// This is a method that lets Shop Admin add purchase details to customers
        /// </summary>
        /// <param name="purchases"></param>
        /// <param name="_customer"></param>
        public void AddPurchases(Purchases purchases, List<Customer> _customer){
            Console.WriteLine("\nYou will be adding the Purchase details line-by-line.");

            Console.WriteLine("\nNow adding: Transaction No.");
            Console.Write("Enter a Trans No.: ");
            int transno = Convert.ToInt32(Console.ReadLine());
            purchases.TransNo = transno;

            Console.WriteLine("\nNow adding: Date");
            Console.Write("Enter a Date (dd/mm/yyyy): ");
            string Date = Console.ReadLine();
            purchases.Date = Date;

            Console.WriteLine("\nNow adding: Amount");
            Console.Write("Enter an Amount: ");
            int amount = Convert.ToInt32(Console.ReadLine());
            purchases.Amount = amount;

            Console.WriteLine("\nNow adding: Customer\n");
            int i = 0;
            foreach (Customer c in _customer){
                Console.WriteLine(i + ". CustomerNo: " + c.No + "\nName: " + c.Name + "\nMembership: " + c.Status + "\n");
                i += 1;
            }

            Console.Write("Enter a Customer (1/2/3...): ");
            int option = Convert.ToInt32(Console.ReadLine());
            purchases.Customer = _customer[option];
            _customer[option].UpdatePoints();

            _purchases.Add(purchases);

            if (purchases.Customer.Status == Membership.Member){
                purchases.Amount = purchases.Amount - (purchases.Amount*(20/100));
                Console.WriteLine("\n20% discount have been applied!\n");
            }
            purchases.Customer.UpdateTotalPurchase(purchases);

            Console.WriteLine("Purchase added sucessfully!");
        }

        /// <summary>
        /// This is a method that Removes the selected customer from the list
        /// </summary>
        /// <param name="_customer"></param>
        public void RemoveCustomer(List<Customer> _customer){
            int i = 0;
            Console.WriteLine("\nWhich customer would you like to delete?\n");
            foreach (Customer c in _customer){
                Console.WriteLine(i + ". CustomerNo: " + c.No + "\nName: " + c.Name + "\nMembership: " + c.Status + "\n");
                i += 1;
            }
            Console.Write("Your option (0/1/2...): ");
            int option2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Customer " + _customer[option2].Name + " deleted sucessfully!");
            _customer.Remove(_customer[option2]);
        }

        /// <summary>
        /// This is a method that Removes the selected card from the inventory
        /// </summary>
        /// <param name="_cards"></param>
        public void RemoveInventory(List<Cards> _cards){
            int i = 0;
            Console.WriteLine("\nWhich card would you like to delete?\n");
            foreach (Cards c in _cards){
                Console.WriteLine(i + ". Card Name: " + c.Name + "\nSeries No.: " + c.SeriesNo + "\nRarity: " + c.Rarity + "\nColour: " + c.Colour + "\nType: " + c.Type + "\nQuantity: " + c.Quantity + "\n");
                i += 1;
            }
            Console.Write("Your option (0/1/2...): ");
            int option2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\nCard " + _cards[option2].Name + " deleted sucessfully!");
            _cards.Remove(_cards[option2]);
        }

        /// <summary>
        /// This is a method that Cancels the selected booking from the list
        /// </summary>
        /// <param name="_booking"></param>
        public void CancelBooking(List<Booking> _booking){
            int i = 0;
            Console.WriteLine("\nWhich Booking would you like to cancel?\n");
            foreach (Booking b in _booking){
            Console.WriteLine(i + ". Booking Day: " + b.Day + "\nDate: " + b.Date + "\nStarting Hour: " + b.StartHour + "\nDuration (Hours): " + b.Hours + "\nBy Customer: " + b.Customer.Name + "\n");
                i += 1;
            }
            Console.Write("Your option (0/1/2...): ");
            int option2 = Convert.ToInt32(Console.ReadLine());

            int currenthour = -24; // sample hour
            if (_booking[option2].StartHour - currenthour < 24){
                Console.WriteLine(currenthour);
                Console.WriteLine("There are less than 24 hours to the start of the game. You may not cancel now.");
            } else if (_booking[option2].StartHour - currenthour >= 24){
                _booking.Remove(_booking[option2]);
                Console.WriteLine("\nBooking Cancelled.");
            }
        }
    }
}