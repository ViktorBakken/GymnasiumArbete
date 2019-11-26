using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class MegaHjärna : MonoBehaviour
{
    public int[] knappTryck = { 0, 0, 0 };
    public List<string> knappOrdning = new List<string>();
    public List<string> rumResultat = new List<string>();
    public GameObject[] rum;
    public GameObject kamera;
    public string aniKnapp;
    public string aniVägg;

    private Vector3 newPosition;

    void Start()
    {
        rum[0].GetComponent<RumInteraktion>().ärIRummet = true;
    }

    public void SättIhopRumResultat(string rummID, float tid) //rum nummer, tid, antalet gånger du rör: blåa, svarta, röda 
    {
        string sammansatt = string.Join(",", knappOrdning.ToArray()); //Tack micke för den smaskiga koden!!!

        rumResultat.Add("RumID: " + rummID + ",  Tid: " + tid + ",  Blå: " + knappTryck[0] + ", Svart: " + knappTryck[1] + ",   Röd: " + knappTryck[2] + ",   Knapp Ordning: " + sammansatt);

        File.WriteAllLines(@"data.txt", rumResultat.ToArray());

        RensaVariabler();
    }

    private void RensaVariabler()
    {
        for (int i = 0; i < knappTryck.Length; i++)
        {
            knappTryck[i] = 0;

        } //

        for (int i = 0; i < knappOrdning.Count; i++)
        {
            knappOrdning.RemoveAt(0);
        }
    }

    public void KameraFöljKaraktär()
    {
        kamera.GetComponent<Kamera>().FöljKaraktär();
    }

    public void KameraSlutaFöljaKaraktär()
    {
        for (int i = 0; i < rum.Length; i++)
        {
            if (rum[i].GetComponent<RumInteraktion>().ärIRummet == true)
            {
                newPosition = rum[i].transform.position + new Vector3(0, 0, -15);
            }
        }
        kamera.GetComponent<Kamera>().SlutaFöljKaraktär(newPosition);
    }
}
