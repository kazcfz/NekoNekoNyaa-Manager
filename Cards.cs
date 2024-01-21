using System;
using System.Collections.Generic;

namespace PassTask3{
    /// <summary>
    /// This is a Cards class which contains 6 fields
    /// </summary>
    public class Cards{
        private string _name;
        private int _seriesno;
        private string _rarity;
        private string _colour;
        private CardType _type;
        private int _quantity;

        /// <summary>
        /// This is a default constructor which sets their respective values from the field and parameter.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="seriesno"></param>
        /// <param name="rarity"></param>
        /// <param name="colour"></param>
        /// <param name="type"></param>
        /// <param name="quantity"></param>
        public Cards(string name, int seriesno, string rarity, string colour, CardType type, int quantity){
            _name = name;
            _seriesno = seriesno;
            _rarity = rarity;
            _colour = colour;
            _type = type;
            _quantity = quantity;
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
        /// This is a property for SeriesNo that set and get the value of the SeriesNo
        /// </summary>
        /// <value></value>
        public int SeriesNo{
            get{return _seriesno;}
            set{_seriesno = value;}
        }


        /// <summary>
        /// This is a property for Rarity that set and get the value of the Rarity
        /// </summary>
        /// <value></value>
        public string Rarity{
            get{return _rarity;}
            set{_rarity = value;}
        }


        /// <summary>
        /// This is a property for Colour that set and get the value of the Colour
        /// </summary>
        /// <value></value>
        public string Colour{
            get{return _colour;}
            set{_colour = value;}
        }

        /// <summary>
        /// This is a property for Type that set and get the value of the CardType
        /// </summary>
        /// <value></value>
        public CardType Type{
            get{return _type;}
            set{_type = value;}
        }

        /// <summary>
        /// This is a property for Quantity that set and get the value of the Quantity
        /// </summary>
        /// <value></value>
        public int Quantity{
            get{return _quantity;}
            set{_quantity = value;}
        }


        /// <summary>
        /// This is a method that displays the details of the cards
        /// </summary>
        public void PrintDetails(){
            Console.WriteLine();
            Console.WriteLine("Name: " + _name);
            Console.WriteLine("Series Number: " + _seriesno);
            Console.WriteLine("Rarity: " + _rarity);
            Console.WriteLine("Colour: " + _colour);
            Console.WriteLine("Type: " + _type);
            Console.WriteLine("Quantity: " + _quantity);
            Console.WriteLine();
        }
    }
}