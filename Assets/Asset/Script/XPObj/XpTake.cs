using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XpTake : MonoBehaviour
{
    public float xp;
    public GameObject xpObj;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerController>().TakeXP(xp);
            
            
            Destroy(xpObj);
        }
    }
}
