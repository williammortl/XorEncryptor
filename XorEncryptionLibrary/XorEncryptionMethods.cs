namespace XorEncryptionLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.IO;
    using System.Net;

    /// <summary>
    /// Contains static methods for encrypting / decrypting
    /// </summary>
    public static class XorEncryptionMethods
    {

        /// <summary>
        /// The size of data to read from the file per call
        /// </summary>
        private const int CHUNK_SIZE = 1024;

        /// <summary>
        /// Xor encrypts / decrypts a file
        /// </summary>
        /// <param name="fileIn">the file to process</param>
        /// <param name="key">the key</param>
        /// <param name="fileOut">the file to write the xor encrypted / decrypted file to, creates the path if it doesn't exist</param>
        /// <returns>true if successful</returns>
        public static Boolean XorFile(String fileIn, byte[] key, String fileOut)
        {

            // short circuit
            if ((fileIn == String.Empty) || (key == null) || (File.Exists(fileIn) == false)) 
            {
                return false;
            }

            // var init
            byte[] buffer = new byte[XorEncryptionMethods.CHUNK_SIZE];
            Boolean retVal = true;
            int keyPointer = 0;

            try
            {

                // create the path if it doesn't exist
                String path = Path.GetDirectoryName(fileOut).Trim();
                if ((path != String.Empty) && (Directory.Exists(path) == false))
                {
                    Directory.CreateDirectory(path);
                }

                // xor the file with the key and write
                using (FileStream fsIn = File.OpenRead(fileIn))
                {
                    using (FileStream fsOut = File.OpenWrite(fileOut))
                    {
                        
                        // loop through file
                        while (true)
                        {

                            // read a chunk from the file and exit the loop done
                            int bytesRead = fsIn.Read(buffer, 0, XorEncryptionMethods.CHUNK_SIZE);
                            if (bytesRead <= 0)
                            {
                                break;
                            }

                            // xor the bytes of the chunk, handle if an error occurs
                            byte[] toWrite = XorEncryptionMethods.XorBytes(buffer.Take<byte>(bytesRead).ToArray<byte>(), key, ref keyPointer);
                            if (toWrite == null)
                            {
                                throw new Exception();
                            }

                            // write out to file
                            fsOut.Write(toWrite, 0, toWrite.Length);
                        }
                    }
                }
            }
            catch
            {

                // delete the portion of the file created
                if (File.Exists(fileOut))
                {
                    File.Delete(fileOut);
                }

                // return failure
                retVal = false;
            }

            return retVal;
        }

        /// <summary>
        /// Xor encrypts / decrypts a byte array with a key
        /// </summary>
        /// <param name="dataIn">the data to xor encrypt / decrypt</param>
        /// <param name="key">the key</param>
        /// <param name="keyPointer">the pointer of where to start in the key</param>
        /// <returns>byte array of data if successful, null on error</returns>
        public static byte[] XorBytes(byte[] dataIn, byte[] key, ref int keyPointer)
        {

            // var init
            byte[] retVal = (byte[])dataIn.Clone();

            try
            {

                // loop through byte array
                for (int i = 0; i < retVal.Length; i++)
                {

                    // xor
                    retVal[i] = Convert.ToByte(retVal[i] ^ key[keyPointer]);

                    // move the key pointer
                    keyPointer++;
                    if (keyPointer >= key.Length)
                    {
                        keyPointer = 0;
                    }
                }
            }
            catch
            {
                retVal = null;
            }

            return retVal;
        }

        /// <summary>
        /// Gets web content as a byte array
        /// </summary>
        /// <param name="url">URL to retrieve</param>
        /// <returns>a byte array of the content if successful, otherwise null</returns>
        public static byte[] GetWebPage(String url)
        {

            // var init
            byte[] retVal = null;

            try
            {

                // get page
                WebRequest req = WebRequest.Create(url);
                req.Method = "GET";
                using (WebResponse resp = req.GetResponse())
                {
                    using (StreamReader sr = new StreamReader(resp.GetResponseStream()))
                    {
                        retVal = Encoding.ASCII.GetBytes(sr.ReadToEnd());
                    }
                }
            }
            catch
            {
                retVal = null;
            }

            return retVal;
        }
    }
}
