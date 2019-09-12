using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pelarController : MonoBehaviour
{
    public int pelareFärg; //blå == 0, svart == 1, röd == 2

    private MegaHjärna MH;
    // Start is called before the first frame update
    void Start()
    {
        MH = GameObject.FindGameObjectWithTag("RoomController").GetComponent<MegaHjärna>();
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && Input.GetKeyDown(KeyCode.Space))
        {
            MH.knappTryck[pelareFärg]++;
        }
    }
}
