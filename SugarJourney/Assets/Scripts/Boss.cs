using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Boss : MonoBehaviour {

    public GameObject mainCharacter;
    
    public GameObject rayo;
    public float fireduration; 
    private bool shooting;
    private float firetimer;
    public float reloadTime;
    public float firecooldown;
    public float bossLife;
    public float characterDamage;
    public Text bossLifeHUD;
    public AudioClip hitted;
    public AudioClip rayoSound;
    public AudioSource audios;

    private bool lf;

    // Use this for initialization
    void Start () {

        firetimer = Time.time;
        lf = true;
        audios = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Main1.uCAttack)
        {
            Combat();
        }
    }
    void Combat()
    {
        bossLifeHUD.text = bossLife.ToString();
        if (lf)
        {
            bossLife = 100 * DificultManager.Dif;
            lf = false;

        }

        if (mainCharacter != null && Time.time - firetimer >= firecooldown)
        {
            Invoke("Shooting", reloadTime);   
            firetimer = Time.time;
            shooting = true;
            AudioSource.PlayClipAtPoint(rayoSound, transform.position);

        }
        if (mainCharacter != null && shooting == false && mainCharacter.transform.position.y >= 133)
        {
            transform.position = new Vector3(mainCharacter.transform.position.x, transform.position.y, transform.position.z);
        }
        if (bossLife <= 0)
        {
            Destroy(gameObject);
        }
    }
    void Shooting()
    {            
            rayo.gameObject.GetComponent<BoxCollider2D>().enabled = true;
            rayo.gameObject.GetComponent<SpriteRenderer>().enabled = true;
             Invoke("Shoot", fireduration);
    }

    void Shoot()
    {
        shooting = false;
        rayo.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        rayo.gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }

    void OnCollisionEnter2D(Collision2D hit)
    {
        bossLife = bossLife - characterDamage;
        audios.Play();
    }

}
