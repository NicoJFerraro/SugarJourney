using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;




public class SwitchManager : MonoBehaviour
{


    void Start()
    {
 
    }

    public void ChangeScene(string escena)
    {
        SceneManager.LoadScene(escena);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ExitButton()

    {
        Application.Quit();
    }
}
