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
        var rectSize = new Size(100, 100);
        var center = new PointF(10, 10);
        var layouter = new CircularCloudLayouter(center);
        var rect = layouter.PutNextRectangle(rectSize);
        new PointF(rect.Location.X + rectSize.Width / 2, rect.Location.Y - rectSize.Height / 2).Should().Be(center);
    }
}