using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandCtr : MonoBehaviour
{
    private float speed = 2.0f;
    private const float ScreenHalfWidth = 2.86f;
    // Use this for initialization	
    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.left * speed * Time.deltaTime);
        if (this.transform.position.x <= -ScreenHalfWidth)
        {
            this.transform.Translate(Vector3.right * ScreenHalfWidth * 2);
        }
    }
}
