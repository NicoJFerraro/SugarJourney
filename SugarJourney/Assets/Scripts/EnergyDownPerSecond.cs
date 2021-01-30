using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyDownPerSecond : MonoBehaviour
{

    private float currentValue;
	// Use this for initialization
	void Start ()
    {
        EnergyDownPerSeconds();
	}
	
	// Update is called once per frame
	void Update ()
    {   
        gameObject.SendMessage("EnergyDownPerSecond", SendMessageOptions.DontRequireReceiver);
        currentValue = GetComponent<Slider>().value;        
	}

    // La energia baja por segundo
    void EnergyDownPerSeconds()
    {
        currentValue -= Time.deltaTime;   
    }
}
