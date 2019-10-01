using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public int speed;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime);
    }
}
