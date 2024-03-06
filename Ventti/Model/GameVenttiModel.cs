namespace Ventti.Model
{
    public class GameVenttiModel : IModel
    {
        private Deck _deck = new Deck();
        private Player _player = new Player("You");
        private Player _dealer = new Player("Dealer");
        public Player Player => _player;
        public Player Dealer => _dealer;
        public Deck Deck => _deck;

        
        public Card DealCard(Player inAction)
        {
            Card drawnCard = Deck.DealTopCard();
            inAction.GetCard(drawnCard);
            CountHandValue(inAction);   
            return drawnCard;
        }

        private void CountHandValue(Player inAction)
        {
            int total = 0;
            inAction.Hand.Sort((kortti1,kortti2)=>kortti1.Value.CompareTo(kortti2.Value));
            inAction.Hand.Reverse();
            foreach (Card card in inAction.Hand)
            {
                int value = GetCardValue(card);
                total += value;
            }
            inAction.HandValue = total;
            if (inAction.HandValue > 21)
            {
                inAction.Busted = true;
            }
            
        }

        private int GetCardValue(Card card)
        {
            if (card.Value == 1)
            {
                return 11;
            }
            else if (card.Value > 9 && card.Value < 14)
            {
                return 10;
            }
            else
            {
                return card.Value;
            }
        }

        public string CheckWinner()
        {
            string winner = "";

            if (Dealer.HandValue >= Player.HandValue && !Dealer.Busted)
            {
                winner = Dealer.Name;
            }
            else if (!Player.Busted)
            {
                winner = Player.Name;
            }
        
            return winner;
        }

        public void ResetGame()
        {
            Deck.CollectHand(Player.Hand);
            Player.Init();
            
            Deck.CollectHand(Dealer.Hand);
            Dealer.Init();
        }

 

    }
}


