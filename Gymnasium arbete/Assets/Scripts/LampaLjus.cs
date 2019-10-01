using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampaLjus : MonoBehaviour
{
    public Material mat;

    public void SättPå()
    {
        mat.SetColor("_Color", Color.yellow);
    }

    public void StängAv()
    {
        mat.SetColor("_Color", Color.gray);
    }
}
