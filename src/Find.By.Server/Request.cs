using System.IO;
using System.Net.Sockets;

namespace Find.By.Server
{
    internal class Request
    {
        private readonly Socket _socket;

        public Request(Socket socket)
        {
            _socket = socket;
            Stream networkStream = new NetworkStream(socket);
            StreamReader streamReader = new StreamReader(networkStream);
            string request = streamReader.ReadLine();
            networkStream.Close();
        }

        public void Send(byte[] responseEmpty)
        {
            _socket.Send(responseEmpty);
        }
    }
}