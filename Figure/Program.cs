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
    public void MoveRight(Graphics g, Color backgroundColor, int distance, int step = 10)
    {
        for (int i = 0; i < distance; i += step)
        {
            DrawBlack(g); //намалювати
            Thread.Sleep(100); //зачекати
            HideDrawingBackGround(g, backgroundColor); //стерти
            CenterX += step; //змінити координату
        }
    }

}
