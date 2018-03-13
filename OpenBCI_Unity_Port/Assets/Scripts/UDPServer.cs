using UnityEngine;  
using System.Collections;  
using System.Net;  
using System.Net.Sockets;  
using System.Text;  
using System.Threading;  
using UnityEngine.UI;

public class UDPServer : MonoBehaviour  
{  
	public string ipAddress = "127.0.0.1";  
	public int ConnectPort = 12345;  
	public static string recvStr;
	public static float arosualValue;
	public static float valenceValue;
	public static bool railed;

	Socket socket;  
	EndPoint clientEnd;  
	IPEndPoint ipEnd;  

	byte[] recvData = new byte[1024];  

	int recvLen;  
	Thread connectThread;  
	//初始化  
	void InitSocket()  
	{  
		ipEnd = new IPEndPoint(IPAddress.Parse(ipAddress), ConnectPort);  
		socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);  
		socket.Bind(ipEnd);  
		//定义客户端  
		IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);  
		clientEnd = (EndPoint)sender;  
		print("UDP_WAITING FOR CONNECTION");  
		//开启一个线程连接  
		connectThread = new Thread(new ThreadStart(SocketReceive));  
		connectThread.Start();  
		arosualValue = 0.1f;
		valenceValue = 0.1f;
		railed = false;
	}  

	void SocketReceive()  
	{  
		while (true)  
		{  
			recvData = new byte[1024];  
			recvLen = socket.ReceiveFrom(recvData, ref clientEnd);
			recvStr = Encoding.UTF8.GetString(recvData, 0, recvLen);  
			string[] tempArray = recvStr.Split (',');

			if (float.Parse (tempArray [0]) * float.Parse (tempArray [1]) < 0.0000001f) {
			
				railed = true;
				Debug.Log ("railed, please adjust the headset");
			
			} else {
				
				railed = false;
				arosualValue = float.Parse(tempArray [0]);
				valenceValue = float.Parse(tempArray [1]);
				Debug.Log("Arosual = " + arosualValue + ", Valence = " + valenceValue);
						
			}

		}  
	}  

	//连接关闭  
	void SocketQuit()  
	{  
		//关闭线程  
		if (connectThread != null)  
		{  
			connectThread.Interrupt();  
			connectThread.Abort();  
		}  
		//最后关闭socket  
		if (socket != null)  
			socket.Close();  
		Debug.LogWarning("断开连接");  
	}  

	// Use this for initialization  
	void Start()  
	{  	
		recvStr = "";
		InitSocket(); //在这里初始化server  
	}  

	void OnApplicationQuit()  
	{  
		SocketQuit();  
	}  

}  