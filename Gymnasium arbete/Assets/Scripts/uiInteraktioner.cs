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
<<<<<<< HEAD
        Vector2 globalPosition = Camera.main.WorldToScreenPoint(position.position);
        GameObject effekt = Instantiate(poppUpPoäng);
=======
        Debug.Log("Whack");
        GameObject effekt = Instantiate(poppUpPoäng, transform);
>>>>>>> 3c0fc3b448905ac7d20768b0b66880929e1fc964
        effekt.GetComponentInChildren<TextMeshProUGUI>().text = poäng.ToString();
        effekt.transform.SetParent(transform, false);
        effekt.transform.position = globalPosition;
        effekt.GetComponentInChildren<Animator>().Play(0);

        Destroy(effekt, effekt.GetComponentInChildren<Animator>().GetCurrentAnimatorClipInfo(0).Length);
    }
}
