namespace TicTacToe;

public class GameResult
{
    public GameResult(Symbol winner, Board board)
    {
        this.Winner = winner;
        this.Board = board;
    }

    public Symbol Winner { get; }
    public Board Board { get; }
}
