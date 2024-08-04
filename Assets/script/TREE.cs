using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TREE : MonoBehaviour
{
    private MeshRenderer rd;
        public void Start()
    {
        rd = GetComponent<MeshRenderer>();  
    }
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        rd.material.color = Color.red;
        script player = collision.gameObject.GetComponent<script>();
        player.HP -= 15;

      //  Main_UI.instance.ShowNotiText("baby don't hurt me"+player.HP);
      Main_UI.instance.ShowNotiText($"Hurt-15\n HP:{player.HP}");
        if (player.HP <= 0)
        {
            player.HP = 0;
            Main_UI.instance.ShowNotiText("died");
        }    
    }
    private void OnCollisionExit(Collision collision)
    {
        rd.material.color = new Color32(152, 76, 2, 255);
    }
}
