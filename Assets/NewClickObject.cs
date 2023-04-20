using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class NewClickObject : MonoBehaviour, IActionableObject
{
    [DllImport("__Internal")]
    private static extern void ObjectClicked(int objectName);
    
    public void OnClickAction()
    {
        Debug.Log("NEW INPUT - Object OnClickAction");
        #if UNITY_WEBGL == true && UNITY_EDITOR == false
            ObjectClicked(1);
        #endif
    }
}
