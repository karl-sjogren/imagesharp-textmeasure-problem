using System;
using System.IO;
using SixLabors.Fonts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using SixLabors.Primitives;

namespace imagesharp_textmeasure {
    class Program {
        static void Main(string[] args) {
            var squareSize = 512;
            using(var img = new Image<Rgba32>(squareSize, squareSize)) {
                var backgroundColor = Rgba32.Salmon;

                var font = SystemFonts.CreateFont("Arial", 300);
                var text = "KS";

                var textSize = TextMeasurer.Measure(text, new RendererOptions(font, 72));

                Console.WriteLine($"Measured size: {textSize.Width}, {textSize.Height}, Text: {text}");

                var textGraphicsOptions = new TextGraphicsOptions(true);

                var textPosition = new PointF(squareSize / 2f - textSize.Width / 2, squareSize / 2f - textSize.Height / 2f);
                img.Mutate(ctx => ctx
                    .Fill(backgroundColor)
                    .DrawText(text, font, Rgba32.White, textPosition));

                byte[] buffer;
                using(var ms = new MemoryStream()) {
                    img.SaveAsPng(ms);
                    ms.Seek(0, SeekOrigin.Begin);
                    buffer = ms.ToArray();
                }

                var base64Image = Convert.ToBase64String(buffer);
                Console.WriteLine("\x1b]1337;File=inline=1;width=100px;height=100px:" + base64Image + "\a\n");

                File.WriteAllBytes("result.png", buffer);
            }
        }
    }
}
