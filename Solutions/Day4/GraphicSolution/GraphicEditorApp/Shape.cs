namespace Drawing;

public enum Color
{
   Red,
   Green,
   Blue,
   Yellow,
   Black
}

public abstract class Shape
{
   protected int Thickness { get; set; }
   protected Color ShapeColor { get; set; }
   public abstract void Draw();
}