using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prokim.Core.IO
{
    public class ImageReader
    {
        private readonly string _path;

        public Bitmap Image
        {
            get; private set;
        }

        public ImageReader(string path)
        {
            _path = path;
        }

        public void Read()
        {
            byte[] bytes = File.ReadAllBytes(_path);

            Image = BytesToImage(bytes);
        }

        /// <summary>
        /// Converts an array of bytes into a bitmap image.
        /// </summary>
        /// <param name="bytes">the array of bytes containing image information</param>
        /// <returns>the bitmap generated from the array of bytes</returns>
        private Bitmap BytesToImage(byte[] bytes)
        {
            MemoryStream ms = new MemoryStream(bytes);
            Image image = System.Drawing.Image.FromStream(ms, false, true);

            return new Bitmap(image);
        }
    }
}
