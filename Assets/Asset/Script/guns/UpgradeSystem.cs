using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeSystem : MonoBehaviour
{
    //public GameObject[] weapon;
    public GameObject[] weapon;
    public GameObject[] obilka;


    void RandomObilka_1()
    {
        int numberObilka_1 = Random.Range(0, spriteObilka.Length);
        imgObilka_1.sprite = spriteObilka[numberObilka_1];
        numberScriptupgr_1 = numberObilka_1;
    }
    void RandomObilka_2()
    {
        int numberObilka_2 = Random.Range(0, spriteObilka.Length) ;
        while(numberObilka_2==numberScriptupgr_1)
        {
            numberObilka_2 = Random.Range(0, spriteObilka.Length);
        }
        imgObilka_2.sprite = spriteObilka[numberObilka_2];
        numberScriptupgr_2 = numberObilka_2;
    }
   public void UpgradeObilka_1()
    {
        switch (numberScriptupgr_1)
        {
            case 0:
                HealthUpgr();
                break;
            case 1:
                HealthRegenHP();
                break;
        }
        CloseUpgrMenu();
    }
    public void UpgradeObilka_2()
    {
        switch (numberScriptupgr_2)
        {
            case 0:
                HealthUpgr();
                break;
            case 1:
                HealthRegenHP();
                break;
        }
        CloseUpgrMenu();
    }
    public int numberScriptupgr_1;
    public int numberScriptupgr_2;

    public PlayerController pl;
    public int trueLevel;
    public int pllevel;
    public GameObject panelUpgr;

    public GunConroller gun;
    public Pistol pist;
    public automate auto;
    public Drobowik drobash;

    public Sprite[] imgWeapon;
    public Sprite[] spriteObilka;
    public Image imgn;
    public Image imgObilka_1;
    public Image imgObilka_2;
    public int numberweapon;
    void Start()
    {
        trueLevel = pl.level;
    }

  
    void Update()
    {
        xpUpgr();
        numberweapon = gun.numberWeapon;
        pllevel = pl.level;


    }

   public void xpUpgr()
    {
        if(pllevel>trueLevel)
        {
            Panelupgr();

            trueLevel = pl.level;
        }
    }

     void Panelupgr()
    {
        gun.StopGame = false;
        Time.timeScale = 0;
        panelUpgr.SetActive(true);
        TrueWeapon();
        RandomObilka_1();
        RandomObilka_2();
    }

     void TrueWeapon()
    {
        if(numberweapon==0)
        {
            imgn.sprite= imgWeapon[numberweapon];
            
        }
        else if(numberweapon==1)
        {
            imgn.sprite = imgWeapon[numberweapon];
            
        }

    }

    public void UpgrWeapon()
    {
        if(numberweapon==0)
        {
            PistolUprg();
        }
        else if(numberweapon==1)
        {
            AutoMateUpgr();
        }
        else if(numberweapon==2)
        {
            drobowikUpgr();
        }
    }

    void PistolUprg()
    {
        pist.pistolLevel++;
        switch(pist.pistolLevel)
        {
            case 1:
                pist.StartTimeBtwShots -= 0.2f;
                break;
            case 2:
                pist.StartTimeBtwShots -= 0.2f;
                break;
            case 3:
                pist.StartTimeBtwShots -= 0.2f;
                break;
        }
        CloseUpgrMenu();
    }

    void AutoMateUpgr()
    {
        auto.automateLevel++;
        switch (auto.automateLevel)
        {
            case 1:
                auto.oboima++;
                break;
            case 2:
                auto.StartBurst = auto.StartBurst - 0.2f;
                break;
            case 3:
                auto.TimeShoots = auto.TimeShoots - 0.2f;
                break;
        }
        CloseUpgrMenu();
    }

    void drobowikUpgr()
    {
        drobash.drobowikLevel++;
        switch (drobash.drobowikLevel)
        {
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
        }
        CloseUpgrMenu();
    }

    void HealthUpgr()
    {
        pl.HealthLevel++;
        switch (pl.HealthLevel)
        {
            case 1:
                pl.hptrue += 30;
                break;
            case 2:
                pl.hptrue += 30;
                break;
            case 3:
                pl.hptrue += 30;
                break;
            case 4:
                pl.hptrue += 30;
                break;
            case 5:
                pl.hptrue += 30;
                break;
        }
    }

    void HealthRegenHP()
    {
        pl.HealthLevel++;
        switch (pl.HealthLevel)
        {
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
        }

    }

    void CloseUpgrMenu()
    {
        panelUpgr.SetActive(false);
        gun.StopGame = true;
    }
}
