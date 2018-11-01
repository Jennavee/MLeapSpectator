using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if PLATFORM_LUMIN
using UnityEngine.XR.MagicLeap;
#endif
using UnityEngine.UI;

public class MLMenuControl : MonoBehaviour
{

#if PLATFORM_LUMIN
    public GameObject selectedTarg;
    int buttonInd;
    public GameObject[] buttons;
    GameObject curObj;

    MLInputController controller;



    // Use this for initialization
    void Awake()
    {




        MLInput.Start();



        controller = MLInput.GetController(0);
        MLInput.OnTriggerDown += SelectTrigger;
        MLInput.OnControllerTouchpadGestureStart += SetButton;
        MLInput.OnControllerTouchpadGestureContinue += SetButton;



    }
    private void OnDestroy()
    {
        MLInput.Stop();

    }





    void SelectTrigger(byte controllerId, float val)
    {

        if (selectedTarg != null)
        {
            selectedTarg.SendMessage("MLTrigger", SendMessageOptions.DontRequireReceiver);
        }

    }






    void SetButton(byte action, MLInputControllerTouchpadGesture gesture)
    {
        Debug.Log("getsure");
        if (gesture.Direction == MLInputControllerTouchpadGestureDirection.Left)
        {
            buttonInd--;
            if (buttonInd < 0)
            {
                buttonInd = buttons.Length - 1;
            }
            SelectTarget(buttons[buttonInd]);


        }
        else if (gesture.Direction == MLInputControllerTouchpadGestureDirection.Right)
        {
            buttonInd++;
            if (buttonInd > buttons.Length - 1)
            {
                buttonInd = 0;
            }
            SelectTarget(buttons[buttonInd]);


        }

    }

    void SelectTarget(GameObject obj)
    {

        if (selectedTarg != null)
        {
            selectedTarg.GetComponent<Image>().color = Color.white;
        }


        selectedTarg = obj.gameObject;
        selectedTarg.GetComponent<Image>().color = Color.green;

    }
#endif
}
