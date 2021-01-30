using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyUp : MonoBehaviour
{
    public Sprite eatDonut;
    public Sprite eatDonut2;
    Animator animator;
    public bool CharacterTouchDona;
    public AudioSource aS;
    // Use this for initialization
    void Start ()
    {
        aS = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        CharacterTouchDona = false;


    }
	
	// Update is called once per frame
	void Update ()
    {

     
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == 8)
        {
            col.gameObject.SendMessage("EnergyUp", SendMessageOptions.DontRequireReceiver);
            animator.Play("DonaDissapear");
            aS.Play();
            CharacterTouchDona = true;
            Invoke("Destroy", 0.8f);               
        }
    }

    void Destroy()
    {
        Destroy(this.gameObject);
    }
}
