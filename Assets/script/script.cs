using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class script : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;

    [SerializeField]
    private int forcePower;

    [SerializeField]
    private float xpower;

    [SerializeField]
    private float increment;

    [SerializeField]
    private int maxHealth = 100; // จำนวนเลือดสูงสุดของผู้เล่น
    private int currentHealth; // จำนวนเลือดปัจจุบันของผู้เล่น

    public Text loseText; // ข้อความที่จะแสดงเมื่อผู้เล่นแพ้
    public Text winText; // ข้อความที่จะแสดงเมื่อผู้เล่นชนะ

    // เพิ่มตัวแปรสำหรับการจัดการคะแนน
    public Text scoreText; // ข้อความที่จะแสดงคะแนน
    private int score = 0; // จำนวนคะแนนเริ่มต้น

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentHealth = maxHealth; // เริ่มต้นด้วยเลือดเต็ม
        loseText.enabled = false; // ซ่อนข้อความแพ้
        winText.enabled = false; // ซ่อนข้อความชนะ

        UpdateScoreText(); // แสดงคะแนนเริ่มต้น
    }

    // Update is called once per frame
    void Update()
    {
        MoveLeft();
        // สามารถเพิ่มการจัดการการรับความเสียหายที่นี่ถ้าต้องการ
    }

    public void MoveLeft()
    {
        xpower = Input.GetAxis("Horizontal");
        rb.AddForce(xpower * Vector3.right * forcePower);
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

        // หยุดการอัพเดตเกม
        Time.timeScale = 0;
    }

    void PlayerWin()
    {
        winText.text = "You Win!";
        winText.enabled = true;

        // หยุดการอัพเดตเกม (หรือทำสิ่งอื่น ๆ ตามที่ต้องการ)
        Time.timeScale = 0;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("WinObject"))
        {
            PlayerWin();
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(10); // ลดเลือดลง 10 หน่วยเมื่อชนกับวัตถุที่มี Tag เป็น "Enemy"
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            score += 1; // เพิ่มคะแนน
            UpdateScoreText(); // อัปเดตการแสดงผลคะแนน
            Destroy(other.gameObject); // ทำลายเหรียญ
        }
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString(); // อัปเดตข้อความใน UI
    }
}

