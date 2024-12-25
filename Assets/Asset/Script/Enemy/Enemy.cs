using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health;
    //public Healthbar healthbar;
    public GameObject enemy;
    public float damage;
    public bool trig;
    public GameObject player;
    private float timeBtwShots;
    public float StartTimeBtwShots=2;
    public GameObject DropExpObj;
    Transform enemyPos;

    public void TakeDamage(float damage)
    {
        
        health -= damage ;
        //healthbar.SetHealth(health);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if(collision.gameObject.name=="Player")
        //{
        //    if (timeBtwShots <= 0)
        //    {
        //        trig = true;
        //        //player.TakeDamage(damage);
        //        timeBtwShots = StartTimeBtwShots;
        //    }
        //    else
        //    {
        //        timeBtwShots -= Time.deltaTime;
        //        trig = false;
        //    }
        //    //trig = true;
        //    //player.TakeDamage(damage);
        //}
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //if (collision.gameObject.name == "Player")
        //{
        //    trig = false;

        //}

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            if (timeBtwShots <= 0)
            {
                player = collision.gameObject;
                trig = true;
                //player.TakeDamage(damage);
                timeBtwShots = StartTimeBtwShots;
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
                trig = false;
            }
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        //healthbar.maxHealth= health;
        //healthbar.SetHealth(health);
    }

    // Update is called once per frame
    void Update()
    {
        if(trig)
        {
            player.GetComponent<PlayerController>().TakeDamage(damage);
            //player.TakeDamage(damage);
        }


        if(health<=0)
        {
            FindObjectOfType<PlayerController>().TakeKills();
            //player.GetComponent<PlayerController>().TakeKills();
            DropEXP();
            //Destroy(gameObject);
            Destroy(enemy);
        }
    }

    void DropEXP()
    {
        
        Instantiate(DropExpObj, enemy.transform.position, transform.rotation) ;
    }
}
