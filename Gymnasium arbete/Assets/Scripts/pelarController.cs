﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class pelarController : MonoBehaviour
{
    public string pelarFärgText;

    [SerializeField] private int pelarFärg; //blå == 0, svart == 1, röd == 2
    private MegaHjärna megaHj;
    private RumInteraktion rumIn;
    private LampaLjus lampa;
    private Animator anim;
    private uiInteraktioner ui;

    private bool pådragPoäng =false;

    // Start is called before the first frame update
    void Start()
    {
        megaHj = GameObject.FindGameObjectWithTag("RummKontroller").GetComponent<MegaHjärna>(); // Koden skapar en link till MH(Mega Hjärna)
        ui = GameObject.FindGameObjectWithTag("UI").GetComponent<uiInteraktioner>();
        rumIn = GetComponentInParent<RumInteraktion>();
        lampa = GetComponentInParent<LampaLjus>();
        anim = GetComponentInChildren<Animator>();
    }

    void OnTriggerStay2D(Collider2D collision)  //Medans spelaren nuddar en pelare.
    {
        if (collision.tag == "Player" && Input.GetKeyDown(KeyCode.Space)) // Om det som nuddar pelaren är spelare och om spelaren trycker på space
        {
            float tid = rumIn.tid -= rumIn.startTid;
            megaHj.knappTryck[pelarFärg]++; // När spelaren trycker space på pelaren spelas det in i, beroende på färg av pelare, den respektive int
            megaHj.knappOrdning.Add(pelarFärgText + "; " + tid.ToString() + " ");

            anim.SetBool(megaHj.aniKnapp, true);

            if (rumIn.blinkPå == true && pelarFärg == 0 || rumIn.ljudPå == true && pelarFärg == 2)
            {
                if (rumIn.blinkPå == true && pelarFärg == 0)
                {
                    rumIn.VadRummetSkaGöra[rumIn.plats] = 2;
                    rumIn.SlutaBlinka();
                }

                if (rumIn.ljudPå == true && pelarFärg == 2)
                {
                    rumIn.VadRummetSkaGöra[rumIn.plats] = 2;
                    rumIn.SlutaSpelaLjud();
                }
                ui.Poäng += megaHj.ökningPoäng;
                ui.PoppUpp(collision.transform, megaHj.ökningPoäng);
            }
            else
            {
                SkaDraAvPoäng(collision);
            }
        }
    }

    void SkaDraAvPoäng(Collider2D collision)
    {
        if (rumIn.blinkPå == true && pelarFärg != 0 || rumIn.ljudPå == true && pelarFärg != 2 || rumIn.blinkPå == false && rumIn.ljudPå == false || rumIn.ärIRummet == false)
        {
            ui.Poäng += megaHj.avdragPoäng;
            ui.PoppUpp(collision.transform, megaHj.avdragPoäng);
        }
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            anim.SetBool(megaHj.aniKnapp, false);
        }
    }
}
