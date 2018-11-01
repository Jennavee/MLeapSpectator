using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MLEvent : MonoBehaviour {

    public UnityEvent OnTrigger;

    public void MLTrigger()
    {
        OnTrigger.Invoke();
    }
}
