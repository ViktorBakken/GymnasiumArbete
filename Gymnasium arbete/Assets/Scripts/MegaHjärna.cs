using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegaHjärna : MonoBehaviour
{    
    public int[] knappTryck = { 0, 0, 0 };
    public List<string> rumResultat;
    public RumInteraktion[] rum;

    void start()
    {
        rum[0].ärIRummet = true;
        //SpelaInTid(0);
    }

    public void SättIhopRumResultat(string rummID, float tid) //rum nummer, tid, antalet gånger du rör: blåa, svarta, röda 
    {
        rumResultat.Add("RumID: " + rummID + "\nTid: " + tid + "\nBlå: " + knappTryck[0] + "\nSvart: " + knappTryck[1] + "\nRöd: " + knappTryck[2]);

        for (int i = 0; i < knappTryck.Length; i++)
        {
            knappTryck[i] = 0;
        } //
    }

    private void Update()
    {
        //Debug.Log(knappTryck[0] + "," + knappTryck[1] + "," + knappTryck[2]);
    }
}
