namespace Drawing;

public class Line : Shape, IDisposable
{
   public Point Start { get; set; }
   public Point End { get; set; }

   public Line()
   {
      Start = new Point();
      End = new Point();
   }
   public Line(Point start, Point end, int thickness, Color color)
   {
      Start = start;
      End = end;
      Thickness = thickness;
      ShapeColor = color;
   }
   public override void Draw()
   {
      Console.WriteLine($"Drawing a {ShapeColor} line from {Start} to {End} with thickness {Thickness}");
   }
   public void Dispose()
   {
      // Clean up resources
      GC.SuppressFinalize(this);
   }
}