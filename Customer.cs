using System;
using System.Collections.Generic;

namespace PassTask3{
    /// <summary>
    /// This is a Customer class which contains 7 fields
    /// </summary>
    public class Customer{
        private int _no;
        private string _name;
        private Membership _status;
        private List<Purchases> _purchases;
        private List<Booking> _booking;
        private int _totalpurchase;
        private int _points;

        /// <summary>
        /// This is a default constructor which sets their respective values from the field and parameter. The Purchases and Booking lists were also set
        /// </summary>
        public Customer(int no, string name, Membership status, int totalpurchase){
            _no = no;
            _name = name;
            _status = status;
            _totalpurchase = totalpurchase;
            _purchases = new List<Purchases>();
            _booking = new List<Booking>();
        }

        /// <summary>
        /// This is a property for No that set and get the value of the Number
        /// </summary>
        /// <value></value>
        public int No{
            get{return _no;}
            set{_no = value;}
        }


        /// <summary>
        /// This is a property for Name that set and get the value of the Name
        /// </summary>
        /// <value></value>
        public string Name{
            get{return _name;}
            set{_name = value;}
        }


        /// <summary>
        /// This is a property for Status that set and get the value of the Status
        /// </summary>
        /// <value></value>
        public Membership Status{
            get{return _status;}
            set{_status = value;}
        }

        /// <summary>
        /// This is a property for Purchases List that get the list of _purchases
        /// </summary>
        /// <value></value>
        public List<Purchases> Purchases{
            get{ return _purchases; }
        }


        /// <summary>
        /// This is a property for Booking List that get the list of _booking
        /// </summary>
        /// <value></value>
        public List<Booking> Booking{
            get{ return _booking; }
        }

        /// <summary>
        /// This is a property for TotalPurchase that set and get the value of the TotalPurchase
        /// </summary>
        /// <value></value>
        public int TotalPurchase{
            get{return _totalpurchase;}
            set{_totalpurchase = value;}
        }

        /// <summary>
        /// This is a property for Points that set and get the value of the Points
        /// </summary>
        /// <value></value>
        public int Points{
            get{return _points;}
            set{_points = value;}
        }

        /// <summary>
        /// This is a method that updates the total purchase amount with other purchases besides booking
        /// </summary>
        /// <param name="purchases"></param>
        public void UpdateTotalPurchase(Purchases purchases){
                _totalpurchase += purchases.Amount;
        }

        /// <summary>
        /// This is an indexer for Purchases which can be accessed like an array
        /// </summary>
        /// <value></value>
        public Purchases this[int i]{
            get{ return _purchases[i]; }
        }

        /// <summary>
        /// This is a method that updates points according to the value of the total purchase made
        /// </summary>
        public void UpdatePoints(){
            if (_status == Membership.Member){
                for (int i=0; i<_totalpurchase; i=i+20){
                    if (i % 20 == 0){
                    _points += 10;
                    }
                }
            }
        }
    }
}