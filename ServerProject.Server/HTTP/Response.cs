using System;
using System.Text;

namespace ServerProject.Server.HTTP_Request
{
    public class Response
    {
        public StatusCode StatusCode { get; init; }
        public HeaderCollection Headers { get; } = new HeaderCollection();
        public string Body { get; set; }
        public Action<Request, Response> PreRenderAction { get; protected set; }

        public Response(StatusCode statusCode)
        {
            this.StatusCode = statusCode;

    
            this.Headers.Add("Server", "My Web Server");
            this.Headers.Add("Date", $"{DateTime.UtcNow:r}");
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine($"HTTP/1.1 {(int)this.StatusCode} {this.StatusCode}");
            foreach (var header in this.Headers)
            {
                result.AppendLine(header.ToString());
            }
            result.AppendLine();
            if (!string.IsNullOrWhiteSpace(this.Body))
            {
                result.Append(this.Body);
            }
            return result.ToString();
        }
    }
}