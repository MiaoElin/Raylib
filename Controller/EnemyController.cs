using System.Numerics;
using Raylib_cs;

public static class EnemyController
{

    public static void LogicTick(ref Context con, float dt)
    {
        ref PlaneEntity plane = ref con.plane;

        PlaneEntity[] enemies = con.enemies;
        ref int enemyCount = ref con.enemyCount;

        //敌人 生成
        ref float enemySpawnTimer = ref con.enemySpawnTimer;
        enemySpawnTimer -= dt;
        if (enemySpawnTimer <= 0)
        {
            enemySpawnTimer = con.enemySpwanInterval;
            PlaneEntity newEnemy = Factory.CreatePlane(RandomUtil.GetRandomPosOnEdge(800, 480), Color.RED, 20, 30, 10);
            enemies[enemyCount] = newEnemy;
            enemyCount++;
        }

        //敌人 行为
        //遍历每架飞机，移动每架飞机,如果敌人碰到我机，我机血槽-10
        for (int i = 0; i < enemyCount; i++)
        {
            ref PlaneEntity ene = ref enemies[i];
            Vector2 dir = plane.pos - ene.pos;

            // - 移动
            ene.Move(dir, dt);

            // - 碰撞检测
            if (IntersectUtil.IsCircleIntersect(plane.pos, plane.radius, ene.pos, ene.radius))
            {
                if (plane.invincibleTimer <= 0)
                {
                    plane.invincibleTimer = plane.invincibleInterval;
                    plane.hp -= 10;
                    if (plane.hp <= 0)
                    {
                        plane.isDead = true;
                    }
                }
            }
        }

        // 销毁的遍历，要用倒序；
        // 移除
        for (int i = enemyCount - 1; i >= 0; i--)
        {
            if (enemies[i].isDead)
            {
                RemoveEnemy(enemyCount, i, enemies[i], enemies);
                enemyCount -= 1;
            }
        }

    }

    public static void DrawAll(ref Context ctx)
    {
        int enemyCount = ctx.enemyCount;
        PlaneEntity[] enemies = ctx.enemies;
        for (int i = 0; i < enemyCount; i++)
        {
            // 画不会改变enemies[],所以用完不用再覆盖回去
            var cur = enemies[i];
            cur.Draw();
        }
    }

    static void RemoveEnemy(int existCount, int nearlyEnemyIndex, PlaneEntity nearlyEnemy, PlaneEntity[] enemies)
    {
        enemies[nearlyEnemyIndex] = enemies[existCount - 1];
        enemies[existCount - 1] = nearlyEnemy;
    }
}