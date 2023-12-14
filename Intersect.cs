using System.Numerics;
using Raylib_cs;
public static class Intersect{

    public static bool IsCircleIntersect(Vector2 p1, float r1,Vector2 p2, float r2){

        float a = (r1 +r2)*(r1 +r2);
        float b = Vector2.DistanceSquared(p1,p2);
       /* if(b>a){
            return false;
        }else{
            return true;
        }*/
        return b<=a;

    }
} 