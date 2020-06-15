using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EventTrigger))]
public class WalkTiles : MonoBehaviour
{
    public bool goodTile = false;
    public Animator anim;


    private void OnTriggerEnter(Collider col)
    {
        if (col.transform.tag == "Player" && goodTile)
        {
            anim.SetTrigger("Down");
        } else 
        if (col.transform.tag == "Player" && !goodTile)
        {
            GetComponent<EventTrigger>().TriggerNow();
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.transform.tag == "Player")
        {
            anim.SetTrigger("Up");

        }
    }
}
