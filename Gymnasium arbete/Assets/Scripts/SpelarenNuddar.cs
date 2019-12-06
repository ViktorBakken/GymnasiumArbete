using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpelarenNuddar : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GetComponentInParent<RumInteraktion>().ärIRummet = true;
            GameObject.FindGameObjectWithTag("RummKontroller").GetComponent<MegaHjärna>().KameraSlutaFöljaKaraktär();
            Destroy(this.gameObject);
        }
    }
}
