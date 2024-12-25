using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Transform player;
    public Rigidbody2D enemy;
    public float moveSpeed;
    public Vector2 moveVector;


    void Start()
    {
        player = FindObjectOfType<PlayerController>().transform;

    }

    
    void Update()
    {
        if (enemy.position.x < player.position.x)
        {
            moveVector.x = moveSpeed;

        }
        else if (enemy.position.x > player.position.x)
        {
            moveVector.x = moveSpeed* (-1);
        }
        if (enemy.position.y < player.position.y)
        {
            moveVector.y = moveSpeed;

        }
        else if (enemy.position.y > player.position.y)
        {
            moveVector.y= moveSpeed * (-1);
        }
        enemy.velocity = new Vector2(moveVector.x, moveVector.y);
        //transform.position /*enemy.velocity*/ = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
        if(player.transform.position.x>=transform.position.x+0.1)
        {
            transform.eulerAngles = new Vector2(0, 180);
        }
        else if(player.transform.position.x <= transform.position.x - 0.1)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }
    }
   
}
