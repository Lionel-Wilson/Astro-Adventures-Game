using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformMovement : MonoBehaviour
{
    //Reference - Unity: 2D Moving Platforms - https://www.youtube.com/watch?v=GtX1p4cwYOc
    public float speed; //speed of the spikewall
    public int startingPoint; //starting index(position of the spike wall)
    public Transform[] points; //Ann array of transnform points(positions where the spikewall needs to move)

    private int i;//index of the array


    // Start is called before the first frame update
    void Start()
    {
        transform.position = points[startingPoint].position; //Setting the position of the spikewall to the psotion of one of the points using inex "startingpoint"
    }

    // Update is called once per frame
    void Update()
    {
        //checking the distance of the spikewall and the point
        if (Vector2.Distance(transform.position, points[i].position) < 0.02f)
        {
            i++; //increase the index
            if (i==points.Length) //check if the platform was on the last point after the index increase
            {
                i = 0; //reset the index
            }
        }
        
        //moveing the spikewall to the point position with the index "i"
        transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.transform.SetParent(transform);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.SetParent(null);
    }
}
