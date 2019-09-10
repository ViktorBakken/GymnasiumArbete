using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RumInteraktion : MonoBehaviour
{

    private Renderer lampa;

    private void Start()
    {
        lampa = GameObject.FindGameObjectWithTag("Lampa").GetComponent<Renderer>();
    }

    public void LampBlinka()
    {
        
    }
}
