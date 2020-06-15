using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsCollected : MonoBehaviour
{
    private CollectibleItems items;
    private GameObject currentobj;
    public bool Chest_Key;
    public bool Blue_Crystal;
    public bool Purple_Crystal;
    public bool Orange_Crystal;
    public bool Green_Crystal;
    public bool Power_Cell;
    public bool Sail;

    private bool CheatMode = false;


 

    public void AquireItem(GameObject test)
    {
        this.GetType().GetField(test.GetComponent<Collectible>().getName()).SetValue(this, true);
        test.SetActive(false);

    }


    public void setobj(GameObject obj) { currentobj = obj; }
    public void UseItem(GameObject item)
    {
        if ((bool)this.GetType().GetField(item.name).GetValue(this) || CheatMode)
        {
            if (item.activeSelf == false)
            {
                item.SetActive(true);
            }
            item.GetComponent<EventTrigger>().TriggerNow();
        }
        else
        {
            Debug.Log("DONT HAVE NECCESARY ITEMS");
        }
    }

    public void DisableItem(GameObject item)
    {
        item.SetActive(false);
    }
    public void EnableItem(GameObject item)
    {
        item.SetActive(true);
    }
}
