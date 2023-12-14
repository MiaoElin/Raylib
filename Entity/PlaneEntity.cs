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
    public float invincibleTimer;
    public float invincibleInterval;

    public void Move(Vector2 dir, float dt)
    {
        pos += Raymath.Vector2Normalize(dir) * moveSpeed * dt;

    }

    public void Draw()
    {
        Raylib.DrawCircleV(pos, radius, color);
    }
}