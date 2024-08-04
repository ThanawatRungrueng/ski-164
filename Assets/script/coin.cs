using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    // Start is called before the first frame upda

    private void OnTriggerEnter(Collider other)
    {
        // ตรวจสอบว่าชนกับผู้เล่น (Player)
     script player = other.GetComponent<script>();
        player.POINT += 10;
        Main_UI.instance.ShowNotiText($"+10\nScroe{player.POINT}");
        Destroy( gameObject );
         
    }
}