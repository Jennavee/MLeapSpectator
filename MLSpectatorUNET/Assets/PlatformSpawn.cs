using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawn : MonoBehaviour
{

    public GameObject MagicLeapSettings;
    public GameObject iOSSettings;

    int buildIndex;

    // Use this for initialization
    void Awake()
    {


    }

    public void SpawnSettings()
    {

#if UNITY_IOS
        buildIndex = 1;

#endif

#if PLATFORM_LUMIN || UNITY_EDITOR
        buildIndex = 0;
#endif


        GameObject settings;

        if (buildIndex == 1)
        {
            settings = Instantiate(iOSSettings, Vector3.zero, Quaternion.identity);

        }
        else
        {
            settings = Instantiate(MagicLeapSettings, Vector3.zero, Quaternion.identity);
        }

        settings.BroadcastMessage("InititializeHUD", SendMessageOptions.DontRequireReceiver);
    }

	
}
