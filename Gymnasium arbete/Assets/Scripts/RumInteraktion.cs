using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RumInteraktion : MonoBehaviour
{

    public int min;
    public int max;
    public bool ärIRummet = false;

    private int vänta = 5;
    private float timer;
    private float secondTimer;
    private LampaLjus lampa;

    private void Start()
    {
        lampa = GameObject.FindGameObjectWithTag("Lampa").GetComponent<LampaLjus>();

        timer = Time.time + vänta;
        secondTimer = Time.time + 4;

        lampa.StängAv();
    }

    void Update()
    {
        if (ärIRummet == true)
        {
            if (timer <= Time.time)
            {
                lampa.SättPå();


                if (secondTimer <= Time.time)
                {
                    lampa.StängAv();
                    secondTimer = Time.time + 4;
                    
                    vänta = RandomiseVänta(min, max);

                    timer = vänta + Time.time;
                }


            }
        }
    }

    int RandomiseVänta(int min, int max)
    {
        int vänta = Random.Range(min, max);
        return vänta;
    }
}
