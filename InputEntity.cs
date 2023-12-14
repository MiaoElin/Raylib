using Raylib_cs;
using System.Numerics;
public struct InputEntity
{
    public Vector2 moveAxis;
    public void Process()
    {
        float x = 0;
        float y = 0;
        if (Raylib.IsKeyDown(KeyboardKey.KEY_W))
        {
            y = -1;
        }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_S))
        {
            y = 1;
        }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
        {
            x = -1;
        }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
        {
            x = 1;
        }
        moveAxis.X = x;
        moveAxis.Y = y;
    }
    public bool isShootProcess()
    {
        if (Raylib.IsKeyDown(KeyboardKey.KEY_SPACE))
        {
            return true;
        }
        else
        {
            return false;
        }

    }
}