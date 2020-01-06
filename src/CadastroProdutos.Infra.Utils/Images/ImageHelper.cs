using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using CadastroProdutos.Infra.Utils.Enums;

namespace CadastroProdutos.Infra.Utils.Images
{
    public class ImageHelper
    {
        private IConfiguration _configuration;
        private string _archivesPath;
        private string _mobileThumbnailFolder;
        private string _webThumbnailFolder;

        public ImageHelper(IConfiguration configuration)
        {
            _configuration = configuration;
            _archivesPath = _configuration["AppSettings:ArchivesPath"];
            _mobileThumbnailFolder = _configuration["AppSettings:MobileThumbnailFolder"];
            _webThumbnailFolder = _configuration["AppSettings:WebThumbnailFolder"];
        }
        public byte[] GetImage(string fileName, ThumbnailTypeEnum? type = null)
        {
            string folder = _archivesPath;

            if (type != null)
            {
                
                folder = type == ThumbnailTypeEnum.Mobile ? $"{_archivesPath}/{_mobileThumbnailFolder}" : $"{_archivesPath}/{_webThumbnailFolder}";
            }

            return File.ReadAllBytes(Path.Combine(folder, fileName));
        }

        public async Task SaveImage(IFormFile file, string fileName)
        {
            if (!Directory.Exists(_archivesPath)) Directory.CreateDirectory(_archivesPath);

            var fullPathFileName = Path.Combine(_archivesPath, fileName);
            using (var fileStream = new FileStream(fullPathFileName, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            SetThumbnails(file.OpenReadStream(), fileName);
        }

        private void SetThumbnails(Stream imageStream, string fileName)
        {
            var originalImage = Image.FromStream(imageStream);

            if (!ValidateImageFormat(originalImage))
            {
                throw new ArgumentException();
            }

            SetCorrectOrientation(originalImage);

            var mobileThumbnailFolder = $"{_archivesPath}/{_mobileThumbnailFolder}/";
            var webThumbnailFolder = $"{_archivesPath}/{_webThumbnailFolder}/";

            if (!Directory.Exists(mobileThumbnailFolder)) Directory.CreateDirectory(mobileThumbnailFolder);
            if (!Directory.Exists(webThumbnailFolder)) Directory.CreateDirectory(webThumbnailFolder);

            CreateAndSaveThumbnail(originalImage, 100, $"{mobileThumbnailFolder}{fileName}");
            CreateAndSaveThumbnail(originalImage, 500, $"{webThumbnailFolder}{fileName}");
            originalImage.Dispose();
        }

        private static bool ValidateImageFormat(Image image)
        {
            if (ImageFormat.Jpeg.Equals(image.RawFormat))
            {
                return true;
            }
            if (ImageFormat.Png.Equals(image.RawFormat))
            {
                return true;
            }
            if (ImageFormat.Gif.Equals(image.RawFormat))
            {
                return true;
            }
            if (ImageFormat.Bmp.Equals(image.RawFormat))
            {
                return true;
            }
            return false;
        }

        private static void SetCorrectOrientation(Image image)
        {
            //property id = 274 describe EXIF orientation parameter
            if (Array.IndexOf(image.PropertyIdList, 274) > -1)
            {
                var orientation = (int)image.GetPropertyItem(274).Value[0];
                switch (orientation)
                {
                    case 1:
                        // No rotation required.
                        break;
                    case 2:
                        image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                        break;
                    case 3:
                        image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        break;
                    case 4:
                        image.RotateFlip(RotateFlipType.Rotate180FlipX);
                        break;
                    case 5:
                        image.RotateFlip(RotateFlipType.Rotate90FlipX);
                        break;
                    case 6:
                        image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        break;
                    case 7:
                        image.RotateFlip(RotateFlipType.Rotate270FlipX);
                        break;
                    case 8:
                        image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                        break;
                }
                // This EXIF data is now invalid and should be removed.
                image.RemovePropertyItem(274);
            }
        }

        private void CreateAndSaveThumbnail(Image image, int size, string thumbnailPath)
        {
            var thumbnailSize = GetThumbnailSize(image, size);

            using (var bitmap = ResizeImage(image, thumbnailSize.Width, thumbnailSize.Height))
            {
                bitmap.Save(thumbnailPath, ImageFormat.Jpeg);
            }
        }

        private static Size GetThumbnailSize(Image original, int size = 500)
        {
            var originalWidth = original.Width;
            var originalHeight = original.Height;

            double factor;
            if (originalWidth > originalHeight)
            {
                factor = (double)size / originalWidth;
            }
            else
            {
                factor = (double)size / originalHeight;
            }

            return new Size((int)(originalWidth * factor), (int)(originalHeight * factor));
        }

        private Bitmap ResizeImage(Image image, int width, int height)
        {
            var result = new Bitmap(width, height);

            using (var graphics = Graphics.FromImage(result))
            {
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;

                graphics.DrawImage(image, 0, 0, result.Width, result.Height);
            }

            return result;
        }
    }
}
