using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RumInteraktion : MonoBehaviour
{
    public int[] VadRummetSkaGöra; //0 == blinka, 1 == ljud, 2 == utfört.
    public int min;
    public int max;
    public int blinkTid;
    public int plats;
    public int vänta = 5;

    public AudioSource ljudKäll;

    public bool blinkPå = false;
    public bool ljudPå = false;
    public bool ärIRummet = false;

    private float timer;
    private float secondTimer;
    private LampaLjus lampa;

    private void Start()
    {
        lampa = GameObject.FindGameObjectWithTag("Lampa").GetComponent<LampaLjus>();

        timer = vänta;
        secondTimer = blinkTid;

        lampa.StängAv();
    }

    void Update()
    {
        Debug.Log(timer);
        if (ärIRummet == true)
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
                    
                    if (i == VadRummetSkaGöra.Length)
                    {
                        Debug.Log("Klar med rum");
                        KlarMedRum();
                    }
                }
            }
        }

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
        ljudPå = true;
        timer = SlumpaVänta(min, max) + Time.time;
        ljudKäll.Play();
    }

    void KlarMedRum()
    {
        lampa.StängAv();
        ljudKäll.Stop();

        //Öppna dörr
    }

    int SlumpaVänta(int min, int max)
    {
        int vänta = Random.Range(min, max);
        return vänta;
    }
}
