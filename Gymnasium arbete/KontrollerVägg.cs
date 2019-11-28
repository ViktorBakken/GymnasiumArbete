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
        //GetComponentInChildren<Animator>();
        animVänster = FindComponentInChildWithTag<Animator>(gameObject, "VäggVänster");
    }

    public void ÖppnaIngångsDörr()
    {
        animVänster.Play(animVäggÖppna);
    }

    public void StängIngångsDörr()
    {
        animVänster.Play(animväggStäng);
    }

    public static T FindComponentInChildWithTag<T>(this GameObject parent, string tag) where T : Component
    {
        Transform t = parent.transform;
        foreach (Transform tr in t)
        {
            if (tr.tag == tag)
            {
                return tr.GetComponent<T>();
            }
        }
        return null;
    }
}
