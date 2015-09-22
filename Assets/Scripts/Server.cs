using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;

delegate void ClientConnected(TcpClient client);
class Server
{
    TcpListener Server_Listener;
    private bool stop = false;

    public event ClientConnected OnClientConnected;

    public void Start(int port)
    {
        try
        {
            this.Server_Listener = new TcpListener(System.Net.IPAddress.Any, port);
            this.Server_Listener.Start();
            this.Server_Listener.BeginAcceptSocket(OnAsyncClientConnected, this.Server_Listener);
        }
        catch (Exception){}
    }

    public void Stop()
    {
        this.stop = true;
        this.Server_Listener.Stop();
    }

    void OnAsyncClientConnected(IAsyncResult asyncresult)
    {
        if (!this.stop)
        {
            TcpListener listener = (TcpListener)asyncresult.AsyncState;
            TcpClient client = listener.EndAcceptTcpClient(asyncresult);

            if (OnClientConnected != null)
                OnClientConnected(client);

            this.Server_Listener.BeginAcceptTcpClient(OnAsyncClientConnected, this.Server_Listener);
        }
    }
}