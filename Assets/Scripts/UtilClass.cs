

public static class UtilClass
{
    public static Side GetSide(float xPosition)
    {
        bool isRight = xPosition > 0;
        return isRight ? Side.Right : Side.Left;
    }
}

public enum Side
{
    Left,
    Right
}

