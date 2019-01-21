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

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveControl();
    }

    private void FixedUpdate()
    {
        //this.ObjJump();
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
        if (this.transform.position.y <= -goundY)
            return true;
        return false;
    }

    private void ObjJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (IsOnGround())
            {
                var rb = this.GetComponent<Rigidbody>();
                rb.velocity += new Vector3(0, velocityY, 0);
                rb.AddForce(Vector3.up * jumpForce);
            }
        }
    }
}
