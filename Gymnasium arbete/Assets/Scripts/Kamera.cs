using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamera : MonoBehaviour
{
    private GameObject player;
    public int kamerasExtraPositionY;
    private bool följKaraktär = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (följKaraktär == true)
        {
            transform.localPosition = new Vector3(player.transform.position.x, player.transform.position.y + kamerasExtraPositionY, transform.position.z);
        }
    }
    public void FöljKaraktär()
    {
        följKaraktär = true;
    }
    public void SlutaFöljKaraktär(Vector3 newPosition)
    {
        följKaraktär = false;

        transform.localPosition = newPosition;
    }
}
