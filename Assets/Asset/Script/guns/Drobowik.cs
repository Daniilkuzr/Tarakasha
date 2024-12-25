using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drobowik : MonoBehaviour
{

    public GameObject bullet;
    public Transform shotPoint;
    public float timeBulletShoot;
    private float trueTimeBulletShoot;
    bool startShoot = true;
    public int drobowikLevel=0;

    void Start()
    {
        trueTimeBulletShoot = timeBulletShoot;
    }


    void Update()
    {
        drobowikShoot();
    }

    public void drobowikShoot()
    {
        if (startShoot)
        {

            Instantiate(bullet,shotPoint.position, transform.rotation);
            startShoot = false;

        }
        else timerShoot();
    }

    void timerShoot()
    {
        if(trueTimeBulletShoot>0)
        {
            trueTimeBulletShoot -= Time.deltaTime;
        }
        else if(trueTimeBulletShoot<=0)
        {
            startShoot = true;
            trueTimeBulletShoot = timeBulletShoot;
        }
    }

}
