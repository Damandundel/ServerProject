using ServerProject.Server.HTTP_Request;

namespace ServerProject.Server.Responses
{
    public class BadRequestResponse : HTTP_Request.Response
    {
        public BadRequestResponse()
            : base(StatusCode.BadRequest)
        {
        }
    }
}