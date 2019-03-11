using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace SemanticImages.Core
{
    /// <summary>
    /// Tools for image processing.
    /// </summary>
    public static class ImageUtils
    {
        /// <summary>
        /// Resizes an image without necessarily keeping the aspect ratio.
        /// </summary>
        /// <param name="image">the image to be resized</param>
        /// <param name="width">new image width</param>
        /// <param name="height">new image height</param>
        public static Bitmap Resize(Image image, int width, int height)
        {
            if (width <= 0 || height <= 0)
            {
                throw new ArgumentException("Width and height must be strictly positive.");
            }

            Rectangle r = new Rectangle(0, 0, width, height);
            Bitmap result = new Bitmap(width, height);

            result.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(result))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, r, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel);
                }
            }

            return result;
        }

        /// <summary>
        /// Resizes an image keeping the aspect ratio.
        /// </summary>
        /// <param name="image">the image to be resized</param>
        /// <param name="scale">the factor by which the image is to be scaled</param>
        public static Bitmap Resize(Image image, float scale)
        {
            if (scale <= 0)
            {
                throw new ArgumentException("Scale must be strictly positive.");
            }

            return Resize(image, (int) (Math.Floor(image.Width * scale)), (int) (Math.Floor(image.Height * scale)));
        }

        /// <summary>
        /// Crops an image.
        /// </summary>
        /// <param name="image">is the image to be cropped</param>
        /// <param name="x">is the x coordinate of the upper left bound of the crop rectangle</param>
        /// <param name="y">is the y coordinate of the upper left bound of the crop rectangle</param>
        /// <param name="width">is the width of the crop rectangle</param>
        /// <param name="height">is the height of the crop rectangle</param>
        /// <returns>the cropped image</returns>
        public static Bitmap Crop(Image image, int x, int y, int width, int height)
        {
            Rectangle r = new Rectangle(x, y, width, height);

            return Crop(image, r);
        }

        /// <summary>
        /// Crops an image.
        /// </summary>
        /// <param name="image">is the image to be cropped</param>
        /// <param name="r">is the crop rectangle</param>
        /// <returns>the cropped image</returns>
        public static Bitmap Crop(Image image, Rectangle r)
        {
            if (!ValidateCropBounds(r, image))
            {
                throw new ArgumentException("Crop coordinates out of bounds.");
            }

            Bitmap cropped = new Bitmap(r.Width, r.Height);

            using (var graphics = Graphics.FromImage(cropped))
            {
                graphics.DrawImage(image, new Rectangle(0, 0, r.Width, r.Height), r, GraphicsUnit.Pixel);
            }

            return cropped;
        }

        /// <summary>
        /// Converts an array of bytes into a bitmap image.
        /// </summary>
        /// <param name="bytes">the array of bytes containing image information</param>
        /// <returns>the bitmap generated from the array of bytes</returns>
        public static Bitmap BytesToImage(byte[] bytes)
        {
            MemoryStream ms = new MemoryStream(bytes);
            Image image = Image.FromStream(ms, false, true);

            return new Bitmap(image);
        }

        /// <summary>
        /// Given the path to an image, determines the corresponding image format.
        /// </summary>
        /// <param name="path">is a path to an image</param>
        /// <returns>the image format</returns>
        public static ImageFormat GetImageFormat(string path)
        {
            string formatStr = Path.GetExtension(path).Replace(".", "");
            ImageFormat format = null;

            switch (formatStr.ToLower())
            {
                case "jpg":
                case "jpeg":
                    format = ImageFormat.Jpeg;
                    break;
                case "png":
                    format = ImageFormat.Png;
                    break;
                case "bmp":
                    format = ImageFormat.Bmp;
                    break;
                default:
                    throw new ArgumentException("Not a path to an image.");
            }

            return format;
        }

        /// <summary>
        /// Validates the bounds of a rectangle for cropping 
        /// </summary>
        /// <param name="r"></param>
        /// <param name="image"></param>
        /// <returns></returns>
        private static bool ValidateCropBounds(Rectangle r, Image image)
        {
            Point min = new Point(r.X, r.Y);
            Point max = new Point(r.X + r.Width, r.Y + r.Height);

            if (min.X < 0 || min.X > image.Width)
                return false;
            
            if (min.Y < 0 || min.Y > image.Height)
                return false;

            if (max.X < 0 || max.X > image.Width)
                return false;

            if (max.Y < 0 || max.Y > image.Height)
                return false;

            return true;
        }
    }
}
