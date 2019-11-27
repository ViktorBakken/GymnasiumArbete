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
    private float secondTimer;
    private bool harStartTid = false;

    private LampaLjus lampa;
    private MegaHjärna megaHj;
    private Animator aniVägg;
    private KontrollerVägg vägg;

    private void Start()
    {
        lampa = GetComponentInChildren<LampaLjus>();
        megaHj = GameObject.FindGameObjectWithTag("RummKontroller").GetComponent<MegaHjärna>();
        aniVägg = GameObject.FindGameObjectWithTag("Vägg").GetComponent<Animator>();
        vägg = GameObject.FindGameObjectWithTag("Anim").GetComponent<KontrollerVägg>();

        timer = 5;
        secondTimer = blinkTid;

        lampa.StängAv();
        vägg.StängIngångsDörr();
    }

    void Update()
    {
        if(ärIRummet == false)
        {
            ÄrSpelarenIRum();
        }
        else
        {
            if (harStartTid == false)
            {
                startTid = Time.time;
                harStartTid = true;
                vägg.StängIngångsDörr();
            }

            SpelaInTid();

            ÄrIRummet();
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
                else if (VadRummetSkaGöra[VadRummetSkaGöra.Length - 1] == 2)
                {
                    KlarMedRum();
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
            timer = SlumpaVänta(min + tidMellanLjud, max + tidMellanLjud) + Time.time;
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

        aniVägg.Play("VäggAnimation");
        megaHj.KameraFöljKaraktär();
        megaHj.rum[rumNummer].GetComponentInChildren<KontrollerVägg>().ÖppnaIngångsDörr();
    }

    int SlumpaVänta(int min, int max)
    {
        int vänta = Random.Range(min, max);
        return vänta;
    }

    void ÄrSpelarenIRum()
    {

    }
}