using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyhole : MonoBehaviour
{
    public float Offset;
    public Animator DoorAnim;
    private void OnCollisionEnter(Collision col)
    {
        if (col.transform.name == "Key")
        {
            col.transform.GetComponent<PickUp>().isHolding = false;
            col.transform.parent = gameObject.transform;
            col.transform.GetComponent<Rigidbody>().isKinematic = true;
            col.transform.rotation = transform.rotation;
            col.transform.position = transform.position + (-Vector3.forward * Offset);
            DoorAnim.SetTrigger("ChangeState");
            DoorAnim.gameObject.GetComponent<Door>().hasKey = true;
            col.gameObject.GetComponent<PickUp>().enabled = false;
        }
    }
}
