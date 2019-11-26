using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class KontrollerVägg : MonoBehaviour
{
    public string animVäggÖppna;

    private Animator animVänster;

    void Start()
    {
        animVänster = GetComponentInChildren<Animator>();
    }

    public void ÖppnaIngångsDörr()
    {
        animVänster.SetBool(animVäggÖppna, true);
    }

    public void StängIngångsDörr()
    {
        animVänster.SetBool(animVäggÖppna, false);
    }
}
