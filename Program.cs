using System.Numerics;
using Raylib_cs;

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

            // ==== 行为 ====
            if (con.gameStatus == 0) {
                Login_Tick(ref con, deltaTime);
            } else if (con.gameStatus == 1) {
                Game_Tick(ref con, deltaTime);
            } else if (con.gameStatus == 2) {

            } else {
                
            }

            // ==== 绘制 ====
            if (con.gameStatus == 0) {
                Login_Draw(ref con);
            } else if (con.gameStatus == 1) {
                Game_Draw(ref con);
            } else if (con.gameStatus == 2) {

            }

            Raylib.EndDrawing();

        }
        Raylib.CloseWindow();
    }

    // ==== 登录页 ====
    static void Login_Tick(ref Context con, float dt) {
        ref InputEntity input = ref con.input;
        ref GUIButton btnRect = ref con.btn_login_startGame; // 这里的问题
        // 判断点击
        if (btnRect.IsMouseInside(input.mousePos)) {
            if (input.isMouseClick) {
                con.gameStatus = 1; // 进入游戏
            }
        }
    }

    static void Login_Draw(ref Context con) {
        // 按钮
        GUIButton btnRect = con.btn_login_startGame;
        btnRect.Draw();
    }

    // ==== 游戏中 ====
    static void Game_Tick(ref Context con, float dt) {
        // 我机: 行为
        PlayerController.LogicTick(ref con, dt);

        // 敌机: 行为
        EnemyController.LogicTick(ref con, dt);

        // 子弹: 行为
        BulletController.LogicTick(ref con, dt);
    }

    static void Game_Draw(ref Context con) {
        // 我机 绘制
        PlayerController.DrawAll(ref con);

        // 敌人 绘制
        EnemyController.DrawAll(ref con);

        // 子弹 绘制
        BulletController.DrawAll(ref con);
    }
}