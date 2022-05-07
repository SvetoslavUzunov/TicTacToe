using TicTacToe.Players;

namespace TicTacToe;

public class Game
{
    public Game(IPlayer firstPlayer, IPlayer secondPlayer)
    {
        this.FirstPlayer = firstPlayer;
        this.SecondPLayer = secondPlayer;
        this.WinnerLogic = new GameWinnerLogic();
    }

    public IPlayer FirstPlayer { get; }
    public IPlayer SecondPLayer { get; }
    public GameWinnerLogic WinnerLogic { get; }

    public GameResult Play()
    {
        Board board = new Board();
        IPlayer currentPlayer = FirstPlayer;
        Symbol symbol = Symbol.X;

        while (!WinnerLogic.GameOver(board))
        {
            Index move = currentPlayer.Play(board, symbol);
            board.PlaceSymbol(move, symbol);

            if (currentPlayer == FirstPlayer)
            {
                currentPlayer = SecondPLayer;
                symbol = Symbol.O;
            }
            else
            {
                currentPlayer = FirstPlayer;
                symbol = Symbol.X;
            }
        }

        Symbol winner = WinnerLogic.GetWinner(board);

        return new GameResult(winner, board);
    }


}