using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

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
    float Increment;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       
     MoveLeft();
       
    }
    public void MoveLeft()
    {
        xpower = Input.GetAxis("Horizontal");
        rb.AddForce(xpower * Vector3.right * forcePower);
    }
  
 
}
