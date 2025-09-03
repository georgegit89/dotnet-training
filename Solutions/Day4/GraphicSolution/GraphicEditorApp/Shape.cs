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
   protected int thickness { get; set; }
   protected Color shapeColor { get; set; }
}