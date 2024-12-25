using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class automate : MonoBehaviour
{
    public GameObject bullet;
    public Transform shotPoint;
    public int oboima;
    public int startOboima;
    public float StartTimeShots;
    public float TimeShoots;
    public float StartBurst;
    public float BurstTime;
    public bool startShoot;
    public int automateLevel=0;
    void Start()
    {
        
    }

    
    void Update()
    {
        //if (timeBtwShots <= 0 && strike==true && oboima>=0)
        //{
        //    Instantiate(bullet, shotPoint.position, transform.rotation);
        //    timeBtwShots = StartTimeBtwShots;
        //    oboima--;
        //}
        Burst();
        //if (startShoot && oboima >= 0)
        //{
        //    strikeBullet();
        //    oboima--;
        //    startShoot = false;
        //}
        //if (startShoot == false)
        //{
        //    if (TimeShoots > 0)
        //    {
        //        TimeShoots = TimeShoots - Time.deltaTime;
        //    }
        //    else if (TimeShoots <= 0)
        //    {
        //        startShoot = true;
        //        TimeShoots = StartTimeShots;
        //    }
        //}
        //if (oboima <= 0)
        //{
        //    if (BurstTime > 0)
        //    {
        //        BurstTime = BurstTime - Time.deltaTime;
        //    }
        //    else if (BurstTime <= 0)
        //    {
        //        BurstTime = StartBurst;
        //        oboima = startOboima;
        //    }
        //}

    }

    void Burst()
    {
        if (startShoot && oboima >= 0)
        {
            strikeBullet();
            oboima--;
            startShoot = false;
        }
        if (startShoot == false)
        {
            if (TimeShoots > 0)
            {
                TimeShoots = TimeShoots - Time.deltaTime;
            }
            else if (TimeShoots <= 0)
            {
                startShoot = true;
                TimeShoots = StartTimeShots;
            }
        }
        if (oboima <= 0)
        {
            if (BurstTime > 0)
            {
                BurstTime = BurstTime - Time.deltaTime;
            }
            else if (BurstTime <= 0)
            {
                BurstTime = StartBurst;
                oboima = startOboima;
            }
        }

    }

    void strikeBullet()
    {
        Instantiate(bullet, shotPoint.position, transform.rotation);
    }

    
}
