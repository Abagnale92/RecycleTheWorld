using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DragTouch : MonoBehaviour
{

    // Update is called once per frame
    public float speed = 0.1F;
    void Update()
    {
            transform.Translate(Input.acceleration.x, 0, 0);
    
    }
}
