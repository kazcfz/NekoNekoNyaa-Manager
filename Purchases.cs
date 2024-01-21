using System;
using System.Collections.Generic;

namespace PassTask3{

    /// <summary>
    /// This is a Purchases class which contains 5 fields
    /// </summary>
    public class Purchases{
        private int _transNo;
        private string _date;
        private int _amount;
        private List<Cards> _cards;
        private Customer _customer;

        /// <summary>
        /// This is a default constructor which sets their respective values from the field and parameter. The Cards list was also set.
        /// </summary>
        public Purchases(int transNo, string date, int amount, Customer customer){
            _transNo = transNo;
            _date = date;
            _amount = amount;
            _cards = new List<Cards>();
            _customer = customer;
        }

        /// <summary>
        /// This is a property for TransNo that set and get the value of the Transaction Number
        /// </summary>
        /// <value></value>
        public int TransNo{
            get{return _transNo;}
            set{_transNo = value;}
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
        /// This is a property for Cards List that get the list of _cards
        /// </summary>
        /// <value></value>
        public List<Cards> Cards{
            get{ return _cards; }
        }

        /// <summary>
        /// This is a property for Customer that set and get the values of the Customer
        /// </summary>
        /// <value></value>
        public Customer Customer{
            get{return _customer;}
            set{_customer = value;}
        }
    }
}