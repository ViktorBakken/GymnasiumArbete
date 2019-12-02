using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class uiInteraktioner : MonoBehaviour
{
    [SerializeField] private int poäng = 0;
    public int Poäng
    {
        set
        {
            if (value > 0)
            {
                poäng = value;
            }
        }

        get
        {
            return poäng;
        }

    }

    [SerializeField] private GameObject poppUpPoäng;
    private TextMeshProUGUI text;


    void Start()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
    }

    void Update()
    {
        text.text = "Poäng: " + poäng.ToString();
    }

    public void PoppUpp(Transform position, int poäng)
    {
        Debug.Log("Whack");
        GameObject effekt = Instantiate(poppUpPoäng, transform);
        effekt.GetComponentInChildren<TextMeshProUGUI>().text = poäng.ToString();
        effekt.GetComponentInChildren<Animator>().Play(0);
        Destroy(effekt, effekt.GetComponentInChildren<Animator>().GetCurrentAnimatorClipInfo(0).Length);
    }
}
