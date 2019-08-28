using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTerrain : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ( collision.gameObject.name == "plastic(Clone)" || collision.gameObject.name == "beer(Clone)" || collision.gameObject.name == "paper(Clone)"|| collision.gameObject.name == "organico(Clone)"|| collision.gameObject.name == "indiff(Clone)")
        {
            //ScoreScript.scoreValue -= 1;
            Destroy(collision.gameObject);
        }
        
    }
}

