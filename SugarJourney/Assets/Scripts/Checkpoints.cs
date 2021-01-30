using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints : MonoBehaviour
{
    public Sprite redFlag;
    public Sprite greenFlag;
    public AudioSource aS;
    public bool playSTrue;

    private SpriteRenderer checkpointSpriteRenderer;

    private void Start()
    {
        aS = GetComponent<AudioSource>();
    }
    void ReachedCheckpoint()
    {
        if (playSTrue)
        {
            aS.Play();
            playSTrue = false;
        }
        GetComponent<SpriteRenderer>().sprite = greenFlag;              
    }


}
