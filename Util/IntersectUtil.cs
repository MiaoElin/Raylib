using System.Numerics;
using Raylib_cs;

public static class IntersectUtil
{

    public static bool IsCircleIntersect(Vector2 p1, float r1, Vector2 p2, float r2)
    {

        float a = (r1 + r2) * (r1 + r2);
        float b = Vector2.DistanceSquared(p1, p2);
        /* if(b>a){
             return false;
         }else{
             return true;
         }*/
        return b <= a;

    }

    // 这里
    public static bool IsPointInsideRect(Vector2 point, Vector2 leftTop, Vector2 rightBottom) {
        if (point.X >= leftTop.X && point.X <= rightBottom.X && point.Y >= leftTop.Y && point.Y <= rightBottom.Y) {
            return true;
        } else {
            return false;
        }
    }
}