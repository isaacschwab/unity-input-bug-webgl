using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class OldInputClick : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void ObjectClicked(int objectName);
    public void OnMouseUpAsButton()
    {
        Debug.Log("OLD INPUT - OnMouseUpAsButton");
        #if UNITY_WEBGL == true && UNITY_EDITOR == false
                    ObjectClicked(0);
        #endif
    }
}
