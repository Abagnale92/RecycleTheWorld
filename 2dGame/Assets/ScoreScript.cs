using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {

    // Use this for initialization

    public static int scoreValue = 0;
     Text score;

    void Start()
    {
        score = GetComponent<Text>();
        
    }

        // Update is called once per frame
        void Update () {
            if(scoreValue <= 0){
               score.text = "Score " + 0; 
            }
            else{score.text = "Score " + scoreValue; }
		
	}

    
}
