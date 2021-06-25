using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class mainmenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //exit
    public void bye()
    {
        Application.Quit();
    }
    //credits
    public void cred()
    {
        SceneManager.LoadScene(2);
    }
    //start
    public void hello()
    {
        SceneManager.LoadScene(1);
    }
    //tutorial
    public void tut()
    {
        SceneManager.LoadScene(3);
    }
    //back to main
    public void mm()
    {
        SceneManager.LoadScene(0);
    }
    public void tut2()
    {
        SceneManager.LoadScene(4);
    }
    public void tut3()
    {
        SceneManager.LoadScene(5);
    }
    public void tut4()
    {
        SceneManager.LoadScene(6);
    }
}
