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
    public static BulletEntity CreatePlane(Vector2 pos, Color color, float radius, float moveSpeed)
    {
        BulletEntity bullet;
        bullet.color = color;
        bullet.radius = radius;
        bullet.pos = pos;
        bullet.moveSpeed = moveSpeed;
        bullet.isDead = false;
        // 坐标的初始值设置为（0,0），其他值是输入的
        bullet.flyDir = Vector2.Zero;
        return bullet;
    }
    public void Draw(){
        Raylib.DrawCircleV(pos,radius,color);
    }

}