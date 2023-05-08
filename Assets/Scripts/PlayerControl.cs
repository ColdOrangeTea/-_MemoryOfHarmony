using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed = 5.0f;
    // public float jumpForce = 5;
    // public bool isOnGround = true;
    private float horizontalInput;
    private float forwardInput;
    // public CharacterController cc;
    public Rigidbody playerRb;

    void Start()
    {
        // cc = GetComponent<CharacterController>();
        playerRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (GameMenuControl.isOpenGameMenu == true) return;
        Move();
    }

    void FixUpdate()
    {
        // if (GameMenuControl.isOpenGameMenu == true) return;
        // Move();
    }

    void Move()
    {
        // 玩家輸入
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        // 玩家向前走
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 10.0f;
        }
        else
        {
            speed = 5.0f;
        }

        // //跳
        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     if (isOnGround)
        //     {
        //     playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        //     isOnGround = false;                
        //     }
        // }
    }
}
