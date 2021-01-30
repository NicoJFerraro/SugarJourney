using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DificultManager : MonoBehaviour {

    public static float Dif = 1;
    public int Dif1;
    public int Dif2;
    public int Dif3;

    public GameObject bc;

    private void Start()
    {
 
    }
    public void Dificult1()
    {
        Dif = Dif1;
    }
    public void Dificult2()
    {
        Dif = Dif2;
    }
    public void Dificult3()
    {
        Dif = Dif3;
    }

    public void ShowButtons()
    {
        if (bc != null && bc.activeInHierarchy == true)
        {
            bc.SetActive(false);
        }
        else if (bc != null && bc.activeInHierarchy == false)
        {
            bc.SetActive(true);
        }
    }

   

}
