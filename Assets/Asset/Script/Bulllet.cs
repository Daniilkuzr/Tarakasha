using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulllet : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public float startLifeTime = 0;
    public float distance;
    public int damage;
    public LayerMask whatIsSolid;
    public GameObject bullet;
    void Start()
    {
        
    }

    
  public void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if(hitInfo.collider !=null)
        {
            if(hitInfo.collider.CompareTag("Enemy"))
            {
                hitInfo.collider.GetComponent<Enemy>().TakeDamage(damage);

            }
            Destroy(gameObject);
        }
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        LifeTimeBullet();
    }

    public void LifeTimeBullet()
    {
        if( lifetime>startLifeTime)
        {
            startLifeTime += Time.deltaTime;
        }
        else
        {
            Destroy(bullet);
        }
    }

}
