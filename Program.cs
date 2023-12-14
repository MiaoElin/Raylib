using Raylib_cs;
using System.Numerics;
public class Program
{
    public static void Main()
    {
        Raylib.InitWindow(800, 480, "Hello World!");
        Raylib.SetTargetFPS(60);

        //声明我方飞机
        PlaneEntity plane = PlaneEntity.CreatePlane(new(400, 240), Color.BLUE, 20, 50, 100);

        //声明敌人s
        PlaneEntity[] enemies = new PlaneEntity[200000];
        float timeSpawnInterval = 2f;
        float timeSpawnTimer = timeSpawnInterval;
        int enemyCount = 0;
        PlaneEntity nearlyEnemy;
        int nearlyEnemyIndex;


        //声明子弹
        BulletEntity[] bullets = new BulletEntity[200000];
        int bulletCount = 0;


        //声明玩家输入
        InputEntity input;
        input.moveAxis = Vector2.Zero;

        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.WHITE);
            float deltaTime = Raylib.GetFrameTime();

            //玩家输入
            input.Process();

            //我机 移动
            plane.Move(input.moveAxis, deltaTime);

            //敌人 生成
            timeSpawnTimer -= deltaTime;
            if (timeSpawnTimer <= 0)
            {
                timeSpawnTimer =timeSpawnInterval;
                PlaneEntity newEnemy = PlaneEntity.CreatePlane(RandomUtil.GetRandomPosOnEdge(800, 480), Color.RED, 20, 30, 10);
                enemies[enemyCount] = newEnemy;
                enemyCount++;
            }
            //子弹 生成
            if (input.isShootProcess())
            {
                BulletEntity newBullet = BulletEntity.CreatePlane(plane.pos, Color.GREEN, 5, 80);
                bullets[bulletCount] = newBullet;
                bulletCount++;
            }

            //敌人 移动
            //遍历每架飞机，移动每架飞机,如果敌人碰到我机，我机血槽-10
            for (int i = 0; i < enemyCount; i++)
            {
                var cur = enemies[i];
                Vector2 dir = plane.pos - cur.pos;
                cur.Move(dir, deltaTime);

                if (Intersect.IsCircleIntersect(plane.pos, plane.radius, cur.pos, cur.radius))
                {
                    plane.hp -= 10;
                    if (plane.hp == 0)
                    {
                        plane.isDead = true;
                    }
                }
                enemies[i] = cur;
            }

            //子弹 移动
            // 1.找到最近的敌人
            nearlyEnemy = Find.FindNearEnemy(plane.pos, enemies, enemyCount, out nearlyEnemyIndex);
            // 2.子弹移向敌人(通过遍历的方式 从第一颗子弹开始发射)
            for (int i = 0; i < bulletCount; i++)
            {
                var cur = bullets[i];
                Vector2 dir = nearlyEnemy.pos - cur.pos;
                cur.Move(dir, deltaTime);

                // 3.如果子弹敌人相撞，敌人子弹移除
                if (Intersect.IsCircleIntersect(nearlyEnemy.pos, nearlyEnemy.radius, cur.pos, cur.radius))
                {

                    //敌人移除
                    RemoveUtil.RemoveEnemy(enemyCount, nearlyEnemyIndex, nearlyEnemy, enemies);
                    enemyCount -= 1;

                    //子弹移除
                    RemoveUtil.RemoveBullet(bulletCount, i, cur, bullets);
                    bulletCount -= 1;
                }
                bullets[i] = cur;

            }

            //我机 绘制
            if(!plane.isDead){
                plane.Draw(plane.color);
            }
                
            //敌人 绘制
            for (int i = 0; i < enemyCount; i++)
            {
                var cur = enemies[i];
                cur.Draw(enemies[i].color);
            }
            //子弹 绘制
            for(int i =0;i<bulletCount;i++){
                var cur = bullets[i];
                bullets[i].Draw();
            }
            Raylib.EndDrawing();


        }
        Raylib.CloseWindow();
    }
}