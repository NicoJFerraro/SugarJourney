using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Character : MonoBehaviour
{    //Variables
    private float move;
    private Collider2D myCollider;

        
    public float speed;   
    public float jumpForce; 
    public static float energyBar;
    public float energyBar2;
    private float seconds; 
    public Text Energy;
    public Text EnergyText;
    public Vector3 respawnPoint;
    public Rigidbody2D rb;
    public LayerMask whatIsGround;
    Animator animator;
    bool facingright = true;
    public bool grounded;
    private bool alive = true;
    public Image gameOver;
    public Button Back;
    public Button Restart;
    public AudioClip muerte;
    public AudioClip checkpoint;
    public AudioClip salto;

    public string sceneToLoad;

    public static bool sMC;

    
    void Start()
    {
        animator = GetComponent<Animator>();
        myCollider = GetComponent<Collider2D>();
        seconds = Time.time;
        sMC = false;
        energyBar = energyBar2;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Fliping();
        Jump();
        Grounded();
        Pause();
        EnergyDownPerSecond();
        Canvas();
    }

    public void Canvas()
    {   
        Energy.text = energyBar.ToString();
    }

    public void EnergyUp()
    {
        energyBar += 5 / DificultManager.Dif;        
    }

    void EnergyDownPerSecond()
    {
        if (Time.time - seconds >= 1)
        {
            seconds = Time.time;
            energyBar -= 1;          
            if (energyBar < 0.5f)
            {
                //Cambia la bool alive a falso, para que se deje de mover
                sMC = true;
                alive = false;
                animator.Play("Death");
                Invoke("TimeScale", 3 );
                Invoke("Death", 2);                      
                               
            }
        }
    }

    void TimeScale()
    {
        Time.timeScale = 0;
    }


    void Death()
    {
        alive = false;
        gameOver.rectTransform.localScale = Vector3.one;
        Energy.rectTransform.localScale = Vector3.zero;
        EnergyText.rectTransform.localScale = Vector3.zero;
        Back.transform.localScale = Vector3.one;
        Restart.transform.localScale = Vector3.one;
    }

    void Movement()
    {   

        animator.SetBool("Ground", grounded);

        if (alive == true)
        {
            move = Input.GetAxis("Horizontal");
        }
       

        Vector3 currentVelocity = Vector3.right * move * speed;
        currentVelocity.y = rb.velocity.y;
        rb.velocity = currentVelocity;

        animator.SetFloat("Speed", Mathf.Abs(move));


        if (rb.velocity.y < -5)
        {
            //print("Falleando..");
            animator.Play("Fall");
        }
    }
    void Jump()
    {
        if (alive == true && Input.GetKeyDown (KeyCode.Space))
        {
            animator.Play("Jump");
            
            //Solo salta si estas en un objeto que esta en la layer ground
            if (grounded) 
            {
                AudioSource.PlayClipAtPoint(salto, transform.position);
                rb.AddForce(Vector3.up * jumpForce * rb.mass, ForceMode2D.Impulse);
            }
         
        }
    }
 
    void OnCollisionEnter2D (Collision2D hit)
    {   if(hit.gameObject.layer == 13)
        {
            //AudioSource.PlayClipAtPoint(muerte, transform.position);
            energyBar = energyBar - 20 * DificultManager.Dif;
        }
        if(hit.gameObject.layer == 16)
        {
            energyBar = energyBar - 5 * DificultManager.Dif;
            Respawn();      
        }
        if (hit.gameObject.layer == 14)
        {
            PlatformMovement.moving = false;
        }
    }
    void OnTriggerEnter2D (Collider2D inside) 
    {

        if (inside.gameObject.layer == 19)
        {
            AudioSource.PlayClipAtPoint(checkpoint, transform.position);
            inside.gameObject.SendMessage("ReachedCheckpoint", SendMessageOptions.DontRequireReceiver);            
            respawnPoint = inside.transform.position;
        }
        if (inside.gameObject.layer == 21)
        {
            SceneManager.LoadScene(sceneToLoad);
        }
        
    }


    void Fliping()
    {
        //Si te estas moviendo a la derecha pero estas mirando a la izquierda flip
        if (move > 0 && !facingright)
        {
            Flip();
        }
        //Si te estas moviendo a la izquierda pero estas mirando a la derecha flip
        else if (move < 0 && facingright)
        {
            Flip();
        }
    }        
    //Flip al personaje 
    void Flip ()
        {
        facingright = !facingright; 
        Vector3 look = transform.localScale;
        look.x *= -1;
        transform.localScale = look;
        }

    //Respawnea al personaje en los respawnpoints
    void Respawn ()
    {
        //Envia al personaje al respawn point.      
        transform.position = respawnPoint;
        PlatformMovement.moving = false;
        
        //Hace que la camara vuelva al personaje.
        Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, this.gameObject.transform.position.y, Camera.main.transform.position.z);
        
    }

    void Grounded()
    {
        grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);
    }
   
     //Pausa el juego presionando la Tecla P
    void Pause()
    {       
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }
    }
    
}
