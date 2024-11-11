using System.Drawing;

namespace TagsCloudVisualization;

public class CircularCloudLayouter
{
    private readonly IPointDistributor distributor;
    private readonly List<RectangleF> rectangles = [];

    public CircularCloudLayouter(PointF center, IPointDistributor distributor)
        => this.distributor = distributor;

    public RectangleF PutNextRectangle(SizeF rectangleSize)
    {
        PointF point;
        RectangleF rect;
        do
        {
            point = distributor.GetNextPoint();
            rect = RectangleFExtensions.GetRectangleFWithCenterIn(point, rectangleSize);
        } while (rectangles.Any(r => r.IntersectsWith(rect)));

        rectangles.Add(rect);
        Console.WriteLine(rect);
        return rect;
    }
}