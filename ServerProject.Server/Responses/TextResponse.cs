using ServerProject.Server.HTTP;
using ServerProject.Server.HTTP_Request;

namespace ServerProject.Server.Responses
{
    public class TextResponse : ContentResponse
    {
        public TextResponse(string text,
            Action<Request, Response> preRenderAction = null)
             : base(text, ContentType.PlainText, preRenderAction)
        {
        }
    }
}