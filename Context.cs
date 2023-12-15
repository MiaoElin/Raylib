using System.Numerics;
using Raylib_cs;

public struct Context
{

    public PlaneEntity plane;

    public PlaneEntity[] enemies;
    public int enemyCount;
    public float enemySpwanInterval;
    public float enemySpawnTimer;

    public BulletEntity[] bullets;
    public int bulletCount;

    public InputEntity input;

    public GUIButton btn_login_startGame;

    public sbyte gameStatus; // 0: 登录; 1: 游戏中; 2: 游戏结束

    public void Initialize()
    {
        plane = Factory.CreatePlane(new(400, 240), Color.BLUE, 20, 50, 100);

        enemies = new PlaneEntity[20000];
        enemySpawnTimer = 2;
        enemySpwanInterval = 2;
        enemyCount = 0;

        bullets = new BulletEntity[20000];
        bulletCount = 0;

        input = new InputEntity();

        gameStatus = 0;

        // 登录 
        Vector2 btnPos = new Vector2(100, 100);
        Vector2 btnSize = new Vector2(100, 30);
        btn_login_startGame = new GUIButton(btnPos, btnSize, Color.BLACK, Color.WHITE, "Start Game"); // 矩形

    }

}