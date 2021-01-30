using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour {

    public float lValue;
    public float rValue;
    public float speed;

    public float timeLeft;
    public float oriTimeLeft;
    private bool up;
    public static bool moving;
    private Vector3 pos;

    // Use this for initialization
    void Start () {
        pos = transform.position;
        moving = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
      
        if (moving)
        {
            Timer();
            Patron();
        }
        else
        {
            transform.position = pos;
            timeLeft = 0;
            up = false;
        }
        
    }

    public void Timer()
    {  
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0 && up == false)
        {
            up = true;
            timeLeft = oriTimeLeft;
        }
        else if (timeLeft < 0 && up == true)
        {
            up = false;
            timeLeft = oriTimeLeft;
        }
    }
    public void Patron()
    {
        if (up)
        {
            transform.position += new Vector3(0, 1, 0) * speed * Time.deltaTime;
        }
        else
        {
            transform.position -= new Vector3(0, 1, 0) * speed * Time.deltaTime;
        }
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == 8)
        {
            moving = true;
        }
    }
}
