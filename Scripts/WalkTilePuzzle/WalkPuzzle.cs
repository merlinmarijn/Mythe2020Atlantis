using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkPuzzle : MonoBehaviour
{
    public GameObject Player;
    public GameObject RespawnLocation;



    public void Respawn()
    {
        Player.GetComponent<CharacterController>().enabled = false;
        Player.transform.position = RespawnLocation.transform.position;
        Player.GetComponent<CharacterController>().enabled = true;
    }
}
