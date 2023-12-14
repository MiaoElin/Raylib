using System.Numerics;
using Raylib_cs;

public struct BulletEntity
{
    public float radius;
    public float moveSpeed;
    public Color color;
    public Vector2 pos;
    public bool isDead;
    public Vector2 flyDir;

    public void Move(Vector2 dir, float dt)
    {
        pos += Raymath.Vector2Normalize(dir) * dt * moveSpeed;
        flyDir = dir;
    }

    public void MoveByLastDir(float dt)
    {
        pos += Raymath.Vector2Normalize(flyDir) * dt * moveSpeed;
    }

    public void Draw()
    {
        Raylib.DrawCircleV(pos, radius, color);
    }

}