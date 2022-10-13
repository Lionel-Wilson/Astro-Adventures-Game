using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerHealth : MonoBehaviour
{
    public float health;
    public Slider healthBar;
    public Text text;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value=health;
        text.text="Health : "+health;

        //die and restert level if fall under map.
        if (transform.position.y < -88)
        {
            Debug.Log("YOU DIED");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
    }

    void OnCollisionEnter2D(Collision2D obj)
    {
        if(obj.gameObject.tag == "Enemy")
        {
            if(health<=0)
            {
                return;
            }
            health=health-10f;
            if(health<=0)
            {
                Debug.Log("YOU DIED");
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        if(obj.gameObject.tag == "floor spike")
        {
            if(health<=0)
            {
                return;
            }
            health=health-40f;
            if(health<=0)
            {
                Debug.Log("YOU DIED");
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        if(obj.gameObject.name == "boss")
        {
            if(health<=0)
            {
                return;
            }
            health=health-18f;
            if(health<=0)
            {
                Debug.Log("YOU DIED");
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }

        if(obj.gameObject.tag == "spikeball")
        {
            if(health<=0)
            {
                return;
            }
            health=health-30f;
            if(health<=0)
            {
                Debug.Log("YOU DIED");
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}
