using Ventti.Model;
using Ventti.View;

namespace Ventti.Presenter
{
    public class VenttiPresenter : IPresenter
    {
        private readonly IView _view;
        private readonly IModel _ventti;

        public VenttiPresenter(IView view, IModel model)
        {
            _view = view;
            _ventti = model;
        }

        public void PlayGame()
        {
            _ventti.Player.Lost += Player_Lost;
            _ventti.Dealer.Lost += Player_Lost;
            do
            {
                _view.DisplayWelcomeMessage();
                _view.DisplayDealingCardsMessage();
                _ventti.Deck.Suffle();       
                PlayerTurn();        
                DealerTurn();
                CheckWinner();
                _ventti.ResetGame();
                Console.Write("Play again (y/n)?");
            }while(Console.ReadKey().KeyChar.ToString().ToLower() != "n");
         
        }

        private void Player_Lost(object sender, EventArgs e)
        {
            Console.WriteLine("---------Event!--------");
            Player lostPlayer = sender as Player;
            _view.DisplayBustedMessage(lostPlayer.Name);          
        }

        private void DealerTurn()
        {
            DealCardToPlayer(_ventti.Dealer);
            while (_ventti.Dealer.HandValue < 17 && !_ventti.Player.Busted && !_ventti.Dealer.Busted)
            {
                DealCardToPlayer(_ventti.Dealer);
            }
        }

        private void PlayerTurn()
        {
            //First two cards
            for (int i = 0; i < 2; i++)
            {
                DealCardToPlayer(_ventti.Player);
            }
            _view.AskForHitOrStay();
            string hitOrStay = _view.GetHitOrStayInput();
            while (hitOrStay == "h" && !_ventti.Player.Busted)
            {
                DealCardToPlayer(_ventti.Player);
                if (!_ventti.Player.Busted)
                {
                    _view.AskForHitOrStay();
                    hitOrStay = _view.GetHitOrStayInput();
                }              
            }
        }

        private void CheckWinner()
        {
            _view.DisplayFinalTotals(_ventti.Player.HandValue, _ventti.Dealer.HandValue);
            string winner = _ventti.CheckWinner();
            _view.DisplayWinnerMessage(winner);
        }
        private void DealCardToPlayer(Player currentPlayer)
        {
            Card playerCard = _ventti.DealCard(currentPlayer);
            _view.DisplayCard(playerCard.ToString(), currentPlayer.Name); 
            _view.DisplayTotal(currentPlayer.HandValue, currentPlayer.Name);
        }


    }
}


