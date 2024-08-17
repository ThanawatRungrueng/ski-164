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
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentHealth = maxHealth; // ������鹴������ʹ���
        loseText.enabled = false; // ��͹��ͤ�����
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
            TakeDamage(1); // Ŵ���ʹŧ 10 ˹�������ͪ��Ѻ�ѵ�ط���� Tag �� "Enemy"
        }
    }
}