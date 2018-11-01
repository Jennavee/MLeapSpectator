using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LoadIn : MonoBehaviour {

    public NetControl net;

    public Renderer ind;

	// Use this for initialization
	void Start () {


		
	}

    private void OnDestroy()
    {
    }

    // Update is called once per frame
    void Update () {

        if(Input.GetKeyDown(KeyCode.B))
        {
            net.StartClient();
            
        }
		
	}
}
