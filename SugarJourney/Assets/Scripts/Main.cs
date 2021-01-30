using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Platform : MonoBehaviour
{
    public GameObject mainCharacter;
    public Text Hpboss;
    public Text Hp;
    public GameObject boss;
    public Button back;
    public Button restart;
    public Image victoryText;
    public Text bossLifeText;
    public Text hpText;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (mainCharacter != null && mainCharacter.transform.position.y >= 135)
        {
            GetComponent<BoxCollider2D>().enabled = true;
            Hpboss.rectTransform.localScale = Vector3.one;
            Hp.rectTransform.localScale = Vector3.one;
        }
        if (boss == null && mainCharacter != null)
        {
            victoryText.rectTransform.localScale = Vector3.one;
            back.transform.localScale = Vector3.one;
            restart.transform.localScale = Vector3.one;
            restart.transform.localScale = Vector3.zero;
            hpText.transform.localScale = Vector3.zero;
        }
    }
}
