using System;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SemanticImages.Core.Tests
{
    [TestClass]
    public class ImageModificationManagerTests
    {
        private const int BASE_WIDTH = 100;
        private const int BASE_HEIGHT = 100;
        private const float SCALE = 0.5f;
        private Bitmap _sourceImage;

        [TestInitialize]
        public void Init()
        {
            _sourceImage = new Bitmap(BASE_WIDTH, BASE_HEIGHT);
            
            for (int x = 0; x < BASE_WIDTH; x++)
            {
                for (int y = 0; y < BASE_HEIGHT; y++)
                {
                    _sourceImage.SetPixel(x, y, Color.Black);
                }
            }
        }

        [TestMethod]
        public void Should_Save_Last_Modification()
        {
            ImageModificationManager manager = new ImageModificationManager(_sourceImage);

            manager.Resize(SCALE);
            Assert.IsTrue(manager.LastModification.Width == BASE_WIDTH * SCALE 
                && manager.LastModification.Height == BASE_HEIGHT * SCALE);
        }

        [TestMethod]
        public void Should_Undo_Last_Change()
        {
            ImageModificationManager manager = new ImageModificationManager(_sourceImage);

            manager.Resize(SCALE);
            manager.Resize(SCALE);
            manager.Undo();
            Assert.IsTrue(manager.LastModification.Width == BASE_WIDTH * SCALE
                && manager.LastModification.Height == BASE_HEIGHT * SCALE);
        }

        [TestMethod]
        public void Should_Undo_All_Changes()
        {
            ImageModificationManager manager = new ImageModificationManager(_sourceImage);

            manager.Resize(SCALE);
            manager.Resize(SCALE);
            manager.UndoAll();
            Assert.IsTrue(manager.LastModification.Width == BASE_WIDTH
                && manager.LastModification.Height == BASE_HEIGHT);
        }
    }
}
