using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTouch : MonoBehaviour
{

    private bool keyPressedright, keyPressedleft;
    public float speed = 6.0f;
    public Rigidbody2D rb;


    private Vector3 moveDirection = Vector3.zero;

    public void Start()
    {
        keyPressedright = false;
        keyPressedleft = false;
    }

    private void Update()
    {
        if (keyPressedright)
        {
            moveright();
        }
        else if (keyPressedleft)
        {
            moveLeft();
        }
    }
    public void onPressR()
    {
        keyPressedright = true;
        moveright();
    }

    public void onRelaseR()
    {
        keyPressedright = false;
    }

    public void onPressL()
    {
        keyPressedleft = true;
        moveright();
    }

    public void onRelaseL()
    {
        keyPressedleft = false;
    }

    public void moveright()
    {
        rb.transform.Translate(0.3f, 0, 0);
    }

    public void moveLeft()
    {
        rb.transform.Translate(-0.3f, 0, 0);


    }





}
