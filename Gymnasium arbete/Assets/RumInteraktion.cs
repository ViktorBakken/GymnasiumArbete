using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RumInteraktion : MonoBehaviour
{

    private SpriteRenderer ljus;

    private void Start()
    {
        ljus = GameObject.FindGameObjectWithTag("Ljus").GetComponent<SpriteRenderer>();
    }

    public void LampBlinka()
    {
        
    }
}
