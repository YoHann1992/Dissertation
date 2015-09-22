using UnityEngine;
using System.Collections;

public class Networking : MonoBehaviour 
{
    private Server TCPServer = null;

    private string posdata;
    private string message;

	// Use this for initialization
	void Start () 
    {
        //Fire up Server and subscribe to client connection event
        this.TCPServer = new Server();
        this.TCPServer.Start(60001);
        this.TCPServer.OnClientConnected += TCPServer_OnClientConnected;
	
	}

    private void TCPServer_OnClientConnected(System.Net.Sockets.TcpClient client)
    {
        throw new System.NotImplementedException();
    }
	
	// Update is called once per frame
	void Update () 
    {
	
	}
}
