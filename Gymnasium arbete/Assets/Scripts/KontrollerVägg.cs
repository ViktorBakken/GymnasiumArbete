using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class KontrollerVägg : MonoBehaviour
{
    public string animVäggÖppna;
    public string animVäggStäng;

    private Animator animVänster;

    void Start()
    {
        animVänster = GameObject.FindGameObjectWithTag("VäggVänster").GetComponent<Animator>();
    }

    public void ÖppnaIngångsDörr()
    {
        animVänster.SetBool(animVäggStäng, false);
        animVänster.SetBool(animVäggÖppna, true);
    }

    public void StängIngångsDörr()
    {
        animVänster.SetBool(animVäggÖppna, false);
        animVänster.SetBool(animVäggStäng, true);

    }
}
