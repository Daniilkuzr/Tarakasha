using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    public GameObject bullet;
    public Transform shotPoint;

    private float timeBtwShots;
    public float StartTimeBtwShots;
    
    public int pistolLevel=0;


    void Start()
    {
       
    }

    
    void Update()
    {
        if (timeBtwShots <= 0)
        {
            //if (Input.GetMouseButton(0))
            //{
                Instantiate(bullet, shotPoint.position, transform.rotation);
                timeBtwShots = StartTimeBtwShots;
            //}
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
}
