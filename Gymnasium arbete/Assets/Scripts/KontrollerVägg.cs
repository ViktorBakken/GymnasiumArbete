using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class KontrollerVägg : MonoBehaviour
{
    public string animVäggÖppna;
    public string animväggStäng;

    private Animator animVänster;

    void Start()
    {
        animVänster = GetComponentInChildren<Animator>();
    }

    public void ÖppnaIngångsDörr()
    {
        animVänster.Play(animVäggÖppna);
    }

    public void StängIngångsDörr()
    {
        animVänster.Play(animväggStäng);
    }
}
