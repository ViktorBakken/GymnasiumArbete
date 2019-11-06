using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

    public int fart;
    public float rotation;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Input.GetAxisRaw("Vertical") * fart * Time.time);

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.Rotate(new Vector3(0, transform.rotation.y - rotation, 0));
        }
        
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.Rotate(new Vector3(0, transform.rotation.y + rotation, 0));
        }
    }
}
