using System.Numerics;
using Raylib_cs;

public struct GUIButton {

    public Rectangle rect;
    public string text;
    public Color bgColor; // 背景
    public Color fontColor; // 字色
    bool isMouseHover;

    public GUIButton(Vector2 pos, Vector2 size, Color bgColor, Color fontColor, string text) {
        this.rect = new Rectangle(pos.X, pos.Y, size.X, size.Y);
        this.text = text;
        this.bgColor = bgColor;
        this.fontColor = fontColor;
        isMouseHover = false;
    }

    public bool IsMouseInside(Vector2 mousePos) {
        Vector2 leftTop = new Vector2(rect.X, rect.Y); // 按钮的左上角
        Vector2 rightBottom = new Vector2(rect.X + rect.Width, rect.Y + rect.Height); // 右下角
        if (IntersectUtil.IsPointInsideRect(mousePos, leftTop, rightBottom)) {
            isMouseHover = true;
            return true;
        } else {
            isMouseHover = false;
            return false;
        }
    }

    public void Draw() {
        Color bgFade = bgColor;
        // 鼠标进入时
        if (isMouseHover) {
            bgFade = Color.RED;
        }
        Raylib.DrawRectangleRec(rect, bgFade);
        Raylib.DrawText(text, (int)rect.X, (int)rect.Y, 14, fontColor);
    }

}