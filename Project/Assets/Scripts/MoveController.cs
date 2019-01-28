using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[yl] TODO 考虑是否只移动背景或只移动小车?若地块动小车没有必要动
public class MoveController : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed = 1;
    public float HorizontalMaxSpeed = 5;
    public float HorizontalMinSpeed = 1;
    private float hForce;
    private float vForce = 1;

    public float goundY = -0.47f;  //车轮在地面时所处位置
    public float velocityY = 5;
    public float jumpForce = 10;
    public float gravity = 10;
    public float carUpSpeed = 0f;
    public const float initUpSpeed = 5; // m/s
    private bool hasPressedJumpButton = false;

    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    //void Update()
    //{
    //    MoveControl();
    //}

    private void FixedUpdate()
    {
        this.Jump();
        this.CarMove();
    }

    private void MoveControl()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        //Debug.Log(h.ToString() + "........." + v.ToString());

        hForce += h * 0.01f;
        if (hForce < HorizontalMinSpeed)
            hForce = HorizontalMinSpeed;
        else if (hForce > HorizontalMaxSpeed)
            hForce = HorizontalMaxSpeed;
        rb.MovePosition(transform.position + Vector3.right * hForce * speed * Time.deltaTime);
    }

    private bool IsOnGround()
    {
        if (this.transform.position.y <= goundY)
            return true;
        return false;
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.hasPressedJumpButton = true;
            if (IsOnGround())
                carUpSpeed = initUpSpeed;
        }
        else
        {
            this.hasPressedJumpButton = false;
        }
        if (hasPressedJumpButton || !IsOnGround())
        {
            var deltaTime = Time.deltaTime;
            var upHeight = carUpSpeed * deltaTime - gravity * deltaTime * deltaTime * 0.5f;
            this.transform.Translate(0, upHeight, 0);
            carUpSpeed -= gravity * deltaTime;
        }
        else
        {
            carUpSpeed = 0f;
        }
    }

    private void CarMove()
    {
        
        
    }
}
