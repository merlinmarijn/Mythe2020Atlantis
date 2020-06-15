using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Interactible))]
public class PickUp : MonoBehaviour{

    public bool isHolding = false;
    public bool isInspecting = false;
    private float inspectRotateSpeed = 5;
    [SerializeField]
    private float ThrowForce = 10f;



    void Update(){
        if(!isInspecting && isHolding){
            transform.eulerAngles = Camera.main.transform.eulerAngles;
        }
        if (isInspecting && isHolding)
        {
            float xAxis = Input.GetAxis("Mouse X") * inspectRotateSpeed;
            float yAxis = Input.GetAxis("Mouse Y") * inspectRotateSpeed;

            transform.Rotate(Vector3.up, -xAxis, Space.World);
            transform.Rotate(Vector3.right, yAxis, Space.World);
        }
        else if (isHolding)
        {
            transform.position = Camera.main.transform.position + Camera.main.transform.forward * 4;

            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }

    public void pick_up(){
        if(!isHolding){
            isHolding = true;
            gameObject.GetComponent<Rigidbody>().useGravity = false;
        }else{
            isHolding = false;
            gameObject.GetComponent<Rigidbody>().useGravity = true;
        }
        if (isInspecting)
        {
            Inspect();
        }
    }

    public void Throw(){
        if(isHolding&&!isInspecting){
            isHolding = false;
            gameObject.GetComponent<Rigidbody>().useGravity = true;
            gameObject.GetComponent<Rigidbody>().AddForce(transform.rotation * Vector3.forward * ThrowForce, ForceMode.Impulse);
        }
    }

    public void Inspect(){
        MouseLook Cam = Camera.main.gameObject.GetComponent<MouseLook>();
        if (!isInspecting && isHolding)
        {
            isInspecting = true;
            Cam.canRotate = false;
            GetComponent<Rigidbody>().isKinematic = true;
        } else
        {
            isInspecting = false;
            Cam.canRotate = true;
            GetComponent<Rigidbody>().isKinematic = false;
        }
    }

}
