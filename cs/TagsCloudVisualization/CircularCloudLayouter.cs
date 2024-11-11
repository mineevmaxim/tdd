using System.Drawing;

namespace TagsCloudVisualization;

public class CircularCloudLayouter
{
    private readonly PointF center;

    public CircularCloudLayouter(PointF center)
    {
        this.center = center;
    }

    public RectangleF PutNextRectangle(SizeF rectangleSize)
    {
        var rect = new RectangleF(new PointF(center.X - rectangleSize.Width / 2, center.Y + rectangleSize.Height / 2), rectangleSize);
        return rect;
    }
}