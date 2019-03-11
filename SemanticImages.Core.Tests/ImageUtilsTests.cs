using System;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SemanticImages.Core.Tests
{
    [TestClass]
    public class ImageUtilsTests
    {
        private const int INITIAL_WIDTH = 1024;
        private const int INITIAL_HEIGHT = 768;

        [TestMethod]
        public void ShouldResizeImage()
        {
            const int NEW_WIDTH = 100;
            const int NEW_HEIGHT = 100;

            Image sourceImage = new Bitmap(INITIAL_WIDTH, INITIAL_HEIGHT);
            Image destImage = ImageUtils.Resize(sourceImage, NEW_WIDTH, NEW_HEIGHT);

            Assert.AreEqual(destImage.Width, NEW_WIDTH);
            Assert.AreEqual(destImage.Height, NEW_HEIGHT);
        }

        [TestMethod]
        public void ShouldResizeImageMaintainingAspectRation()
        {
            const float SCALE = 1.75f;

            Image sourceImage = new Bitmap(INITIAL_WIDTH, INITIAL_HEIGHT);
            Image destImage = ImageUtils.Resize(sourceImage, SCALE);

            Assert.AreEqual(destImage.Width / destImage.Height, sourceImage.Width / sourceImage.Height);
        }
    }
}
