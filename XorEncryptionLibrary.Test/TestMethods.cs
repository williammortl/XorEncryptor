namespace XorEncryptionLibrary.Test
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using XorEncryptionLibrary;
    using System.Linq;
    using System.IO;
    
    /// <summary>
    /// Test methods for XorEncryptionLibrary
    /// </summary>
    [TestClass]
    public class TestMethods
    {

        /// <summary>
        /// Test web page download
        /// </summary>
        [TestMethod]
        public void TestWebPageDownloadSuccessAndFailure()
        {

            // test successes
            byte[] download = XorEncryptionMethods.GetWebPage("http://www.williammortl.com");
            Assert.IsNotNull(download);
            Assert.IsTrue(download.Length > 0);
            download = XorEncryptionMethods.GetWebPage("http://williammortl.com");
            Assert.IsNotNull(download);
            Assert.IsTrue(download.Length > 0);

            // test failures
            download = XorEncryptionMethods.GetWebPage("http://this.not.my.website.williammortl.com");
            Assert.IsNull(download);
            download = XorEncryptionMethods.GetWebPage("www.google.com");
            Assert.IsNull(download);
        }

        /// <summary>
        /// Test downloading a key and using XorBytes
        /// </summary>
        [TestMethod]
        public void TestXorBytesWithWebKey()
        {

            // download key
            byte[] key = XorEncryptionMethods.GetWebPage("http://www.williammortl.com");
            Assert.IsNotNull(key);
            Assert.IsTrue(key.Length > 1);

            // xor and test
            byte[] data = { 1, 2, 3, 4, 255 };
            int keyPointer = 0;
            byte [] xdata = XorEncryptionMethods.XorBytes(data, key, ref keyPointer);
            Assert.IsNotNull(xdata);
            Assert.IsTrue(keyPointer == data.Length);
            Assert.IsTrue(xdata.Length == data.Length);
            Assert.IsFalse(data.SequenceEqual<byte>(xdata));
            keyPointer = 0;
            byte[] xxdata = XorEncryptionMethods.XorBytes(xdata, key, ref keyPointer);
            Assert.IsNotNull(xxdata);
            Assert.IsTrue(keyPointer == xdata.Length);
            Assert.IsTrue(xxdata.Length == xdata.Length);
            Assert.IsTrue(data.SequenceEqual<byte>(xxdata));
        }

        /// <summary>
        /// Test XorBytes with key that wraps
        /// </summary>
        [TestMethod]
        public void TestXorBytesWithKeyWrap()
        {

            // var init
            byte[] data = { 1, 2, 3, 4, 5, 6, 255 };
            byte[] key = { 111, 222, 200 };
            int keyPointer = 0;

            // xor and test
            byte[] xdata = XorEncryptionMethods.XorBytes(data, key, ref keyPointer);
            Assert.IsNotNull(xdata);
            Assert.IsTrue(keyPointer == 1);
            Assert.IsTrue(xdata.Length == data.Length);
            Assert.IsFalse(data.SequenceEqual<byte>(xdata));
            keyPointer = 0;
            byte[] xxdata = XorEncryptionMethods.XorBytes(xdata, key, ref keyPointer);
            Assert.IsNotNull(xxdata);
            Assert.IsTrue(keyPointer == 1);
            Assert.IsTrue(xxdata.Length == xdata.Length);
            Assert.IsTrue(data.SequenceEqual<byte>(xxdata));
        }

        /// <summary>
        /// Test XorBytes with key that wraps
        /// </summary>
        [TestMethod]
        public void TestXorFileWithWebKey()
        {

            // download key
            byte[] key = XorEncryptionMethods.GetWebPage("http://www.williammortl.com");
            Assert.IsNotNull(key);
            Assert.IsTrue(key.Length > 1);

            // xor file
            Assert.IsTrue(XorEncryptionMethods.XorFile("GettysburgAddress.txt", key, "x.txt"));
            Assert.IsTrue(XorEncryptionMethods.XorFile("x.txt", key, "xx.txt"));
            Assert.IsTrue(File.ReadAllBytes("GettysburgAddress.txt").SequenceEqual<byte>(File.ReadAllBytes("xx.txt")));

            // cleanup
            File.Delete("x.txt");
            File.Delete("xx.txt");
        }
    }
}
