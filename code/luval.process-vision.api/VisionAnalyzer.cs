using luval.process_vision.api.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.process_vision.api
{
    public class VisionAnalyzer
    {
        private PredictionService _predictionService;
        private OcrService _ocrService;

        public VisionAnalyzer()
        {
            _predictionService = new PredictionService();
            _ocrService = new OcrService();
        }

        public VisionResult GetResult(string imageFileName)
        {
            var predictionResult = _predictionService.Predict(imageFileName);
            return GetResult(imageFileName, predictionResult.Data);
        }

        public VisionResult GetResult(string imageFileName, PredictionResponse prediction)
        {
            var file = new FileInfo(imageFileName);
            var img = new Bitmap(file.FullName);
            var topBox = prediction.
                Predictions.Where(i => i.TagName == "Box").OrderByDescending(i => i.Probability)
                .FirstOrDefault();
            var buttons = GetButtonsInsideBox(topBox, prediction);
            var result = new VisionResult()
            {
                Box = FromPrediction(file.Extension, img, topBox),
                Buttons = buttons.Select(i => FromPrediction(file.Extension, img, i)).ToList()
            };
            return null;
        }

        private VisionObject FromPrediction(string fileExtension, Bitmap img, PredictionResult prediction)
        {
            var fileInfo = new FileInfo(string.Format(@"C:\Folder\{0}.{1}",Guid.NewGuid(), fileExtension));
            var boxImg = GetBoxImage(img, prediction.BoundingBox);
            var imgBytes = GetImageBytes(boxImg, GetFormat(fileExtension));
            var ocr = _ocrService.DoOcr(fileInfo, imgBytes);
            var result = new VisionObject()
            {
                Location = new Rectangle() { X = 0, Y = 0, Width = boxImg.Width, Height = boxImg.Height },
                Probability = prediction.Probability,
                TagName = prediction.TagName,
                OcrResult = ocr.Data

            };
            return result;
        }

        private ImageFormat GetFormat(string extension)
        {
            var evaluate = extension.ToLowerInvariant().Replace(".", "");
            switch (evaluate)
            {
                case "png": return ImageFormat.Png;
                case "jpeg": return ImageFormat.Jpeg;
                case "tiff": return ImageFormat.Tiff;
                case "gif": return ImageFormat.Gif;
                case "bmp": return ImageFormat.Bmp;
                case "jpg": return ImageFormat.Jpeg;
                default: return ImageFormat.Bmp;
            }
        }

        public List<PredictionResult> GetButtonsInsideBox(PredictionResult box, PredictionResponse prediction)
        {
            var buttonsInside = prediction.Predictions
                .Where(i => i.TagName == "Button" && i.BoundingBox.Left > box.BoundingBox.Left
                        && i.BoundingBox.Top > box.BoundingBox.Top).OrderByDescending(i => i.Probability)
                        .Take(4).ToList();
            return buttonsInside;
        }

        private byte[] GetImageBytes(Image img, ImageFormat format)
        {
            using (var ms = new MemoryStream())
            {
                img.Save(ms, format);
                return ms.ToArray();
            }
        }

        private Image GetBoxImage(Bitmap img, PredictionBoundingBox box)
        {
            var rec = GetBoxFromImage(box, img.Size);
            var format = img.PixelFormat;
            var newImg = img.Clone(rec, format);
            newImg.Save(@"C:\Users\ch489gt\Pictures\Snag-Auto\marin.png");
            return newImg;
        }

        private Image GetBoxImage(string imageFileName, PredictionBoundingBox box)
        {
            return GetBoxImage(new Bitmap(imageFileName), box);
        }

        private Rectangle GetBoxFromImage(PredictionBoundingBox box, Size imgSize)
        {
            return new Rectangle()
            {
                X = Convert.ToInt32(imgSize.Width * box.Left),
                Y = Convert.ToInt32(imgSize.Height * box.Top),
                Width = Convert.ToInt32(imgSize.Width * box.Width),
                Height = Convert.ToInt32(imgSize.Height * box.Height)
            };
        }
    }
}
