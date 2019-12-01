using System.Collections;
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
    public int väntaLjud; //Tid som låter ljudet spela klart
    public int tidMellanLjud; //Tiden mellan ljudet;
    public string rummID; //Ett id för rummet, används när tiderna antecknas
    public int rumNummer;
    public Object spelareIRum;

    public AudioSource ljudKäll;

    public bool blinkPå = false;
    public bool ljudPå = false;
    public bool ärIRummet = false;

    public float tid;
    public float startTid;

    private float timer;
    private float AndraTimer;
    private bool harStartTid = false;
    private bool byteMellanBlinkOchLjud = false;

    private LampaLjus lampa;
    private MegaHjärna megaHj;
    public KontrollerVägg väggKontroll;

    private void Start()
    {
        lampa = GetComponentInChildren<LampaLjus>();
        megaHj = GameObject.FindGameObjectWithTag("RummKontroller").GetComponent<MegaHjärna>();
        väggKontroll = GetComponentInChildren<KontrollerVägg>();

        timer = 5;
        AndraTimer = blinkTid;

        lampa.StängAv();
    }

    void Update()
    {
        if (ärIRummet == true)
        {
            if (harStartTid == false)
            {
                startTid = Time.time;
                harStartTid = true;
                väggKontroll.Stäng();
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
                    byteMellanBlinkOchLjud = false;

                    if (VadRummetSkaGöra.Length == VadRummetSkaGöra.Length || VadRummetSkaGöra[i] != VadRummetSkaGöra[i + 1])
                    {
                        byteMellanBlinkOchLjud = true;
                    }

                    if (VadRummetSkaGöra[i] == 0)
                    {
                        Blinka();
                        break;
                    }
                    else if (VadRummetSkaGöra[i] == 1)
                    {
                        SpelaLjud(byteMellanBlinkOchLjud);
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
        blinkPå = true;
        lampa.SättPå();

        if (AndraTimer <= 0)
        {
            Debug.Log("ny tid");
            lampa.StängAv();
            blinkPå = false;

            AndraTimer = blinkTid;
            timer = SlumpaVänta(min + 5, max + 5) + Time.time;

        }
        else
        {
            AndraTimer--;
        }
    }

    void SpelaLjud(bool byter)
    {
        if (AndraTimer <= Time.time)
        {
            Debug.Log("Ljud på");
            if (byter == true)
            {
                timer = SlumpaVänta(min, max) + Time.time;
            }
            else
            {
                timer = SlumpaVänta(min + tidMellanLjud, max + tidMellanLjud) + Time.time;
            }

            ljudPå = true;
            AndraTimer = väntaLjud;
            ljudKäll.Play();
        }
        else
        {
            ljudPå = false;
            AndraTimer--;
        }
    }

    void KlarMedRum()
    {
        //blinkPå = false;
        //lampa.StängAv();

        //ljudPå = false;
        //ljudKäll.Stop();

        ärIRummet = false;
        Resultaten();


        väggKontroll.Öppna(false);
        megaHj.KameraFöljKaraktär();
        megaHj.rum[rumNummer].GetComponentInChildren<KontrollerVägg>().Öppna(true);
    }

    void Resultaten()
    {
        tid -= startTid;
        megaHj.SättIhopRumResultat(rummID, tid);
    }

    int SlumpaVänta(int min, int max)
    {
        int vänta = Random.Range(min, max);
        return vänta;
    }

}