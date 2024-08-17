using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public int maxHealth = 5; // �ӹǹ���ʹ�٧�ش�ͧ������
    private int currentHealth; // �ӹǹ���ʹ�Ѩ�غѹ�ͧ������

    public Text loseText; // ��ͤ��������ʴ�����ͼ�������

    void Start()
    {
        currentHealth = maxHealth; // ������鹴������ʹ���
        loseText.enabled = false; // ��͹��ͤ�����
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

        // ��ش����Ѿവ�� ���ʹ��Թ������� ����ͧ���
        Time.timeScale = 0;
    }
}

