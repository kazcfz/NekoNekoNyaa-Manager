using System;

namespace PassTask3{
    /// <summary>
    /// This is a Booking class which contains 6 fields
    /// </summary>
    public class Booking{
        private int _day;
        private string _date;
        private int _amount;
        private int _starthour;
        private int _hours;
        private Customer _customer;

        /// <summary>
        /// This is a default constructor which sets their respective values from the field and parameter.
        /// </summary>
        /// <param name="day"></param>
        /// <param name="date"></param>
        /// <param name="starthour"></param>
        /// <param name="hours"></param>
        /// <param name="customer"></param>
        public Booking(int day, string date, int starthour, int hours, Customer customer){
            _day = day;
            _date = date;
            _starthour = starthour;
            _hours = hours;
            _customer = customer;
        }

        /// <summary>
        /// This is a property for Day that set and get the value of the Day
        /// </summary>
        /// <value></value>
        public int Day{
            get{return _day;}
            set{_day = value;}
        }

        /// <summary>
        /// This is a property for Date that set and get the value of the Date
        /// </summary>
        /// <value></value>
        public string Date{
            get{return _date;}
            set{_date = value;}
        }


        /// <summary>
        /// This is a property for Amount that set and get the value of the Amount
        /// </summary>
        /// <value></value>
        public int Amount{
            get{return _amount;}
            set{_amount = value;}
        }


        /// <summary>
        /// This is a property for StartHour that set and get the value of the Starting Hour
        /// </summary>
        /// <value></value>
        public int StartHour{
            get{return _starthour;}
            set{_starthour = value;}
        }

        /// <summary>
        /// This is a property for Hours that set and get the value of the Duration in Hours
        /// </summary>
        /// <value></value>
        public int Hours{
            get{return _hours;}
            set{_hours = value;}
        }
        
        /// <summary>
        /// This is a property for Customer that set and get the values of the Customer
        /// </summary>
        /// <value></value>
        public Customer Customer{
            get{return _customer;}
            set{_customer = value;}
        }


        /// <summary>
        /// This is a method that updates the total purchase amount made for a customer
        /// </summary>
        /// <param name="Customer"></param>
        public void UpdateTotalPurchase(Customer Customer){
            Customer.TotalPurchase += _amount;
        }


        /// <summary>
        /// This is a method that updates the price of a booking by checking the duration hours
        /// </summary>
        /// <param name="booking"></param>
        public void UpdateAmount(Booking booking){
            for (int i=0; i<_hours; i=i+2){
                if (i % 2 == 0){
                _amount += 10;
                }
            }
        }


        /// <summary>
        /// This is a method that displays some information of the booking details
        /// </summary>
        public void PrintDetails(){
            Console.WriteLine("Starting Hour: " + _starthour);
            Console.WriteLine("Duration (Hours): " + _hours);
            Console.WriteLine("Amount: RM" + _amount);
            Console.WriteLine();
        }
    }
}