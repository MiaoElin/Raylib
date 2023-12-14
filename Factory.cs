using System.Numerics;
using Raylib_cs;

public static class Factory
{

    public static PlaneEntity CreatePlane(Vector2 pos, Color color, float radius, float moveSpeed, int hp)
    {
        PlaneEntity plane;
        plane.color = color;
        plane.radius = radius;
        plane.pos = pos;
        plane.moveSpeed = moveSpeed;
        plane.isDead = false;
        plane.hp = hp;
        plane.invincibleInterval = 1f;
        plane.invincibleTimer = plane.invincibleInterval;
        return plane;
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

}