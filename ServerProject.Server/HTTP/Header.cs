using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServerProject.Server.Common;

namespace ServerProject.Server.HTTP
{
    public class Header
    {
        public const string ContentType = "Content-Type";
        public const string ContentLength = "Content-Length";
        public const string ContentDisposition = "Content-Disposition";
        public const string Cookie = "Cookie";
        public const string Date = "Date";
        public const string Location = "Location";
        public const string Server = "Server";
        public const string SetCookie = "Set-Cookie";

        public Header(string name, string value)
        {
            Guard.AgainstNull(name, nameof(name));
            Guard.AgainstNull(value, nameof(value));
            Name = name;
            Value = value;
        }

        public string Name { get; init; }
        public string Value { get; set; }
        public override string ToString()
        {
            return $"{Name}: {Value}";
        }
    }

    public class InnerHeader
    {
        public string Name { get; }
        public string Value { get; set; }

        public InnerHeader(string name, string value)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Header name must not be null or empty.", nameof(name));
            }

            Name = name;
            Value = value ?? string.Empty;
        }

        public override string ToString()
        {
            return $"{Name}: {Value}";
        }
    }

    public sealed class HTTPRequestHeader
    {
        public string Name { get; }
        public string Value { get; set; }

        public HTTPRequestHeader(string name, string value)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Header name must not be null or whitespace.", nameof(name));
            }

            Name = name;
            Value = value ?? string.Empty;
        }

        public override string ToString()
        {
            return $"{Name}: {Value}";
        }
    }
}



namespace ServerProject.Server.HTTP_Request
{
    public sealed class Header
    {
        public string Name { get; }
        public string Value { get; set; }

        public Header(string name, string value)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Header name must not be null or whitespace.", nameof(name));
            }

            Name = name;
            Value = value ?? string.Empty;
        }

        public override string ToString()
        {
            return $"{Name}: {Value}";
        }
    }
}