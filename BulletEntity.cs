using System.Numerics;
using Raylib_cs;
public struct BulletEntity
{
    public float radius;
    public float moveSpeed;
    public Color color;
    public Vector2 pos;
    public void Move(Vector2 dir, float dt)
    {
        pos += Raymath.Vector2Normalize(dir) * dt * moveSpeed;
    }
    public static BulletEntity CreatePlane(Vector2 pos, Color color, float radius, float moveSpeed)
    {
        BulletEntity bullet;
        bullet.color = color;
        bullet.radius = radius;
        bullet.pos = pos;
        bullet.moveSpeed = moveSpeed;
        return bullet;
    }
    public void Draw(){
        Raylib.DrawCircleV(pos,radius,color);
    }

}