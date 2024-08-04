using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Main_UI.instance.ShowNotiText("STUPID WIN");
    }
}
