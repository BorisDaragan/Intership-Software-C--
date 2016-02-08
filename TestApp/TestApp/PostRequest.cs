using System;
using System.IO;
using System.Net;

namespace RandomOrgApi
{
    class PostRequest
    {
        private string url;
        private string jsonContent;
        public PostRequest(string inpUrl, string inpJsonContent)
        {
            url = inpUrl;
            jsonContent = inpJsonContent;
        }

        public string SimplePOST()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";

            System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
            Byte[] byteArray = encoding.GetBytes(jsonContent);

            request.ContentLength = byteArray.Length;
            request.ContentType = @"application/json";
            try
            {
                using (Stream dataStream = request.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);
                }
            }
            catch (Exception ex)
            {
                return "404";
            }

            long length = 0;
            string responseText = "";
            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    length = response.ContentLength;
                    WebHeaderCollection header = response.Headers;

                    using (var reader = new System.IO.StreamReader(response.GetResponseStream()))
                    {
                        responseText = reader.ReadToEnd();
                    }
                }
                return responseText;
            }
            catch (WebException ex)
            {
                return "404";
            }

            return responseText;
        }
    }
}
