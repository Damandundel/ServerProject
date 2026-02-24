using ServerProject.Server.HTTP_Request;

namespace ServerProject.Server.Responses
{
    public class NotFoundResponse : Response
    {
        public NotFoundResponse()
            : base(StatusCode.NotFound)
        {
        }
    }
}