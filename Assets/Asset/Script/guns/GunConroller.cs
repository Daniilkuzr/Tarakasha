using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
public class GunConroller : MonoBehaviour
{
    public GameObject pistol;
    public GameObject automate;
    public GameObject drob;
    public GameObject panel;
    public bool StopGame =false;
    public GameObject HPXPBar;
    public int numberWeapon;

    void Start()
    {

    }


    void Update()
    {
        if (StopGame == false)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void Usepistol()
    {
        numberWeapon = 0;
        pistol.SetActive(true);
        StopGame = true;
        panel.SetActive(false);
        HPXPBar.SetActive(true);
    }

    public void UseAuto()
    {
        numberWeapon = 1;
        automate.SetActive(true);
        StopGame = true;
        panel.SetActive(false);
        HPXPBar.SetActive(true);
    }

    public void UseDrob()
    {
        numberWeapon = 2;
        drob.SetActive(true);
        StopGame = true;
        panel.SetActive(false);
        HPXPBar.SetActive(true);
    }
}
