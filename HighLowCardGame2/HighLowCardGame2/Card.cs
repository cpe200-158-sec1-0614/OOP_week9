using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighLowCardGame2
{
    class Card
    {

        private int _value;
        private int _suit;
        private string[] _namesuit = { "Spade", "Heart", "Dimond", "Club" };
        private string[] _namecard = { "A", "J", "Q", "K" };

        public Card(int v, int s)
        {
            _value = v;
            _suit = s;
        }
        public int Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }

        }
        public int Suit
        {
            get
            {
                return _suit;
            }
            set
            {
                _suit = value;
            }
        }

        public void PrintCard()
        {
            Console.WriteLine(_value + " " + _suit);
        }

        public string GetNameSuit()
        {
            string ncard = "";
            if (_value == 1) { ncard = _namecard[0]; }
            else if (_value == 11) { ncard = _namecard[1]; }
            else if (_value == 12) { ncard = _namecard[2]; }
            else if (_value == 13) { ncard = _namecard[3]; }
            else { ncard = _value.ToString(); }
            return ncard + " of " + _namesuit[_suit - 1];
        }

    }
}
