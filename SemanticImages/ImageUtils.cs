using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace SemanticImages
{
    /// <summary>
    /// Used for resizing an image.
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
    }
}
