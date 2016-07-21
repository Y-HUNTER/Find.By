using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Find.By.Core.Logging;

namespace Find.By.Server
{
    public class HostServer
    {
        private const int PORT = 32081;
        private readonly Logger _logger = Logger.GetLogger();
        private bool _isServerRunning;
        private readonly TcpListener _listener = new TcpListener(IPAddress.Parse("127.0.0.1"), PORT);

        private static Locator Locator { get; set; }

        public void Start()
        {
            if (this._isServerRunning) return;
            try
            {
                this._logger.Info("Starting listener...");
                this._isServerRunning = true;
                this._listener.Start();
                Thread thread = new Thread(Service)
                {
                    IsBackground = true
                };
                thread.Start();
            }
            catch (SocketException ex)
            {
                this._logger.Error(ex.Message);
                this._isServerRunning = false;
            }
            catch (Exception ex)
            {
                this._logger.Error(ex.Message);
                this._isServerRunning = true;
            }
        }

        public void ShowLocator(Locator locator)
        {
            Locator = locator;
        }

        private void Service()
        {
            try
            {
                while (this._isServerRunning)
                {
                    Socket socket = this._listener.AcceptSocket();
                    try
                    {
                        Request request = new Request(socket);
                        Response response = new Response();
                        if (Locator == null)
                            socket.Send(response.Empty);
                        else
                            socket.Send(response.Generate(Locator));
                        Locator = null;
                    }
                    catch (Exception ex)
                    {
                        this._logger.Error(ex.Message);
                    }
                    socket.Close();
                }
            }
            catch (Exception ex)
            {
                this._logger.Error(ex.Message);
            }
        }

        public void Stop()
        {
            this._logger.Info("Stopping listener...");
            this._isServerRunning = false;
        }
    }
}