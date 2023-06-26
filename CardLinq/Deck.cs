﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardLinq
{
    class Deck: ObservableCollection<Card>
    {
        private static Random random = new Random();
        public Deck()
        {
            Reset();
        }
        public void Reset()
        {
            Clear();
            for (int suit = 0; suit < 4; suit++)
            {
                for (int value = 0; value < 13; value++)
                {
                    Add(new Card((Values)value,(Suits)suit));
                }
            }
        }
        public Card Deal(int index)
        {
            Card cardToDeal = base[index];
            RemoveAt(index);
            return cardToDeal;
        }
        /// <summary>
        /// перетасовка доски, возвращает ссылку на тот же обьект desc
        /// </summary>
        /// <returns></returns>
        public Deck Shuffle()
        {
            List<Card> copy = new List<Card>(this);
            Clear();
            while (copy.Count > 0)
            {
                int index = random.Next(copy.Count);
                Card card = copy[index];
                copy.RemoveAt(index);
                Add(card);
            }
            return this;
        }
        public void Sort()
        {
            List<Card> sortedCards = new List<Card>(this);
            sortedCards.Sort(new CardComparerByValue());
            Clear();
            foreach (Card card in sortedCards)
            {
                Add(card);
            }
        }
    }
}
