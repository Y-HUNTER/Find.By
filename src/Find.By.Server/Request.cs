using System.IO;
using System.Net.Sockets;

namespace Find.By.Server
{
    internal class Request
    {
        public Request(Socket socket)
        {
            Stream networkStream = new NetworkStream(socket);
            StreamReader streamReader = new StreamReader(networkStream);
            string request = streamReader.ReadLine();
            networkStream.Close();
        }
    }
}