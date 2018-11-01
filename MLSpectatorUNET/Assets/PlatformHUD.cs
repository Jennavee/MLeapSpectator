using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Net;
using System.Net.Sockets;

public class PlatformHUD : MonoBehaviour {


    public Text ipAddress;
    public Text clientStatus;
    public  NetControl netCon;
    bool hostDiscovered;

    public GameObject ConnectHUD;
    public GameObject StatusHUD;




	// Use this for initialization
	void Start () {


		
	}
    public void InititializeHUD()
    {
        Debug.Log("initialized");
        netCon = NetControl.netControl;
        netCon.HUD = this;
        
    }

    public void StartHost()
    {
        StartCoroutine(BootHost());


    }

    IEnumerator BootHost()
    {
        netCon.discovery.Initialize();
        SetIP(LocalIPAddress());
        yield return new WaitForSecondsRealtime(.4f);
        netCon.StartHost();
        yield return new WaitForSecondsRealtime(.4f);
        netCon.discovery.StartAsServer();
    }

    public void SetIP(string IP)
    {
        netCon.networkAddress = IP;
        ipAddress.text = IP;
    }



    public void StartClientDiscovery()
    {
        if(!hostDiscovered)
        {
            StartCoroutine(BootClient());
            
        }
        else
        {
            netCon.StartClient();
        }

    }


    IEnumerator BootClient()
    {
        netCon.discovery.Initialize();
        yield return new WaitForSecondsRealtime(.4f);
        netCon.discovery.StartAsClient();
    }

    public void DiscoveredHost(string IP)
    {
        hostDiscovered = true;
        Debug.Log("discovered");
        clientStatus.text = "ClientJoin";
        SetIP(IP);

    }

    public static string LocalIPAddress()
    {
        IPHostEntry host;
        string localIP = "0.0.0.0";
        host = Dns.GetHostEntry(Dns.GetHostName());
        foreach (IPAddress ip in host.AddressList)
        {
            if (ip.AddressFamily == AddressFamily.InterNetwork)
            {
                localIP = ip.ToString();
                break;
            }
        }
        return localIP;
    }




}
