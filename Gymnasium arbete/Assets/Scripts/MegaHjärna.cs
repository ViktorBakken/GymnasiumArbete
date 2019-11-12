using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class MegaHjärna : MonoBehaviour
{
    public int[] knappTryck = { 0, 0, 0 };
    public List<string> knappOrdning = new List<string>();
    public List<string> rumResultat = new List<string>();
    public RumInteraktion[] rum;
    public string aniKnapp;

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
}
