using System.Text;

namespace Find.By.Server
{
    internal class Response
    {
        public byte[] Generate(Locator locator)
        {
            return BuildResponce(Status.Ok, locator.By.ToString(), locator.Value);
        }

        public byte[] Empty
        {
            get { return BuildResponce(Status.Empty, string.Empty, string.Empty); }
        }

        private byte[] BuildResponce(Status status, string by, string value)
        {
            StringBuilder responce = new StringBuilder();
            responce.AppendLine("HTTP/1.1 200 OK");
            responce.AppendLine("Content-Type: application/json");
            responce.AppendLine();
            responce.AppendLine(string.Format("{{\"Status\":\"{0}\",\"By\":\"{1}\", \"Value\": \"{2}\"}}", status.Value, by, value));
            return Encoding.UTF8.GetBytes(responce.ToString());
        }
    }
}