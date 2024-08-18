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
    private int maxHealth = 100; // จำนวนเลือดสูงสุดของผู้เล่น
    private int currentHealth; // จำนวนเลือดปัจจุบันของผู้เล่น

    public Text loseText; // ข้อความที่จะแสดงเมื่อผู้เล่นแพ้
    public Text winText; // ข้อความที่จะแสดงเมื่อผู้เล่นชนะ
    public Text scoreText; // ข้อความที่จะแสดงคะแนน

    private int score = 0; // จำนวนคะแนนเริ่มต้น

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentHealth = maxHealth; // เริ่มต้นด้วยเลือดเต็ม
        loseText.enabled = false; // ซ่อนข้อความแพ้
        winText.enabled = false; // ซ่อนข้อความชนะ

        UpdateScoreText(); // แสดงคะแนนเริ่มต้น
    }

    void Update()
    {
        MoveLeft();
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

        Destroy(gameObject);

        Time.timeScale = 0;
    }

    void PlayerWin()
    {
        winText.text = "You Win!";
        winText.enabled = true;

        Time.timeScale = 0;
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