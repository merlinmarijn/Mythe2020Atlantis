using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractRay : MonoBehaviour
{
    private Interactible LastObject;
    private void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, 4))
        {

            Debug.DrawLine(ray.origin, ray.origin + ray.direction * 4, Color.red);
           if(hitInfo.collider.gameObject.GetComponent<Interactible>()){
                if (Input.GetKeyDown(KeyCode.E)){
                   hitInfo.collider.gameObject.GetComponent<Interactible>().InvokeAction1();
               }
                if (Input.GetMouseButtonDown(0))
                {
                    hitInfo.collider.gameObject.GetComponent<Interactible>().InvokeAction2();
                }
                if (Input.GetMouseButtonDown(1))
                {
                    hitInfo.collider.gameObject.GetComponent<Interactible>().InvokeAction3();
                }

                //Checks if lastobject is empty
                if (LastObject == null)
                {
                    LastObject = hitInfo.transform.GetComponent<Interactible>();
                    LastObject.EnableLookAt();
                }

                //If lastobject isnt currently hit object and lastobject isnt null
                if (LastObject != hitInfo.transform.GetComponent<Interactible>() && LastObject!=null)
                {
                    LastObject = hitInfo.transform.GetComponent<Interactible>();
                    LastObject.EnableLookAt();
                }

            }
           //Check if lastobject = true and has interactible
            if (LastObject && !hitInfo.collider.gameObject.GetComponent<Interactible>())
            {
                LastObject.DisableLookAt();
                LastObject = null;
            }
        }
        else
        {
            //if hitting nothing en lastobject is set
            if (LastObject != null)
            {
                LastObject.DisableLookAt();
                LastObject = null;
            }
            Debug.DrawLine(ray.origin, ray.origin + ray.direction * 4, Color.green);
        }
    }
}
