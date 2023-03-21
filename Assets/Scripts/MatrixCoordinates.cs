using System;
public struct MatrixCoordinates
{
    public int X { get; private set; }
    public int Y { get; private set; }

    public MatrixCoordinates(int x, int y)
    {
        X = x;
        Y = y;
    }
}

