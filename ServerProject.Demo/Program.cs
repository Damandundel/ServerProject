using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using ServerProject.Server;
using ServerProject.Server.HTTP;
using ServerProject.Server.Responses;


namespace ServerProject.Demo
{
    internal class Program
    {

        private const string DownloadForm = @"<form action='/content' method='POST'>
   <input type='submit' value ='Download Sites Content' /> 
</form>";


        private static string Filename = "content.txt";

        private static void AddFormDataAction(Request request, Response response)
        {
            response.Body = string.Empty;

            foreach (var (key, value) in request.FormData)
            {
                response.Body += $"{key} - {value}";
                response.Body += Environment.NewLine;
            }
        }

        static async Task Main(string[] args)
        {

            await DownloadSitesAsTextFile(Filename, new string[]
            {
                "https://www.aboutyou.com",
                "https://www.softuni.bg",
                "https://www.youtube.com",
                "https://www.frogonaquest.com"
            });
            var server = new HttpServer(x =>
            x.MapGet("/html", new HtmlResponse("<h1 style=\"color:blue;\">Hello from my html response</h1>"))
            .MapGet("/store", new HtmlResponse(Home.Html))
            .MapGet("/redirect", new ix("https://github.com/"))
            .MapGet("/login", new HtmlResponse(Form.Html))
            .MapPost("/login", new TextResponse("", AddFormDataAction))
            .MapGet("/content", new HtmlResponse(DownloadForm))
            .MapPost("/content", new TextFileRepsonse(Filename)));
            await server.Start();
        }

        private static async Task<string> DownloadWebSiteContent(string url)
        {
            using var client = new HttpClient();
            var response = await client.GetAsync(url);
            var html = await response.Content.ReadAsStringAsync();
            return html;
        }

        private static async Task DownloadSitesAsTextFile(string filename, string[] urls)
        {
            var downloads = new List<Task<string>>();

            foreach (var url in urls)
            {
                downloads.Add(DownloadWebSiteContent(url));
            }

            var responses = await Task.WhenAll(downloads);

            var responsesString = string.Join(Environment.NewLine + new string('-', 100), responses);

            await File.WriteAllTextAsync(filename, responsesString);
        }
    }
}

namespace ServerProject.Server.HTTP
{
    public class Request
    {
        public Request()
        {
            FormData = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        }

      
        public IDictionary<string, string> FormData { get; }
    }
}

namespace ServerProject.Server.Responses
{
  
    public class Response
    {
        public Response()
        {
            Body = string.Empty;
            ContentType = "text/plain; charset=utf-8";
        }

        public string Body { get; set; }
        public string ContentType { get; set; }
    }
}