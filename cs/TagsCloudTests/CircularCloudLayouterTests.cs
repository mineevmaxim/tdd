using System.Drawing;
using NUnit.Framework;
using FluentAssertions;
using TagsCloudVisualization;

namespace TagsCloudTests;

public class CircularCloudLayouterTests
{
    [Test]
    [Description("Центр первого прямоугольника равен параметру center")]
    public void PutNextRectangle_FirstRect_ShouldBeInCenter()
    {
        var rectSize = new SizeF(100, 100);
        var center = new PointF(10, 10);
        var layouter = new CircularCloudLayouter(center, new SpiralPointDistributor(center));
        var rect = layouter.PutNextRectangle(rectSize);
        rect.GetCenter().Should().Be(center);
    }

    [Test]
    public void PutNextRectangle_Rectangles_ShouldNotIntersect()
    {
        var center = new PointF(0, 0);
        var rnd = new Random();
        var layouter = new CircularCloudLayouter(center, new SpiralPointDistributor(center));
        var rectangles = new List<RectangleF>();
        for (var i = 0; i < 10; i++)
        {
            var rect = layouter.PutNextRectangle(new SizeF(rnd.Next(1, 20), rnd.Next(1, 20)));
            rectangles.Add(rect);
        }

        for (var i = 0; i < rectangles.Count; i++)
        for (var j = i; j < rectangles.Count; j++)
            if (i != j)
                rectangles[i].IntersectsWith(rectangles[j]).Should().BeFalse($"{rectangles[i]}, {rectangles[j]}");
    }
}