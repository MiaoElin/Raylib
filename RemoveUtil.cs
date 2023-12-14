using System.Numerics;
using Raylib_cs;
public static class RemoveUtil{
    public static void RemoveEnemy(int existCount,int nearlyEnemyIndex,PlaneEntity nearlyEnemy,PlaneEntity[]enemies){
        enemies[nearlyEnemyIndex]= enemies[enemies.Length-1];
        enemies[enemies.Length-1]=nearlyEnemy;
    }
    public static void RemoveBullet(int bulletCount,int bulletIndex,BulletEntity bullet,BulletEntity[]bullets){
        bullets[bulletIndex] = bullets[bullets.Length-1];
        bullets[bullets.Length-1] =bullet;

    }
}