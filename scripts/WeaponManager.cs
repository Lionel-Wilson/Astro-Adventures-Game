using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    //reference/inspiration -Swapping Weapons in Unity - Game Dev Tutorial - https://www.youtube.com/watch?v=JhV2zFhtKvI
    [SerializeField] private GameObject Akbullet;
    [SerializeField] private GameObject ShottyBullet;
    [SerializeField] private GameObject Sniperbullet;
    
    PlayerShoot playerShootScript;

    private void Awake()
    {
        playerShootScript = GetComponent<PlayerShoot>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(grabgun.heldgun != null &&  grabgun.heldgun.name == "ak-47 ground")
        {
            playerShootScript.SetBulletPrefab(Akbullet);
            playerShootScript.shootSpeed = 6000;
            playerShootScript.shootTimer = 0.1f;

        }
        else if(grabgun.heldgun != null &&  grabgun.heldgun.name == "shotgun ground")
        {
            playerShootScript.SetBulletPrefab(ShottyBullet);
            playerShootScript.shootSpeed = 5000;
            playerShootScript.shootTimer = 0.75f;
        }
        else if(grabgun.heldgun != null &&  grabgun.heldgun.name == "sniper ground" || grabgun.heldgun != null &&  grabgun.heldgun.name == "sniper ground (1)")
        {
            playerShootScript.SetBulletPrefab(Sniperbullet);
            playerShootScript.shootSpeed = 7000;
            playerShootScript.shootTimer = 1f;
        }
        else
        {
            return;
        }
    }
}
