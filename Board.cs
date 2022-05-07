using System.Text;

namespace TicTacToe
{
    public class Board : IBoard
    {
        private Symbol[,] board;

        public Board(int rows = 3, int columns = 3)
        {
            if (rows != columns)
            {
                throw new ArgumentException("Rows and Columns should be equal!");
            }

            this.TotalRows = rows;
            this.TotalColumns = columns;

            board = new Symbol[TotalRows, TotalColumns];
        }

        public int TotalRows { get; }
        public int TotalColumns { get; }
        public Symbol[,] BoardState => this.board;

        public bool IsFull()
        {
            for (int row = 0; row < TotalRows; row++)
            {
                for (int column = 0; column < TotalColumns; column++)
                {
                    if (board[row, column] == Symbol.None)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public void PlaceSymbol(Index index, Symbol symbol)
        {
            if (index.Row < 0 || index.Row >= this.TotalRows || index.Column < 0 || index.Column >= this.TotalColumns)
            {
                throw new IndexOutOfRangeException("Invalid index!");
            }

            board[index.Row, index.Column] = symbol;
        }

        public IEnumerable<Index> GetEmptyPositions()
        {
            var emptyPositions = new List<Index>();
            for (int row = 0; row < TotalRows; row++)
            {
                for (int col = 0; col < TotalColumns; col++)
                {
                    if (board[row, col] == Symbol.None)
                    {
                        emptyPositions.Add(new Index(row, col));
                    }
                }
            }

            return emptyPositions;
        }

        public Symbol GetRowSymbols(int currentRow)
        {
            Symbol winnerSymbol = board[currentRow, 0];
            if (winnerSymbol == Symbol.None)
            {
                return Symbol.None;
            }

            for (int col = 1; col < TotalColumns; col++)
            {
                if (board[currentRow, col] != winnerSymbol)
                {
                    return Symbol.None;
                }
            }

            return winnerSymbol;
        }

        public Symbol GetColmunSymbols(int currentCol)
        {
            Symbol winnerSymbol = board[0, currentCol];
            if (winnerSymbol == Symbol.None)
            {
                return Symbol.None;
            }

            for (int row = 1; row < TotalRows; row++)
            {
                if (board[row, currentCol] != winnerSymbol)
                {
                    return Symbol.None;
                }
            }

            return winnerSymbol;
        }

        public Symbol GetPrimaryDiagonalSymbols()
        {
            Symbol winnerSymbol = board[0, 0];
            if (winnerSymbol == Symbol.None)
            {
                return Symbol.None;
            }

            for (int row = 0; row < TotalRows; row++)
            {
                if (board[row, row] != winnerSymbol)
                {
                    return Symbol.None;
                }
            }

            return winnerSymbol;
        }

        public Symbol GetSecondDiagonalSymbols()
        {
            Symbol winnerSymbol = board[0, TotalColumns - 1];
            if (winnerSymbol == Symbol.None)
            {
                return Symbol.None;
            }

            for (int row = 1; row < TotalRows; row++)
            {
                if (board[row, TotalRows - row - 1] != winnerSymbol)
                {
                    return Symbol.None;
                }
            }

            return winnerSymbol;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            for (int row = 0; row < TotalRows; row++)
            {
                for (int col = 0; col < TotalColumns; col++)
                {
                    if (board[row, col] == Symbol.None)
                    {
                        builder.Append('.');
                        continue;
                    }

                    builder.Append(board[row, col]);
                }

                builder.AppendLine();
            }

            return builder.ToString();
        }
    }
}