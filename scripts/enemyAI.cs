using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class enemyAI : MonoBehaviour
{
    //reference - Unity 2D Platformer Tutorial 23 - Enemy AI Part 1 Script Setup - https://www.youtube.com/watch?v=AGiRP6e090c&list=PLjAb99vXJuCRD04EUp8p2az1ILZbq_ZfY&index=23
    // reference to waypoints
    public List<Transform> points;
    //int value for next point index
    public int nextID = 0;
    //the valuse of that applies to ID for changing
    int idChangeValue = 1;

    public float speed = 2;

    healthDeath healthDeathScript;

    private void Awake()
    {
        healthDeathScript = GetComponent<healthDeath>();
    }


    private void Reset()
    {
        Init();
    }

    void Init()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;

        //create root object
        GameObject root = new GameObject(name + "_root");
        //reset position of Root to enemy object
        root.transform.position = transform.position;
        //set enemy object as child of root
        transform.SetParent(root.transform);
        //create waypoitns object
        GameObject waypoints = new GameObject("Waypoints");
        //reset waypoints to root
        //make waypoints object child of root
        waypoints.transform.SetParent(root.transform);
        waypoints.transform.position = Vector3.zero;
        //create two points (gameobject) and reset their posiiotn to way points object
        //make the points children of waypint object
        GameObject p1 = new GameObject("Point1"); p1.transform.SetParent(waypoints.transform); p1.transform.position = Vector3.zero;
        GameObject p2 = new GameObject("Point2"); p2.transform.SetParent(waypoints.transform); p2.transform.position = Vector3.zero;

        //Init points list then add the points to it
        points = new List<Transform>();
        points.Add(p1.transform);
        points.Add(p2.transform);
    }

    private void Update()
    {
        MoveToNextPoint();
        if(gameObject.name == "boss")
        {
            //change speed depending on health
            if (healthDeathScript.health <= 1500)
            {
                speed = 25;
            }
            if (healthDeathScript.health <= 1000)
            {
                speed = 27;
            }
            if (healthDeathScript.health <= 500)
            {
                speed = 29;
            }
            if (healthDeathScript.health <= 250)
            {
                speed = 35;
            }
            if (healthDeathScript.health <= 150)
            {
                speed = 45;
            }
            if (healthDeathScript.health <= 80)
            {
                speed = 60;
            }

        }


    }

    void MoveToNextPoint()
    {
        //get the next point transform
        Transform goalPoint = points[nextID];
        //flip the enemy transform to look into the points direction
        if (goalPoint.transform.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(-10,10,1);
        }
        else
        {
            transform.localScale = new Vector3(10,10,1);
        }

        if(gameObject.name == "boss")
        {
            //flip the enemy transform to look into the points direction
            if (goalPoint.transform.position.x > transform.position.x)
            {
                transform.localScale = new Vector3(-15,15,1);
            }
            else
            {
                transform.localScale = new Vector3(15,15,1);
            }
        }
        //move the enemy towards the goal point
        transform.position = Vector2.MoveTowards(transform.position,goalPoint.position,speed*Time.deltaTime);
        //check the distance between the enmey and the goal point to trigger next point
        if(Vector2.Distance(transform.position, goalPoint.position)<0.5f)
        {
            //check if we are at the end of the line(make the change -1)
            if(nextID == points.Count - 1)
            {
                idChangeValue = -1;
            }
            //check if we are at the start of the line(make the change +1)
            if(nextID == 0)
            {
                idChangeValue = 1;
            }
            //Apply the change on the nextID
            nextID += idChangeValue;
            //nextID = nextID + idChangeValue
        }
    }
}
