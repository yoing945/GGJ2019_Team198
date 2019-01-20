using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed = 1;
    public float HorizontalMaxSpeed = 5;
    public float HorizontalMinSpeed = 1;
    private float hForce;
    private float vForce = 1;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveControl();
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
}
