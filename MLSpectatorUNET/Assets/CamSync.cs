using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CamSync : MonoBehaviour {


    Transform cam;
	// Use this for initialization
	void Start () {
        cam = Camera.main.transform;
	}
	
	// Update is called once per frame
	void Update () {
        Track();
	}

    void Track()
    {


        if(GetComponent<NetworkIdentity>().hasAuthority)
        {

            transform.position = cam.position;
            transform.rotation = cam.rotation;
        }
    }

}
