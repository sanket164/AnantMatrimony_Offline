using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AnantMatrimony
{
    class ftpUpload
    {
        public string UploadFile(string FilePath, string ftpURL, string ftpUserName, string ftpPassword)
        {
            try
            {
                // Get the object used to communicate with the server.
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpURL); //"ftp://www.mehtainfosoft.com/httpdocs/images");
                request.Method = WebRequestMethods.Ftp.UploadFile;
                //request.Timeout = 600000;
                // Options
                request.UseBinary = true;
                request.UsePassive = false;

                // This example assumes the FTP site uses anonymous logon.
                request.Credentials = new NetworkCredential(ftpUserName, ftpPassword); //"mehtain1", "mehta@123");

                // Copy the contents of the file to the request stream.
                //StreamReader sourceStream = new StreamReader(FilePath);//"testfile.txt");
                //byte[] fileContents = Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());
                //sourceStream.Close();
                //request.ContentLength = fileContents.Length;

                byte[] fileContents = File.ReadAllBytes(FilePath);

                request.ContentLength = fileContents.Length;
                //using (Stream s = request.GetRequestStream())
                //{
                //    s.Write(fileContents, 0, fileContents.Length);
                //}

                Stream requestStream = request.GetRequestStream();
                requestStream.Write(fileContents, 0, fileContents.Length);
                requestStream.Close();

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();

                //Console.WriteLine("Upload File Complete, status {0}", response.StatusDescription);

                response.Close();

                return response.StatusDescription;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string DeleteFile(string ftpURL, string ftpUserName, string ftpPassword)
        {
            try
            {
                // Get the object used to communicate with the server.
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpURL); //"ftp://www.mehtainfosoft.com/httpdocs/images");
                request.Method = WebRequestMethods.Ftp.DeleteFile;

                // Options
                //request.UseBinary = true;
                //request.UsePassive = false;

                // This example assumes the FTP site uses anonymous logon.
                request.Credentials = new NetworkCredential(ftpUserName, ftpPassword); //"mehtain1", "mehta@123");
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();

                response.Close();

                return response.StatusDescription;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
