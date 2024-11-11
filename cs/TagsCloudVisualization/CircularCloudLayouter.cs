using System.Drawing;

namespace TagsCloudVisualization;

public class CircularCloudLayouter
{
    private readonly PointF center;

    public CircularCloudLayouter(PointF center)
        => this.center = center;

    public RectangleF PutNextRectangle(SizeF rectangleSize)
    {
        var rect = RectangleFExtensions.GetRectangleFWithCenterIn(center, rectangleSize);
        return rect;
    }
}