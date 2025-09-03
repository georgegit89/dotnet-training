namespace Drawing;

public class Line : Shape, IDisposable
{
   public Point start { get; set; }
   public Point end { get; set; }

   public Line()
   {
      start = new Point();
      end = new Point();
   }
   public void Dispose()
   {
      // Clean up resources
   }
}