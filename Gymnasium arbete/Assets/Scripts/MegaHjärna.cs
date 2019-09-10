using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    public List<float> tider;
    public GameObject rum;
    public bool slutaSpelaIn = false;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpelaInTid()
    {
        float startTid = Time.time;
        
        while(slutaSpelaIn == true)
        {
            timer = Time.time;
        }

        timer -= startTid;
        tider.Add(timer);
    }
}
