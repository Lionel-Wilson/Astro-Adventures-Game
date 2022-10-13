using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class main_menu : MonoBehaviour
{
    public string firstLevel;
    public string tutorial;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startgame()
    {
        SceneManager.LoadScene(firstLevel);
    }
    public void starttutorial()
    {
        SceneManager.LoadScene(tutorial);
    }
    public void quitgame()
    {
        Application.Quit();
    }
}
