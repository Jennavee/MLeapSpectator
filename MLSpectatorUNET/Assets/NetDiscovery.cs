using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetDiscovery : NetworkDiscovery {


    NetControl netControl;
	// Use this for initialization
	void Start () {
        netControl = GetComponent<NetControl>();
		
	}
	

    public override void OnReceivedBroadcast(string fromAddress, string data)
    {
        Debug.Log("Heyyy " + fromAddress);
        netControl.HUD.DiscoveredHost(fromAddress);
    }
}
