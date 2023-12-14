public static class PlayerController
{

    public static void ProcessInput(ref Context ctx)
    {
        ref InputEntity input = ref ctx.input;
        input.Process();
    }

    // 行为
    public static void LogicTick(ref Context ctx, float dt)
    {
        ref InputEntity input = ref ctx.input;
        ref PlaneEntity plane = ref ctx.plane;

        // 我方移动
        plane.Move(input.moveAxis, dt);

        // 我机 无敌时间
        plane.invincibleTimer -= dt;
        if (plane.invincibleTimer <= 0)
        {
            plane.invincibleTimer = 0;
        }

    }

    public static void DrawAll(ref Context ctx)
    {
        PlaneEntity plane = ctx.plane;
        if (!plane.isDead)
        {
            plane.Draw();
        }
    }

}