using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ServerProject.Server.HTTP;
using ServerProject.Server.HTTP_Request;

namespace ServerProject.Server.Responses
{
    public class TextFileRepsonse : Response
    {
        public TextFileRepsonse(string filename)
            : base(StatusCode.OK)
        {
            Filename = filename;
            Headers.Add(ServerProject.Server.HTTP.Header.ContentType, ContentType.PlainText);
        }

        public string Filename { get; init; }


        public override string ToString()
        {

            if (File.Exists(Filename))
            {
                Body = File.ReadAllText(Filename);
                var byteCount = new FileInfo(Filename).Length;
                Headers.Add(ServerProject.Server.HTTP.Header.ContentDisposition, $"attachment; filename=\"{Filename}\"");
                Headers.Add(ServerProject.Server.HTTP.Header.ContentLength, byteCount.ToString());
            }
            return base.ToString();
        }
    }
}