using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemanticImages.Core.IO
{
    public class ImageWriter
    {
        private readonly string _path;

        public Bitmap Image
        {
            get; private set;
        }

        public ImageWriter(string path)
        {
            _path = path;
        }

        public void Write(Image image)
        {
            ImageFormat format = GetImageFormat(_path);

            image.Save(_path, format);
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
    }
}
