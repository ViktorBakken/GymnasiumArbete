using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pelarController : MonoBehaviour
{
    public int pelarFärg; //blå == 0, svart == 1, röd == 2
    public string pelarFärg2;

    private MegaHjärna MegaHj;
    private RumInteraktion rumIn;
    private LampaLjus lampa;
    // Start is called before the first frame update
    void Start()
    {
        MegaHj = GameObject.FindGameObjectWithTag("RummKontroller").GetComponent<MegaHjärna>(); // Koden skapar en link till MH(Mega Hjärna)
        rumIn = GameObject.FindGameObjectWithTag("Rum").GetComponent<RumInteraktion>();
        lampa = GameObject.FindGameObjectWithTag("Lampa").GetComponent<LampaLjus>();
    }

    void OnTriggerStay2D(Collider2D collision)  //Medans spelaren nuddar en pelare.
    {
        if (collision.tag == "Player" && Input.GetKeyDown(KeyCode.Space)) // Om det som nuddar pelaren är spelare och om spelaren trycker på space
        {
            float tid = rumIn.tid -= rumIn.startTid;
            MegaHj.knappTryck[pelarFärg]++; // När spelaren trycker space på pelaren spelas det in i, beroende på färg av pelare, den respektive int
            MegaHj.knappOrdning.Add(pelarFärg2 + "; " + tid.ToString() + "  ");
            Debug.Log("Nice");

            if (rumIn.blinkPå == true && pelarFärg == 0) 
            {
                rumIn.VadRummetSkaGöra[rumIn.plats] = 2;
                lampa.StängAv();
                Debug.Log("Fungerar!");
            }

            if (rumIn.ljudPå == true && pelarFärg == 2)
            {
                rumIn.VadRummetSkaGöra[rumIn.plats] = 2;
                rumIn.ljudKäll.Stop();
                Debug.Log("Tyst!!!!!!");


            }
        }
    }
}
