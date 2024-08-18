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
    private int maxHealth = 100; // �ӹǹ���ʹ�٧�ش�ͧ������
    private int currentHealth; // �ӹǹ���ʹ�Ѩ�غѹ�ͧ������

    public Text loseText; // ��ͤ��������ʴ�����ͼ�������
    public Text winText; // ��ͤ��������ʴ�����ͼ����蹪��

    // �������������Ѻ��èѴ��ä�ṹ
    public Text scoreText; // ��ͤ��������ʴ���ṹ
    private int score = 0; // �ӹǹ��ṹ�������

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentHealth = maxHealth; // ������鹴������ʹ���
        loseText.enabled = false; // ��͹��ͤ�����
        winText.enabled = false; // ��͹��ͤ������

        UpdateScoreText(); // �ʴ���ṹ�������
    }

    // Update is called once per frame
    void Update()
    {
        MoveLeft();
        // ����ö������èѴ��á���Ѻ����������·�����ҵ�ͧ���
    }

    public void MoveLeft()
    {
        xpower = Input.GetAxis("Horizontal");
        rb.AddForce(xpower * Vector3.right * forcePower);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Ŵ�ӹǹ���ʹ��������Ѻ�����������

        if (currentHealth <= 0)
        {
            PlayerLose();
        }
    }

    void PlayerLose()
    {
        loseText.text = "You Lose!";
        loseText.enabled = true;

        // ź�������͡�ҡ��
        Destroy(gameObject);

        // ��ش����Ѿവ��
        Time.timeScale = 0;
    }

    void PlayerWin()
    {
        winText.text = "You Win!";
        winText.enabled = true;

        // ��ش����Ѿവ�� (���ͷ������� � �������ͧ���)
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
            TakeDamage(10); // Ŵ���ʹŧ 10 ˹�������ͪ��Ѻ�ѵ�ط���� Tag �� "Enemy"
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            score += 1; // ������ṹ
            UpdateScoreText(); // �ѻവ����ʴ��Ť�ṹ
            Destroy(other.gameObject); // ���������­
        }
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString(); // �ѻവ��ͤ���� UI
    }
}

