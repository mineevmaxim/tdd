using System.Drawing;

namespace TagsCloudVisualization;

public static class RectangleFExtensions
{
    public static RectangleF GetRectangleFWithCenterIn(PointF center, SizeF size) 
        => new(center.X - size.Width / 2, center.Y + size.Height / 2, size.Width, size.Height);
    
    public static PointF GetCenter(this RectangleF rectangle)
        => new(rectangle.X + rectangle.Width / 2, rectangle.Y - rectangle.Height / 2);
}