using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dotnet
{
    public class ResizeHttpTrigger
    {
        private readonly ILogger<ResizeHttpTrigger> _logger;

        public ResizeHttpTrigger(ILogger<ResizeHttpTrigger> logger)
        {
            _logger = logger;
        }

        [Function("ResizeHttpTrigger")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            // 1. Get image parameters from the query string
            string widthParam = req.Query["w"];
            string heightParam = req.Query["h"];

            if (!int.TryParse(widthParam, out int width) || !int.TryParse(heightParam, out int height))
            {
                return new BadRequestObjectResult("Invalid width or height parameters.");
            }

            // 2. Read the image bytes from the request body (as a stream)
            byte[] imageBytes;
            using (var ms = new MemoryStream())
            {
                await req.Body.CopyToAsync(ms);
                imageBytes = ms.ToArray();
            }

            if (imageBytes == null || imageBytes.Length == 0)
            {
                return new BadRequestObjectResult("No image data received.");
            }

            // 3. Resize the image using ImageSharp
            using (var image = Image.Load(imageBytes))
            {
                image.Mutate(x => x.Resize(width, height));

                // 4. Convert the image to a byte array
                using (var ms = new MemoryStream())
                {
                    await image.SaveAsJpegAsync(ms);
                    var resizedImageBytes = ms.ToArray();

                    // 5. Return the resized image as the response
                    return new FileContentResult(resizedImageBytes, "image/jpeg");
                }
            }
        }
    }
}
