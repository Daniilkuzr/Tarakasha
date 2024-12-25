using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D  rb;
    public Vector2 moveDir;
    public bool facingRight=true;
    public int kol;
    private Animator anim;
    public float health;
    public float hptrue;
    public GameObject player;
    public float xpbar;
    public float xptrue;
    public float RegenHP;
    public int RegenLevel = 0;
    public TMP_Text levelText;
    public TMP_Text killText;
    public int level = 0;
    public Slider hpbar;
    public Slider xpBar;
    private float Timer=0;
    public TMP_Text timeText; 

    public GameObject defeatMenu;
    public TMP_Text textDefeat;


    public int kils = 0;

    public UpgradeSystem upweap;

    public int HealthLevel=0;
    public void TakeXP(float xp)
    {
        xpbar += xp;
    }
    
    public void levelUp()
    {
        if(xpbar>xptrue)
        {
            level++;
            xptrue =xptrue+50;
            xpbar = 0;
            
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }

    public void TakeKills()
    {
        kils++;
    }
         

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        hptrue = health ;
    }

    // Update is called once per frame
    void Update()
    {
        InputManagment();
        anim = GetComponent<Animator>();
        if (health <= 0)
        {
            Time.timeScale = 0;
            defeatMenu.SetActive(true);
            textDefeat.text = levelText.text +"\n"+ killText.text;
            //Destroy(gameObject);
            //Destroy(player);
        }
        xpBar.value = xpbar / xptrue;
        hpbar.value = health/hptrue;
        levelUp();
        PlRegenHP();
        levelText.text = "Level " + level;
        killText.text = "Kills   " + kils;
        Timer += Time.deltaTime;
        int second=((int)Timer)%60;
        int minute = second / 60;
        timeText.text="Time "+minute+":"+second ;
    }

    void FixedUpdate()
    {
        Move();
        
    }

    float healthTimeReg=1;
    float trueRegTime = 0;
    bool regen = true;
    void PlRegenHP()
    {
        if(health<hptrue && regen)
        {
            health += RegenHP;
            regen = false;
        }
        else if(!regen)
        {
            if(healthTimeReg>trueRegTime)
            {
                healthTimeReg -= Time.deltaTime;
            }
            else
            {
                healthTimeReg = 1;
                regen = true;
            }
        }
    }

    void InputManagment()
    {
        

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDir = new Vector2(moveX, moveY).normalized;
        kol = 1;
        if (facingRight == false && moveX > 0)
        {
            Flip();
            kol *= -1;
        }
        else if(facingRight == true && moveX < 0)
        {
            Flip();
            kol *= -1;
        }

    }
        void Move()
    {
        rb.velocity = new Vector2(moveDir.x * moveSpeed, moveDir.y * moveSpeed);
    }

    void Flip()
    {
        
        facingRight = !facingRight;
        //transform.localScale *= new Vector2(-1, 1);
        transform.Rotate(0f, 180f, 0f);
    }

    private States State
    {
        get { return (States)anim.GetInteger("state"); }
        set { anim.SetInteger("state", (int)value); }
    }



    public enum States
    {
        run,
        idle

    }


}
