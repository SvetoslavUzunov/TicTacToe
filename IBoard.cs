namespace TicTacToe;

public interface IBoard
{
    bool IsFull();
    void PlaceSymbol(Index index, Symbol symbol);
    IEnumerable<Index> GetEmptyPositions();
    Symbol GetRowSymbols(int currentRow);
    Symbol GetColmunSymbols(int currentCol);
    Symbol GetPrimaryDiagonalSymbols();
    Symbol GetSecondDiagonalSymbols();
}