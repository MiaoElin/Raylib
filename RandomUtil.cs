using System.Numerics;
using Raylib_cs;
public static class RandomUtil
{
    public static Vector2 GetRandomPosOnEdge(int width, int height)
    {
        int x = 0;
        int y = 0;
        Random r = new Random();
        int a = r.Next(0, 3);//0上，1下，2左，3右
        if (a == 0)
        {
            y = 0;
            x = r.Next(0, width);
        }
        if (a == 1)
        {
            y = height;
            x = r.Next(0, width);
        }
        if (a == 2)
        {
            x = 0;
            y = r.Next(0, height);
        }
        if (a == 3)
        {
            x = width;
            y = r.Next(0, height);
        }
        
        Vector2 pos = new Vector2(x,y);
        return pos;
        //return new Vector2(x,y);
    }
}