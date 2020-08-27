using System;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace SB.Common.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public static class StringCompressor
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string CompressString(string text)
        {
            var buffer = Encoding.UTF8.GetBytes(text);
            var base64Encoded = Convert.ToBase64String(buffer);

            buffer = Encoding.UTF8.GetBytes(base64Encoded);
            var memoryStream = new MemoryStream();

            using (var gZipStream = new GZipStream(memoryStream, CompressionMode.Compress, true))
                gZipStream.Write(buffer, 0, buffer.Length);

            memoryStream.Position = 0;
            var compressedData = new byte[memoryStream.Length];
            memoryStream.Read(compressedData, 0, compressedData.Length);

            var gZipBuffer = new byte[compressedData.Length + 4];
            Buffer.BlockCopy(compressedData, 0, gZipBuffer, 4, compressedData.Length);
            Buffer.BlockCopy(BitConverter.GetBytes(buffer.Length), 0, gZipBuffer, 0, 4);

            return Convert.ToBase64String(gZipBuffer);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="compressedText"></param>
        /// <returns></returns>
        public static string DecompressString(string compressedText)
        {
            var gZipBuffer = Convert.FromBase64String(compressedText);

            var memoryStream = new MemoryStream();
            var dataLength = BitConverter.ToInt32(gZipBuffer, 0);
            memoryStream.Write(gZipBuffer, 4, gZipBuffer.Length - 4);

            var buffer = new byte[dataLength];
            memoryStream.Position = 0;

            var gZipStream = new GZipStream(memoryStream, CompressionMode.Decompress);
            gZipStream.Read(buffer, 0, buffer.Length);
            gZipStream.Dispose();

            memoryStream.Dispose();
            var base64Text = Encoding.UTF8.GetString(buffer);
            buffer = Convert.FromBase64String(base64Text);

            return Encoding.UTF8.GetString(buffer);
        }
    }
}
