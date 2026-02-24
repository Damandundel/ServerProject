using ServerProject.Server.HTTP;
using ServerProject.Server.HTTP_Request;

namespace ServerProject.Server.Responses
{
    public class HtmlResponse : ContentResponse
    {
        public HtmlResponse(string html,
            Action<Request, Response> preRenderAction = null)
            : base(html, ContentType.Html, preRenderAction)
        {
        }
    }
}