using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class CursorController : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void ObjectClicked(string objectName);
    
    private Controls controls;
    private Camera mainCamera;
    private void Awake()
     {
         controls = new Controls();
         controls.Mouse.Click.started += _ => StartedClick();
         controls.Mouse.Click.performed += _ => EndedClick();
         mainCamera = Camera.main;
     }
    
    private void OnEnable()
     {
         controls.Enable();
     }

     private void OnDisable()
     {
         controls.Disable();
     }

     private void StartedClick()
     {
         
     }

     private void EndedClick()
     {
         Debug.Log("NEW INPUT - Click");
         DetectObject();
     }

     private void DetectObject()
     {
         Ray ray = mainCamera.ScreenPointToRay(controls.Mouse.Position.ReadValue<Vector2>());
         RaycastHit hit;
         if (Physics.Raycast(ray, out hit))
         {
             if(hit.collider != null) 
             {
                 Debug.Log("NEW INPUT - 3D Hit: " + hit.collider.tag);
                 IActionableObject actionable = hit.collider.GetComponent<IActionableObject>();
                 if (actionable != null) actionable.OnClickAction();
             }
         }
     }
}
