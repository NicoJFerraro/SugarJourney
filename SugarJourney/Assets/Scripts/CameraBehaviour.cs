using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraBehaviour : MonoBehaviour
{    
    //Variables
    public float speed;
    bool movement;
    public Transform pj;
    // Use this for initialization
    void Start()
    {
        movement = true;
        transform.position = new Vector3(0, pj.position.y, -10);
    }

    // Update is called once per frame
    void Update()
    {
        if (!Character.sMC)
        {
            CamFollow();
        }
        else if (Character.sMC && pj != null)
        {
            transform.position = new Vector3(0, pj.position.y,-10);
        }
    }
    void CamFollow()
    {
        if (Main1.uCAttack)
        {
            transform.position = new Vector3(0, 135.0263f, -10);
        }
        if (this.gameObject.transform.position.y >= 135)
        {
            movement = false;
        }
        if (movement == true)
        {
            this.transform.position += Vector3.up * speed * Time.deltaTime;
        }
    }


}