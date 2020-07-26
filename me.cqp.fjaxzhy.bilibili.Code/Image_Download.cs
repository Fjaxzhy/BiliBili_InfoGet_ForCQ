using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace me.cqp.fjaxzhy.bilibili.Code
{
    public class Image_Download
    {
        public string Image_DL(string Url,string imagename)
        {
            string SaveDirectory,Path=Directory.GetCurrentDirectory()+"\\data\\image\\";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            Stream myResponseStream = response.GetResponseStream();
            Stream stream = new FileStream(Path, FileMode.Create);
            byte[] bArr = new byte[1024];
            int size = myResponseStream.Read(bArr, 0, bArr.Length);
            while (size > 0)
            {
                stream.Write(bArr, 0, size);
                size = myResponseStream.Read(bArr, 0, bArr.Length);
            }
            stream.Close();
            myResponseStream.Close();
            SaveDirectory = Path+imagename;
            return SaveDirectory;
        }
    }
}
