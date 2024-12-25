using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrobowikShoot : MonoBehaviour
{
    public float lifetime;
    public float startLifeTime = 0;
    public int damage;
    public LayerMask whatIsSolid;
    public GameObject bullet;
    void Start()
    {
        
    }

    
    void Update()
    {
        strike();
    }

    void strike()
    {
       if(lifetime>startLifeTime)
        {
            lifetime -= Time.deltaTime;
        }
        else
        {
            Destroy(bullet);
        }


    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(damage);
            Destroy(bullet);
        }

    }
}
