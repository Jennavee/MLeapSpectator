using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;
using UnityEngine.Networking;

public class LoadIn : MonoBehaviour {

    MLInputController controller;
    public NetControl net;

    public Renderer ind;

	// Use this for initialization
	void Start () {
        MLInput.Start();
        controller = MLInput.GetController(0);

        MLInput.OnControllerButtonDown += MLInput_OnControllerButtonDown;


		
	}

    private void OnDestroy()
    {
        MLInput.Stop();
    }

    // Update is called once per frame
    void Update () {

        if(Input.GetKeyDown(KeyCode.B))
        {
            net.StartClient();
            
        }
		
	}

    void MLInput_OnControllerButtonDown(byte arg1, MLInputControllerButton arg2)
    {

        if(arg2 == MLInputControllerButton.Bumper)
        {
            ind.material.color = Color.blue;
            net.StartClient();
        }
    }

}
