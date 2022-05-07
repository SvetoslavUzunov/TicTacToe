namespace TicTacToe;

public class Index
{
    public Index(int row, int column)
    {
        this.Row = row;
        this.Column = column;
    }

    public Index(string input)
    {
        string[] parts = input.Split(',');
        this.Row = int.Parse(parts[0]);
        this.Column = int.Parse(parts[1]);
    }

    public int Row { get; set; }
    public int Column { get; set; }

    public override string ToString()
    {
        return $"{Row},{Column}";
    }

    public override bool Equals(object? obj)
    {
        var otherIndex = obj as Index;

        return Row == otherIndex.Row && Column == otherIndex.Column;
    }
}
