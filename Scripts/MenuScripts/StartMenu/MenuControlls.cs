using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuControlls : MonoBehaviour
{
    public void setSensitivity(float speed)
    {
        GlobalSettings.Sensitivity = speed;
    }
}
