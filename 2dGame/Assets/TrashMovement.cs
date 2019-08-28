using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashMovement : MonoBehaviour {
    

    public float speed = 6.0f;



    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {
       
    }

    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * speed;
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        

        if (collision.gameObject.name == "plastic(Clone)")
        {
            ScoreScript.scoreValue += 3;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.name == "beer(Clone)")
        {
            ScoreScript.scoreValue -= 1;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.name == "paper(Clone)")
        {
            ScoreScript.scoreValue -= 1;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.name == "organico(Clone)")
        {
            ScoreScript.scoreValue -= 1;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.name == "indiff(Clone)")
        {
            ScoreScript.scoreValue -= 1;
            Destroy(collision.gameObject);

        }
    }
}

