using UnityEngine;
using System.Collections;
using UnityEngine.XR.MagicLeap;

public class ControllerSync : MonoBehaviour
{

    public Vector3 camOffsetPos;
    public Vector3 camOffsetRot;
    Transform cam;
    // Use this for initialization
    void Start()
    {
        cam = Camera.main.transform;

    }

    // Update is called once per frame
    void Update()
    {
        camOffsetPos = cam.position - transform.position;
        camOffsetRot = cam.eulerAngles - transform.eulerAngles;

    }
}
