﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampaLjus : MonoBehaviour
{
    public Material mat;


    public void SättPå()
    {
        mat.color = Color.yellow;
    }

    public void StängAv()
    {
        mat.color = Color.gray;
    }
}
