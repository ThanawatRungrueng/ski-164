using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int score = 0;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            // เพิ่มคะแนน
            score += 1;

            // ทำลายเหรียญ
            Destroy(other.gameObject);
        }
    }
}

