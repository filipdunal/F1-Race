using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steering : MonoBehaviour
{
    Rigidbody2D rb;
    public float originalSpeedForce = 0f;
    public float speedForce; //15f
    float breakForce; 
    public float torqueForce; //-200f

    float driftFactor; //1f
    public float driftFactorSticky; //0.9f
    public float driftFactorSlippy; //1f;
    public float minSlippyVelocity; //1.5f

    void Start()
    { 
        originalSpeedForce = speedForce;
        rb = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        driftFactor = driftFactorSticky;
        if (RightVelocity().magnitude > minSlippyVelocity)
        {
            driftFactor = driftFactorSlippy;
        }
        //Debug.Log(System.Math.Round(RightVelocity().magnitude,2));


        rb.velocity = ForwardVelocity() + RightVelocity() * driftFactor;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(transform.up*speedForce);
        }
        if(Input.GetKey(KeyCode.DownArrow))
        {
            rb.AddForce(transform.up * -speedForce / 2f);
        }

        float tf = Mathf.Lerp(0, -torqueForce, rb.velocity.magnitude / 2);
        rb.angularVelocity = Input.GetAxis("Horizontal") * tf;

        Vector2 RightVelocity()
        {
            return transform.right * Vector2.Dot(rb.velocity, transform.right);
        }

        Vector2 ForwardVelocity()
        {
            return transform.up*Vector2.Dot(rb.velocity,transform.up);
        }

        


    }
}
