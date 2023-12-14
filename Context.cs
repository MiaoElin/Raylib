using System.Numerics;
using Raylib_cs;

public struct Context{

    public PlaneEntity plane;

    public PlaneEntity[] enemies;
    public int enemyCount;

    public BulletEntity[] bullets;
    public int bulletCount;

    public InputEntity input;

    public void Initialize(){
        plane = PlaneEntity.CreatePlane(new(400, 240), Color.BLUE, 20, 50, 100);

        
    }
    
}