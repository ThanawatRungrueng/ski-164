using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TREE : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        script player = collision.gameObject.GetComponent<script>();
        player.HP -= 15;

        Main_UI.instance.ShowNotiText("baby don't hurt me"+player.HP);
        if (player.HP <= 0)
        {
            player.HP = 0;
            Main_UI.instance.ShowNotiText("you gay");
        }    
       
    }
}
