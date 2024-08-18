using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  

public class script : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;

    [SerializeField]
    int forcePower;

    [SerializeField]
    private float xpower;

    [SerializeField]
    private int hp = 100;

    [SerializeField]
    private int point = 0;

    [SerializeField]
    public int HP { get { return hp; } set { hp = value; } }

    public int POINT { get { return point; } set { point = value; } }

    [SerializeField]
    private Camera firstPersonCamera; // กล้องมุมมองบุคคลที่หนึ่ง

    [SerializeField]
    private Camera thirdPersonCamera; // กล้องมุมมองบุคคลที่สาม

    private bool isFirstPerson = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        SwitchToThirdPerson(); // เริ่มต้นที่มุมมองบุคคลที่สาม
    }

    void Update()
    {
        MoveLeft();
        CheckRestart();
        CheckHP();
        CheckCameraToggle(); // เพิ่มเพื่อสลับมุมกล้อง
    }

    public void MoveLeft()
    {
        xpower = Input.GetAxis("Horizontal");
        rb.AddForce(xpower * Vector3.right * forcePower);
    }

    private void CheckRestart()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void CheckHP()
    {
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    // ตรวจสอบการกดปุ่ม "V" เพื่อสลับมุมกล้อง
    private void CheckCameraToggle()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            isFirstPerson = !isFirstPerson;

            if (isFirstPerson)
            {
                SwitchToFirstPerson();
            }
            else
            {
                SwitchToThirdPerson();
            }
        }
    }

    private void SwitchToFirstPerson()
    {
        firstPersonCamera.enabled = true;
        thirdPersonCamera.enabled = false;
    }

    private void SwitchToThirdPerson()
    {
        firstPersonCamera.enabled = false;
        thirdPersonCamera.enabled = true;
    }
}