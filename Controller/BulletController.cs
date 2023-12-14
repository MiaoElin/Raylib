using System.Numerics;
using Raylib_cs;

public static class BulletController
{

    public static void LogicTick(ref Context ctx, float dt)
    {
        ref InputEntity input = ref ctx.input;
        ref PlaneEntity plane = ref ctx.plane;
        ref BulletEntity[] bullets = ref ctx.bullets;
        ref PlaneEntity[] enemies = ref ctx.enemies;
        ref int enemyCount = ref ctx.enemyCount;
        ref int bulletCount = ref ctx.bulletCount;

        //子弹 生成
        if (input.isShootProcess())
        {
            BulletEntity newBullet = Factory.CreatePlane(plane.pos, Color.GREEN, 5, 80);
            bullets[bulletCount] = newBullet;
            bulletCount++;
        }

        //子弹 移动(通过遍历的方式 从第一颗子弹开始发射)
        for (int i = 0; i < bulletCount; i++)
        {
            // 1.找到最近的敌人
            ref var bul = ref bullets[i];
            int nearlyEnemyIndex;
            PlaneEntity nearlyEnemy = FindUtil.FindNearEnemy(bul.pos, enemies, enemyCount, out nearlyEnemyIndex);
            if (nearlyEnemyIndex != -1)
            {
                // 2.子弹移向敌人
                Vector2 dir = nearlyEnemy.pos - bul.pos;
                bul.Move(dir, dt);

                // 3.如果子弹敌人相撞，敌人子弹移除
                if (IntersectUtil.IsCircleIntersect(nearlyEnemy.pos, nearlyEnemy.radius, bul.pos, bul.radius))
                {

                    enemies[nearlyEnemyIndex].isDead = true;
                    bul.isDead = true;

                }
            }
            else
            {
                // todo 子弹继续朝原始方向移动
                bul.MoveByLastDir(dt);

            }

        }

        // 销毁的遍历，要用倒序；
        // 子弹移除
        for (int i = bulletCount - 1; i >= 0; i--)
        {
            if (bullets[i].isDead)
            {
                RemoveBullet(bulletCount, i, bullets[i], bullets);
                bulletCount -= 1;
            }
        }

    }

    public static void DrawAll(ref Context ctx)
    {
        int bulletCount = ctx.bulletCount;
        BulletEntity[] bullets = ctx.bullets;
        for (int i = 0; i < bulletCount; i++)
        {
            var cur = bullets[i];
            bullets[i].Draw();
        }
    }

    static void RemoveBullet(int bulletCount, int bulletIndex, BulletEntity bullet, BulletEntity[] bullets)
    {
        bullets[bulletIndex] = bullets[bulletCount - 1];
        bullets[bulletCount - 1] = bullet;
    }
}