using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class pelarController : MonoBehaviour
{
    public int pelarFärg; //blå == 0, svart == 1, röd == 2
    public string pelarFärg2;

    private MegaHjärna MegaHj;
    private RumInteraktion rumIn;
    private LampaLjus lampa;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        MegaHj = GameObject.FindGameObjectWithTag("RummKontroller").GetComponent<MegaHjärna>(); // Koden skapar en link till MH(Mega Hjärna)
        rumIn = GetComponentInParent<RumInteraktion>();
        lampa = GetComponentInParent<LampaLjus>();
        anim = GetComponentInChildren<Animator>();
    }

    void OnTriggerStay2D(Collider2D collision)  //Medans spelaren nuddar en pelare.
    {
        if (collision.tag == "Player" && Input.GetKeyDown(KeyCode.Space)) // Om det som nuddar pelaren är spelare och om spelaren trycker på space
        {
            float tid = rumIn.tid -= rumIn.startTid;
            MegaHj.knappTryck[pelarFärg]++; // När spelaren trycker space på pelaren spelas det in i, beroende på färg av pelare, den respektive int
            MegaHj.knappOrdning.Add(pelarFärg2 + "; " + tid.ToString() + "  ");

            anim.SetBool(MegaHj.aniKnapp, true);

            Debug.Log("Nice");

            if (rumIn.blinkPå == true && pelarFärg == 0)
            {
                SlutaBlinka();
            }

            if (rumIn.ljudPå == true && pelarFärg == 2)
            {
                SlutaSpelaLjud();
            }
        }
    }

    void SlutaBlinka()
    {
        rumIn.VadRummetSkaGöra[rumIn.plats] = 2;
        lampa.StängAv();
        Debug.Log("Fungerar!");
    }
    void SlutaSpelaLjud()
    {
        rumIn.VadRummetSkaGöra[rumIn.plats] = 2;
        rumIn.ljudKäll.Stop();
        rumIn.ljudPå = false;
        Debug.Log("Tyst!!!!!!");
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            anim.SetBool(MegaHj.aniKnapp, false);
        }
    }
}
