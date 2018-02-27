using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textView : MonoBehaviour {

	public Text IndText;

	// Use this for initialization
	void Start () {

		IndText.text = "WAITING FOR EXTERNAL CONNECTION";
				
	}
	
	// Update is called once per frame
	void Update () {

		IndText.text = UDPServer.recvStr;
		
	}
}
