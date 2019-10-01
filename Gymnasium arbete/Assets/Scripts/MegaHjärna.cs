using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegaHjärna : MonoBehaviour
{

    
    public float tider; // En variable som används för att 
    public int[] knappTryck = { 0, 0, 0 };
    public List<string> rumResultat;
    public GameObject rum;
    public bool slutaSpelaIn = false;

    private float timer;

    public void SpelaInTid() //Metod som används för att börja spela in tiden
    {
        float startTid = Time.time; //Vi tar reda på tiden när vi börjar spela in

        if (slutaSpelaIn == false) // 
        {
            timer = Time.time;
        }

        timer -= startTid;
        tider = timer;
    }
    public void SättIhopRumResultat(int rumNum) //rum nummer, tid, antalet gånger du rör: blåa, svarta, röda 
    {
        rumResultat.Add("RumNummer: " + rumNum + ", Tid: " + tider + ", Blå: " + knappTryck[0] + ", Svart: " + knappTryck[1] + ", Röd: " + knappTryck[2]);

        for (int i = 0; i < knappTryck.Length; i++)
        {
            knappTryck[i] = 0;
        }
        tider = 0;
    }

    private void Update()
    {
        Debug.Log(knappTryck[0] + "," + knappTryck[1] + "," + knappTryck[2]);
    }
}
