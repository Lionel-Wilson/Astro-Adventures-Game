using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class floor_spike_hazard : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (SceneManager.GetActiveScene().name == "Tutorial two")
        {
            if(collision.gameObject.tag == "Player"){
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }

        if(collision.gameObject.tag == "Player"){
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
    }
}
