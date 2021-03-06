﻿using BLL;
using DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Drawing;
using System.IO;

namespace TestFilterEdgeDetection
{
    [TestClass]
    public class TestImageManagement
    {
        readonly Bitmap landscapeImage = new Bitmap(Path.Combine(Environment.CurrentDirectory, @"data\", "landscape.jpg"));

        [TestMethod]
        public void TestLoadImage()
        {
            var ibitmapManager = Substitute.For<IBitmapManager>();

            ibitmapManager.GetBitmap().Returns(landscapeImage);

            ImageManagement imageManagement = new ImageManagement();
            Bitmap bitmap = imageManagement.LoadImage(ibitmapManager, 200);

            Assert.AreEqual("95981363415123963124134142051385511793", ImageFilters.BitmapToHash(bitmap));
        }

        [TestMethod]
        public void TestLoadImageException()
        {
            var ibitmapManager = Substitute.For<IBitmapManager>();
            ibitmapManager.GetBitmap().Returns(x => { throw new Exception(); });

            ImageManagement imageManagement = new ImageManagement();
            Assert.ThrowsException<Exception>(() => imageManagement.LoadImage(ibitmapManager, 200));
        }

        [TestMethod]
        public void TestSaveImage()
        {
            var ibitmapManager = Substitute.For<IBitmapManager>();

            ibitmapManager.SetBitmap(landscapeImage);

            ImageManagement imageManagement = new ImageManagement();
            try
            {
                imageManagement.SaveImage(ibitmapManager, landscapeImage);
                Assert.IsTrue(true);
            }
            catch
            {
                Assert.IsTrue(false);
            }
        }
    }
}
