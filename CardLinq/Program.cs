namespace CardLinq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var deck = new Deck()
                .Shuffle()
                .Take(16);

            IOrderedEnumerable<IGrouping<Suits, Card>> gropead = NewMethod(deck);
            
            foreach (var group in gropead)
            {
                Console.WriteLine(@$"Group: {group.Key}
                Count: {group.Count()}
                Minimum: {group.Min()}
                Maximum: {group.Max()}");
            }
        }

        private static IOrderedEnumerable<IGrouping<Suits, Card>> NewMethod(IEnumerable<Card> deck)
        {
            return from card in deck
                   group card by card.Suit into suitGroup
                   orderby suitGroup.Key descending
                   select suitGroup;
        }
    }
}