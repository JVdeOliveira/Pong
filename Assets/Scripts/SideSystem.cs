﻿
public class SideSystem
{
    public static Side GetSide(float xPosition)
    {
        bool isRight = xPosition > 0;
        return isRight ? Side.Right : Side.Left;
    }
}
