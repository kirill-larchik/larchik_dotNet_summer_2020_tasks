using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechShopProductsClassLibrary;

namespace TechShopProductsUnitTestProject
{
    [TestClass]
    public class ProductsUnitTest
    {
        [TestMethod]
        public void Plus_Processors()
        {
            Processor firstProcessor = new Processor("Intel i5", 125.65);
            Processor secondProcessor = new Processor("Ryzen 5", 100.35);
            Processor expected = new Processor("Intel i5 - Ryzen 5", 113);

            Processor actual = firstProcessor + secondProcessor;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Plus_VideoCards()
        {
            VideoСard firstVideoCard = new VideoСard("NVIDIA GTX 1050ti", 125.65);
            VideoСard secondVideoCard = new VideoСard("RADEON RX580", 100.35);
            VideoСard expected = new VideoСard("NVIDIA GTX 1050ti - RADEON RX580", 113);

            VideoСard actual = firstVideoCard + secondVideoCard;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Cast_ProcessorToVideoCard()
        {
            Processor firstProcessor = new Processor("Intel i5", 125.65);
            VideoСard expected = new VideoСard("Intel i5", 125.65);

            VideoСard actual = (VideoСard)firstProcessor;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Cast_VideoCardToProcessor()
        {
            VideoСard firstVideoCard = new VideoСard("Intel i5", 125.65);
            Processor expected = new Processor("Intel i5", 125.65);

            Processor actual = (Processor)firstVideoCard;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Cast_ProcessorToInt()
        {
            Processor firstProcessor = new Processor("Intel i5", 125.65);
            int expected = 12565;

            int actual = (int)firstProcessor;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Cast_ProcessorToFloat()
        {
            Processor firstProcessor = new Processor("Intel i5", 125.65);
            double expected = 125.65;

            double actual = (double)firstProcessor;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Cast_VideoCardToInt()
        {
            VideoСard firstVideoCard = new VideoСard("RADEON RX580", 100.35);
            int expected = 10035;

            int actual = (int)firstVideoCard;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Cast_VideoCardToFloat()
        {
            VideoСard firstVideoCard = new VideoСard("RADEON RX580", 100.35);
            double expected = 100.35;

            double actual = (double)firstVideoCard;

            Assert.AreEqual(expected, actual);
        }
    }
}
