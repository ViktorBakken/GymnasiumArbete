﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;


public class RumInteraktion : MonoBehaviour
{
    public int[] VadRummetSkaGöra; //0 == blinka, 1 == ljud, 2 == utfört.
    public int min; //Minimum tiden för timern
    public int max; //Maximum tiden för  timern
    public int blinkTid; //tiden lampan är på
    public int plats; //platsen i VadRummetSkaGöra
    public float väntaLjud; //Tid som låter ljudet spela klart
    public string rummID; //Ett id för rummet, används när tiderna antecknas
    public int rumNummer;
    public GameObject spelareIRum;

    public AudioSource ljudKäll;

    public bool blinkPå = false;
    public bool ljudPå = false;
    public bool ärIRummet = false;
    public bool förstaRummet = false;

    public float tid;
    public float startTid;

    private float timer;
    private float AndraTimer;
    private bool harStartTid = false;
    private bool ljudSpelas = true;
    private bool blink = true;

    private LampaLjus lampa;
    private MegaHjärna megaHj;
    private KontrollerVägg väggKontroll;
    private uiInteraktioner ui;

    void Start()
    {
        megaHj = GameObject.FindGameObjectWithTag("RummKontroller").GetComponent<MegaHjärna>();
        ui = GameObject.FindGameObjectWithTag("UI").GetComponent<uiInteraktioner>();
        lampa = GetComponentInChildren<LampaLjus>();
        väggKontroll = GetComponentInChildren<KontrollerVägg>();

        lampa.StängAv();
    }

    void Update()
    {
        if (ärIRummet == true)
        {
            if (harStartTid == false)
            {
                startTid = Time.time;
                timer = 5 + Time.time;
                

                harStartTid = true;
                if (förstaRummet == false)
                {
                    väggKontroll.Stäng();
                }
            }

            if (VadRummetSkaGöra[VadRummetSkaGöra.Length - 1] == 2)
            {
                KlarMedRum();
            }
            else
            {
                SpelaInTid();

                ÄrIRummet();
            }

        }
    }

    void ÄrIRummet()
    {
        if (timer <= Time.time)
        {
            for (int i = 0; i < VadRummetSkaGöra.Length; i++)
            {
                if (VadRummetSkaGöra[i] != 2)
                {
                    plats = i;

                    if (VadRummetSkaGöra[i] == 0)
                    {
                        Blinka();
                        break;
                    }
                    else if (VadRummetSkaGöra[i] == 1)
                    {
                        SpelaLjud();
                        break;
                    }
                }
            }
        }
    }

    void SpelaInTid()
    {
        tid = Time.time;
    }

    void Blinka()
    {
        if (blink == true)
        {
            lampa.SättPå();
            blinkPå = true;
            blink = false;
            UpdateraTimern(2, true);
        }

        if (AndraTimer <= 0)
        {
            SlutaBlinka();
        }
        else
        {
            AndraTimer--;
        }
    }

    void SpelaLjud()
    {
        if (ljudSpelas == true)
        {
            ljudKäll.Play();
            ljudPå = true;
            ljudSpelas = false;
            UpdateraTimern(2, false);
        }

        if (AndraTimer <= Time.time)
        {
            SlutaSpelaLjud();
        }
    }

    public void SlutaBlinka()
    {
        Debug.Log("ny tid");
        lampa.StängAv();
        blinkPå = false;
        blink = true;

        UpdateraTimern(2, true);
        UpdateraTimern(1, true);
    }

    public void SlutaSpelaLjud()
    {
        ljudKäll.Stop();
        UpdateraTimern(1, false);
        ljudPå = false;
        ljudSpelas = true;
    }

    void KlarMedRum()
    {
        blinkPå = false;
        lampa.StängAv();

        ljudPå = false;
        ljudKäll.Stop();

        ärIRummet = false;
        tid = Time.time;
        Resultaten();

        if (rumNummer != megaHj.rum.Length)
        {
            väggKontroll.Öppna(false);
            megaHj.KameraFöljKaraktär();
            megaHj.rum[rumNummer].GetComponentInChildren<KontrollerVägg>().Öppna(true);
        }
        else
        {
            ui.TändAvslutningsSkärm();
        }
    }

    void Resultaten()
    {
        tid -= startTid;
        megaHj.SättIhopRumResultat(rummID, tid);
    }

    void UpdateraTimern(int vilkenTimer, bool blink)
    {
        if (vilkenTimer == 1)
        {
            timer = SlumpaVänta(min, max) + Time.time;
        }

        if (vilkenTimer == 2 && blink == true)
        {
            AndraTimer = blinkTid + Time.time;
        }
        else if (vilkenTimer == 2 && blink == false)
        {
            AndraTimer = väntaLjud + Time.time;
        }

    }

    int SlumpaVänta(int min, int max)
    {
        int vänta = Random.Range(min, max);
        return vänta;
    }

}