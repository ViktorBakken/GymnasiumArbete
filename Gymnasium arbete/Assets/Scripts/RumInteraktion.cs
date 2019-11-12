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
    public string rummID; //Ett id för rummet, används för att anteckna

    public AudioSource ljudKäll;

    public bool blinkPå = false;
    public bool ljudPå = false;
    public bool ärIRummet = false;

    public float tid;
    public float startTid;


    private float timer;
    private float secondTimer;
    private bool harStartTid = false;

    private LampaLjus lampa;
    private MegaHjärna megaHj;
    private Animator aniVägg;

    private void Start()
    {
        lampa = GameObject.FindGameObjectWithTag("Lampa").GetComponent<LampaLjus>();
        megaHj = GameObject.FindGameObjectWithTag("RummKontroller").GetComponent<MegaHjärna>();

        timer = 5;
        secondTimer = blinkTid;

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
            }

            SpelaInTid();

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
                    else if (VadRummetSkaGöra[VadRummetSkaGöra.Length - 1] == 2)
                    {
                        Debug.Log("Klar med rum");
                        KlarMedRum();

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

        if (secondTimer <= 0)
        {
            Debug.Log("ny tid");
            lampa.StängAv();
            blinkPå = false;

            secondTimer = blinkTid;
            timer = SlumpaVänta(min + 5, max + 5) + Time.time;

        }
        else
        {
            secondTimer--;
        }
    }

    void SpelaLjud()
    {
        ljudPå = false;
        if (secondTimer <= Time.time)
        {
            Debug.Log("Ljud på");
            timer = SlumpaVänta(min + 10, max + 10) + Time.time;
            ljudPå = true;
            secondTimer = väntaLjud;
            ljudKäll.Play();
        }
        else
        {
            secondTimer--;
        }
    }

    void KlarMedRum()
    {
        blinkPå = false;
        lampa.StängAv();

        ljudPå = false;
        ljudKäll.Stop();


        ärIRummet = false;
        tid -= startTid;
        megaHj.SättIhopRumResultat(rummID, tid);
    }

    int SlumpaVänta(int min, int max)
    {
        int vänta = Random.Range(min, max);
        return vänta;
    }
}
