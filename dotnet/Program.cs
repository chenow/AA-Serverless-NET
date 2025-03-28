using System;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Formats.Jpeg;
using System.IO;

namespace ImageProcessingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = @"img.jpeg";
            string outputPath = @"img-resized.jpeg";

            RedimensionnerImage(inputPath, outputPath);
        }

        static void RedimensionnerImage(string inputPath, string outputPath)
        {
            try
            {
                using (Image image = Image.Load(inputPath))
                {
                    image.Mutate(x => x.Resize(image.Width / 2, image.Height / 2));
                    image.Save(outputPath, new JpegEncoder());
                    Console.WriteLine($"Image redimensionnée et sauvegardée à : {outputPath}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors du traitement de l'image : {ex.Message}");
            }
        }
    }
}
