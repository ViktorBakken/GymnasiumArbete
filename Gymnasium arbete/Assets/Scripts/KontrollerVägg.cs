using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class KontrollerVägg : MonoBehaviour
{
    public string animVänstraDörrÖppna;
    public string animVänstraDörrStäng;
    public string animHögraDörrÖppna;


    public GameObject väggar;
    public Animator animVänster;
    public Animator animHöger;

    void Start()
    {
        animVänster = GetComponentInChildren<Animator>();
        animHöger = väggar.GetComponentInChildren<Animator>();
        //animVänster = FindComponentInChildWithTag<Animator>(gameObject, "VäggVänster");

    }

    public void ÖppnaIngångsDörr()
    {
        animVänster.Play(animVänstraDörrÖppna);
    }

    public void StängIngångsDörr()
    {
        animVänster.Play(animVänstraDörrStäng);
    }

    public void ÖppnaUtgången()
    {
        animHöger.Play(animHögraDörrÖppna);
    }

    //public static T FindComponentInChildWithTag<T>(this GameObject parent, string tag) where T : Component
    //{
    //    Transform t = parent.transform;
    //    foreach (Transform tr in t)
    //    {
    //        if (tr.tag == tag)
    //        {
    //            return tr.GetComponent<T>();
    //        }
    //    }
    //    return null;
    //}
}
