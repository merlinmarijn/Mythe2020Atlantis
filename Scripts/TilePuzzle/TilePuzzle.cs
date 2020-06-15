using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilePuzzle : MonoBehaviour
{
    public bool CorrectTile;
    private void OnCollisionEnter(Collision collision)
    {
        if (CorrectTile && collision.transform.tag=="Player")
        {
            Debug.Log("test");
        } else { Debug.Log("Test2"); }
    }

    private void OnCollisionExit(Collision collision)
    {
        
    }
}
