using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 6f;
    public float dashspeed = 5f;
    public int maxDashStack = 3;
    public int dashStack;
    
    public float dashCooltime = 2.3f;
    private float dashCoolDawn = 0f;

    public float maxDashTime = 0.1f;
    private float dashTime = 0f;
    
    private bool isDash = false;

    private void Start()
    {
        dashStack = maxDashStack;
        dashCoolDawn = dashCooltime;
    }
    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 dir = Vector3.right * h + Vector3.up * v;

        
        
        if (dashStack > 0 && Input.GetKeyDown(KeyCode.LeftShift))
        {
            dashStack -= 1;
            isDash = true;

        }
        if (isDash)
        {
            transform.position += dir * (speed * dashspeed) * Time.deltaTime;
            dashTime += Time.deltaTime;
        }
        else
        {
            //transform.Translate(dir * speed * Time.deltaTime);
            transform.position += dir * speed * Time.deltaTime;
        }

        if (dashTime >= maxDashTime)
        {
            dashTime = 0;
            isDash = false;
        }

        if (dashCoolDawn > 0f && dashStack != maxDashStack)
        {
            dashCoolDawn -= Time.deltaTime;
        }

        if (dashStack < maxDashStack && dashCoolDawn <= 0f)
        {       
            dashCoolDawn = dashCooltime;
            dashStack += 1;
        }
    }
    public void PlayerDash()
    {

    }

}
