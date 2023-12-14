using Raylib_cs;
using System.Numerics;
public struct PlaneEntity
{
    public Vector2 pos;
    public Color color;
    public float radius;
    public float moveSpeed;
    public bool isDead;
    public int hp;
    public void Move(Vector2 dir, float dt)
    {
        pos += Raymath.Vector2Normalize(dir) * moveSpeed * dt;

    }
    public static PlaneEntity CreatePlane(Vector2 pos, Color color, float radius, float moveSpeed, int hp)
    {
        PlaneEntity plane;
        plane.color = color;
        plane.radius = radius;
        plane.pos = pos;
        plane.moveSpeed = moveSpeed;
        plane.isDead = false;
        plane.hp = hp;
        return plane;
    }
    public void Draw(Color color)
    {
        Raylib.DrawCircleV(pos, radius, color);
    }
}