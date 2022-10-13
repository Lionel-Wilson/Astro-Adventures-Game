using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grabgun : MonoBehaviour
{
    public Transform grabDetect;
    public Transform  gunHolder;
    public float rayDist;
    public static bool armed;
    public static GameObject heldgun;

    
    
    void Start()
    {
        //true if holding a gun.
        armed = false;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit2D grabCheck = Physics2D.Raycast(grabDetect.position, Vector2.right * transform.localScale, rayDist);

        if (PlayerController.isLeft == false)
        {
            if(grabCheck.collider != null && grabCheck.collider.tag == "AK" || 
            grabCheck.collider != null && grabCheck.collider.tag == "Shotty" || 
            grabCheck.collider != null && grabCheck.collider.tag == "Sniper")
            {
                //flip weapon
                grabCheck.collider.gameObject.transform.eulerAngles = new Vector3(0,0,0);
                
                if (Input.GetKey(KeyCode.E) && heldgun == null)
                {
                    armed = true;
                    heldgun = grabCheck.collider.gameObject;
                    heldgun.transform.parent = gunHolder;
                    heldgun.transform.position = gunHolder.position;
                    heldgun.GetComponent<Rigidbody2D>().isKinematic = true;

                }
                else if(Input.GetKey(KeyCode.E))
                {
                    heldgun.transform.position =  new Vector3(heldgun.transform.position.x - 8, heldgun.transform.position.y, heldgun.transform.position.z );
                    heldgun.transform.parent = null;
                    heldgun.GetComponent<Rigidbody2D>().isKinematic = false;
                    heldgun = null;   
                }
            }
        }

        if (PlayerController.isLeft)
        {
            if(grabCheck.collider != null && grabCheck.collider.tag == "AK" || 
            grabCheck.collider != null && grabCheck.collider.tag == "Shotty" || 
            grabCheck.collider != null && grabCheck.collider.tag == "Sniper")
            {
                //flip weapon
                grabCheck.collider.gameObject.transform.eulerAngles = new Vector3(0,180,0);

                if (Input.GetKey(KeyCode.E) && heldgun == null)
                {
                    armed = true;
                    heldgun = grabCheck.collider.gameObject;

                    //pick up weapon
                    heldgun.transform.parent = gunHolder;
                    heldgun.transform.position = gunHolder.position;
                    heldgun.GetComponent<Rigidbody2D>().isKinematic = true;
                    
                }
                else if(Input.GetKey(KeyCode.E))
                {
                    heldgun.transform.position =  new Vector3(heldgun.transform.position.x - 8, heldgun.transform.position.y, heldgun.transform.position.z );
                    heldgun.transform.parent = null;
                    heldgun.GetComponent<Rigidbody2D>().isKinematic = false;
                    heldgun = null;   
                }
            }
        }
        

        
    }
}