using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterControl : MonoBehaviour {

    Rigidbody2D rb;
    float moveSpeed;
   
    
    // Use this for initialization
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();

        moveSpeed = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        MoveMonster();
    }

    void MoveMonster()
    {
        rb.velocity = new Vector2( 0, -moveSpeed);
        
     
    }

}
