using Raylib_cs;
using System.Numerics;
public class Program
{
    public static void Main()
    {
        Raylib.InitWindow(800, 480, "Hello World!");
        Raylib.SetTargetFPS(60); // 1/60 0.01667s

        Context con = new Context();
        con.Initialize();

        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.WHITE);
            float deltaTime = Raylib.GetFrameTime();

            // 玩家输入
            PlayerController.ProcessInput(ref con);

            // 我机: 行为
            PlayerController.LogicTick(ref con, deltaTime);

            // 敌机: 行为
            EnemyController.LogicTick(ref con, deltaTime);

            // 子弹: 行为
            BulletController.LogicTick(ref con, deltaTime);

            // 我机 绘制
            PlayerController.DrawAll(ref con);

            // 敌人 绘制
            EnemyController.DrawAll(ref con);

            // 子弹 绘制
            BulletController.DrawAll(ref con);

            Raylib.EndDrawing();

        }
        Raylib.CloseWindow();
    }
}