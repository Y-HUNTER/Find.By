using System.Dynamic;
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
            responce.AppendLine(string.Format("{{\"Status\":\"{0}\",\"By\":\"{1}\", \"Value\": \"{2}\"}}", status.Value, by, value));
            return Encoding.UTF8.GetBytes(responce.ToString());
        }
    }

    class Status
    {
        public string Value { get; private set; }

        public static Status Ok 
        {
            get
            {
                return new Status() {Value = "Ok"};
            }
        }

        public static Status Empty
        {
            get
            {
                return new Status() {Value = "Empty"};
            }
        }

        public override string ToString()
        {
            return Value;
        }
    }
}