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

class Circle : Figure
{
    public int Radius { get; set; }

    public Circle(int x, int y, int radius) : base(x, y)
    {
        Radius = radius;
    }

    public override void DrawBlack(Graphics g)
    {
        g.FillEllipse(Brushes.Black, CenterX - Radius, CenterY - Radius, Radius * 2, Radius * 2);
    }

    public override void HideDrawingBackGround(Graphics g, Color backgroundColor)
    {
        g.FillEllipse(new SolidBrush(backgroundColor), CenterX - Radius, CenterY - Radius, Radius * 2, Radius * 2);
    }
}

class Square : Figure
{
    public int SideLength { get; set; }

    public Square(int x, int y, int sideLength) : base(x, y)
    {
        SideLength = sideLength;
    }

    public override void DrawBlack(Graphics g)
    {
        g.FillRectangle(Brushes.Black, CenterX - SideLength / 2, CenterY - SideLength / 2, SideLength, SideLength);
    }

    public override void HideDrawingBackGround(Graphics g, Color backgroundColor)
    {
        g.FillRectangle(new SolidBrush(backgroundColor), CenterX - SideLength / 2, CenterY - SideLength / 2, SideLength, SideLength);
    }
}

class Rhomb : Figure
{
    public int HorDiagLen { get; set; }
    public int VertDiagLen { get; set; }

    public Rhomb(int x, int y, int horDiagLen, int vertDiagLen) : base(x, y)
    {
        HorDiagLen = horDiagLen;
        VertDiagLen = vertDiagLen;
    }

    public override void DrawBlack(Graphics g)
    {
        //4 точки ромба верхня права нижня ліва
        Point[] points = {
            new Point(CenterX, CenterY - VertDiagLen / 2),
            new Point(CenterX + HorDiagLen / 2, CenterY),
            new Point(CenterX, CenterY + VertDiagLen / 2),
            new Point(CenterX - HorDiagLen / 2, CenterY)
        };
        g.FillPolygon(Brushes.Black, points);
    }

    public override void HideDrawingBackGround(Graphics g, Color backgroundColor)
    {
        Point[] points = {
            new Point(CenterX, CenterY - VertDiagLen / 2),
            new Point(CenterX + HorDiagLen / 2, CenterY),
            new Point(CenterX, CenterY + VertDiagLen / 2),
            new Point(CenterX - HorDiagLen / 2, CenterY)
        };
        g.FillPolygon(new SolidBrush(backgroundColor), points);
    }
}
