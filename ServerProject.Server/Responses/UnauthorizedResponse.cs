using ServerProject.Server.HTTP_Request;

namespace ServerProject.Server.Responses
{
    public class UnauthorizedResponse : Response
    {
        public UnauthorizedResponse()
            : base(StatusCode.Unauthorized)
        {
        }
    }
}