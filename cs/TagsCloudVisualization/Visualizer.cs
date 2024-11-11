using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace TagsCloudVisualization;

public class Visualizer
{
    private readonly IEnumerable<RectangleF> rectangles;

    public Visualizer(IEnumerable<System.Drawing.RectangleF> rectangles)
        => this.rectangles = rectangles.Select(rect => new RectangleF(rect.X, rect.Y, rect.Width, rect.Height));

    public Visualizer(IEnumerable<RectangleF> rectangles)
        => this.rectangles = rectangles;

    public void SaveVisualizationAsPng(string fileName)
    {
        using var image = new Image<Rgba32>(1000, 1000);
        image.Mutate(ctx =>
        {
            ctx.Clear(Color.Azure);

            foreach (var rectangle in rectangles)
                ctx.Draw(Color.DarkRed, 1.5f, rectangle);
        });
        image.SaveAsPng(fileName);
        Console.WriteLine($"Tag cloud visualization saved to file {fileName}");
    }
}