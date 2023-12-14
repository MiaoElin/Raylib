using System.Numerics;
using Raylib_cs;
public static class RemoveUtil{
    public static void RemoveEnemy(int existCount,int nearlyEnemyIndex,PlaneEntity nearlyEnemy,PlaneEntity[]enemies){
        enemies[nearlyEnemyIndex]= enemies[existCount-1];
        enemies[existCount-1]=nearlyEnemy;
    }
    public static void RemoveBullet(int bulletCount,int bulletIndex,BulletEntity bullet,BulletEntity[]bullets){
        bullets[bulletIndex] = bullets[bulletCount-1];
        bullets[bulletCount-1] =bullet;

    }
}