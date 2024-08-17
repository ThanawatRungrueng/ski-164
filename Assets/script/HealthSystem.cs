using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public int maxHealth = 5; // จำนวนเลือดสูงสุดของผู้เล่น
    private int currentHealth; // จำนวนเลือดปัจจุบันของผู้เล่น

    public Text loseText; // ข้อความที่จะแสดงเมื่อผู้เล่นแพ้

    void Start()
    {
        currentHealth = maxHealth; // เริ่มต้นด้วยเลือดเต็ม
        loseText.enabled = false; // ซ่อนข้อความแพ้
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // ลดจำนวนเลือดเมื่อได้รับความเสียหาย

        if (currentHealth <= 0)
        {
            PlayerLose();
        }
    }

    void PlayerLose()
    {
        loseText.text = "You Lose!";
        loseText.enabled = true;

        // ลบผู้เล่นออกจากเกม
        Destroy(gameObject);

        // หยุดการอัพเดตเกม หรือดำเนินการอื่นๆ ที่ต้องการ
        Time.timeScale = 0;
    }
}

