namespace TicTacToe;

public class GameWinnerLogic
{
    public bool GameOver(Board board)
    {
        for (int row = 0; row < board.TotalRows; row++)
        {
            if (board.GetRowSymbols(row) != Symbol.None)
            {
                return true;
            }
        }

        for (int col = 0; col < board.TotalColumns; col++)
        {
            if (board.GetColmunSymbols(col) != Symbol.None)
            {
                return true;
            }
        }

        if (board.GetPrimaryDiagonalSymbols() != Symbol.None)
        {
            return true;
        }

        if (board.GetSecondDiagonalSymbols() != Symbol.None)
        {
            return true;
        }

        return board.IsFull();
    }

    public Symbol GetWinner(Board board)
    {
        Symbol winnerSymbol;
        for (int row = 0; row < board.TotalRows; row++)
        {
            winnerSymbol = board.GetRowSymbols(row);
            if (winnerSymbol != Symbol.None)
            {
                return winnerSymbol;
            }
        }

        for (int col = 0; col < board.TotalColumns; col++)
        {
            winnerSymbol = board.GetColmunSymbols(col);
            if (winnerSymbol != Symbol.None)
            {
                return winnerSymbol;
            }
        }

        winnerSymbol = board.GetPrimaryDiagonalSymbols();
        if (winnerSymbol != Symbol.None)
        {
            return winnerSymbol;
        }

        winnerSymbol = board.GetSecondDiagonalSymbols();
        if (winnerSymbol != Symbol.None)
        {
            return winnerSymbol;
        }

        return Symbol.None;
    }
}