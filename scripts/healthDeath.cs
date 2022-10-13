using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthDeath : MonoBehaviour
{
    public float health;
    public Text text;
    public Vector3 Offset;

    public GameObject blocker;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        text.text="Health : "+health;
        text.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + Offset);
        
    }

    void OnCollisionEnter2D(Collision2D obj)
    {
        if(obj.gameObject.tag == "Shotgun bullet")
        {
            health=health-26f;
            if(health<=0)
            {
                if(gameObject.name == "boss")
                {
                    Destroy(blocker);
                }
                Destroy(gameObject);
            }
            
        }

        if(obj.gameObject.tag == "sniper bullet")
        {
            health=health-65f;
            if(health<=0)
            {
                if(gameObject.name == "boss")
                {
                    Destroy(blocker);
                }
                Destroy(gameObject);
            }
            
        }

        if(obj.gameObject.tag == "AKbullet")
        {
            health=health-12f;
            if(health<=0)
            {
                if(gameObject.name == "boss")
                {
                    Destroy(blocker);
                }
                Destroy(gameObject);
            }
            
        }
    }
}
