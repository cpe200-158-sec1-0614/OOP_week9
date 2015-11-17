using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighLowCardGame2
{
    class Player
    {
        private List<Card> _pile;
        private string _name;
        private int _count;
        private Card _OnHand;

        public Card OnHand
        {
            get { return _OnHand; }
        }

        public Player(string name, int i, Deck D)
        {
            _name = name;
            _pile = new List<Card>(26);

            for (int j = 0; j < 26; j++, i++)
            {
                _pile.Add(D.ADeck[i]);
            }
            
        }

        public List<Card> Pile
        {
            get { return _pile; }
        }

        public string Name
        {
            get { return _name; }
        }

        public int Count //"Score"
        {
            get { return _count; }
        }

        public void PrintPile()
        {
            for (int i = 0; i < _pile.Count; i++)
            {
                Console.WriteLine(_pile[i].Value + " " + _pile[i].Suit);
            }
        }

        public void Dealing(int Deal = 1)
        {
            _OnHand = Pile[Deal - 1];

            Console.Write(_name + ": " + _OnHand.GetNameSuit() + "\t");
        }

        public void Take(int Deal = 1)
        {
            _count += Deal * 2;
        }

        public void Remove(int Deal = 1)
        {
            _pile.RemoveRange(0, Deal);
        }

        public void Shuffle()
        {
            int size = _pile.Count;
            for (int i = 0; i < size; i++)
            {
                Random r = new Random(Guid.NewGuid().GetHashCode());
                int a = r.Next(0, size);
                Card c = _pile[a];
                _pile[a] = _pile[i];
                _pile[i] = c;
            }
        }
    }
}



