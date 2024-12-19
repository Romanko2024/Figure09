using System.Drawing;

abstract class Figure
{
    protected int CenterX { get; set; }
    protected int CenterY { get; set; }

    public Figure(int x, int y)
    {
        CenterX = x;
        CenterY = y;
    }

    public abstract void DrawBlack(Graphics g);
    public abstract void HideDrawingBackGround(Graphics g, Color backgroundColor);
    //
    
}
