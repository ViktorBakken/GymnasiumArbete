using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class uiInteraktioner : MonoBehaviour
{
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

    [SerializeField] private int poäng = 0;
    [SerializeField] private float extraHöjd;
    [SerializeField] private float sidaMin;
    [SerializeField] private float sidaMax;
    [SerializeField] private GameObject poppUpPoäng;
    [SerializeField] private GameObject AvslutningsSkärm;

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
        Vector2 globalPosition = Camera.main.WorldToScreenPoint(position.position + new Vector3(Slump(sidaMin, sidaMax + 1), Slump(1, extraHöjd + 1), 0));
        GameObject effekt = Instantiate(poppUpPoäng);

        effekt.GetComponentInChildren<TextMeshProUGUI>().text = poäng.ToString();
        effekt.transform.SetParent(transform, false);
        effekt.transform.position = globalPosition;
        effekt.GetComponentInChildren<Animator>().Play(0);

        Destroy(effekt, effekt.GetComponentInChildren<Animator>().GetCurrentAnimatorClipInfo(0).Length);
    }

    public void TändAvslutningsSkärm()
    {
        AvslutningsSkärm.SetActive(true);
        Time.timeScale = 0;
    }

    float Slump(float min, float max)
    {
        float värde = Random.Range(min, max);
        return värde;
    }
}
