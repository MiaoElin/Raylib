using System.Numerics;
using Raylib_cs;

public static class FindUtil
{
    public static PlaneEntity FindNearEnemy(Vector2 pos, PlaneEntity[] enemies, int enemiesCount, out int nearlyEnemyIndex)
    {
        PlaneEntity nearlyEnemy = default;
        float nearDistan = float.MaxValue;
        float enemyPlaneDistance;
        int index = -1;
        for (int i = 0; i < enemiesCount; i++)
        {
            var cur = enemies[i];
            if (cur.isDead)
            {
                continue;
            }
            enemyPlaneDistance = Vector2.Distance(pos, enemies[i].pos);

            if (enemyPlaneDistance < nearDistan)
            {
                nearDistan = enemyPlaneDistance;
                nearlyEnemy = enemies[i];
                index = i;
            }

        }
        nearlyEnemyIndex = index;
        return nearlyEnemy;

    }
}