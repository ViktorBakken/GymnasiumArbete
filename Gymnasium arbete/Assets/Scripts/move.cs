using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public int fart;
    public int hoppKraft;

    private bool nuddarMarken = false;
    private Vector2 rayPosition;
    private Rigidbody2D rig;
    private RaycastHit2D hit;

    void Start()
    {
        rig = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Debug.DrawRay(rayPosition,Vector2.down);
        rayPosition = new Vector2(transform.position.x, transform.position.y - 1);

        NuddarMarken();

        transform.Translate(Vector2.right * Input.GetAxisRaw("Horizontal") * fart * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.W) && nuddarMarken == true)
        {
            rig.AddForce(Vector2.up * hoppKraft);
        }
    }


    void NuddarMarken()
    {
        hit = Physics2D.Raycast(rayPosition, Vector2.down, 0.1f);

        if (hit == true)
        {
            nuddarMarken = true;
        }
        else
        {
            nuddarMarken = false;
        }

        Debug.Log(nuddarMarken);
    }
}
