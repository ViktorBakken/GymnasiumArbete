using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pelarController : MonoBehaviour
{
    public int pelarFärg; //blå == 0, svart == 1, röd == 2


    private float timer;
    private bool lampaPå = false;
    private MegaHjärna MH;
    private LampaLjus lampLj;
    // Start is called before the first frame update
    void Start()
    {
        MH = GameObject.FindGameObjectWithTag("RoomController").GetComponent<MegaHjärna>(); // Koden skapar en link till MH(Mega Hjärna)
        lampLj = GameObject.FindGameObjectWithTag("Lampa").GetComponent<LampaLjus>();
    }

    void Update()
    {
        if (pelarFärg == 2 && timer <= Time.time && lampaPå == true)
        {
            timer = 0;

            lampaPå = false;

            lampLj.StängAv();
        }
    }

    void OnTriggerStay2D(Collider2D collision)  //Medans spelaren nuddar en pelare.
    {
        if (collision.tag == "Player" && Input.GetKeyDown(KeyCode.Space)) // Om det som nuddar pelaren är spelare och om spelaren trycker på space
        {
            MH.knappTryck[pelarFärg]++; // När spelaren trycker space på pelaren spelas det in i, beroende på färg av pelare, den respektive int
        }
    }

    void OnTriggerExit(Collider collision)
    {
        lampLj.StängAv();
    }
}
