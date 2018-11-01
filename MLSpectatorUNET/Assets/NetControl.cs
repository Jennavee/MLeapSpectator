using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetControl : NetworkManager {

    public static NetControl netControl;
    public PlatformSpawn spawn;

    [HideInInspector]
    public NetDiscovery discovery;
    public PlatformHUD HUD;

	// Use this for initialization
	void Awake () {

        if(netControl == null)
        {
            netControl = this;
        }
        SetUpDiscovery();
        spawn.SpawnSettings();
		
	}

    void SetUpDiscovery()
    {
        discovery = GetComponent<NetDiscovery>();
        discovery.Initialize();
        
    }

	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.A))
        {
            OnServerSceneChanged("SampleScene3");
        }
		
	}


    public override void OnServerSceneChanged(string sceneName)
    {
        Debug.Log("swapping scene");
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }


}
