using System.Drawing;

namespace TagsCloudVisualization;

public class SpiralPointDistributor : IPointDistributor
{
    private readonly PointF center;
    private float radius;
    private float angle;
    private readonly float angleStep;
    private readonly float radiusStep;

    public SpiralPointDistributor(PointF center, float angleStep = MathF.PI / 180, float radiusStep = 1f)
    {
        this.center = center;
        this.angleStep = angleStep;
        this.radiusStep = radiusStep;
    }
    
    public PointF GetNextPoint()
    {
        var x = center.X + radius * MathF.Cos(angle);
        var y = center.Y + radius * MathF.Sin(angle);
        
        angle += angleStep;
        if (angle >= MathF.PI * 2 || radius == 0)
        {
            angle = 0;
            radius += radiusStep;
        }

        return new PointF(x, y);
    }
}