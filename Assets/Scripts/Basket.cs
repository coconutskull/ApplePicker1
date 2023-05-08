using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Basket : MonoBehaviour
{
    public ScoreCounter scoreCounter;
    void Start()
    {
        //find GameObject named ScoreCounter in Scene Hierarchy
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        //Get the ScoreCounter (script) component of scoreGO
        scoreCounter = scoreGO.GetComponent<ScoreCounter>();
    }

    void Update()
    {
        Vector3 mousePos2D = Input.mousePosition; //Get current screen position from input for mouse
        
        //Camera position on how far to push mouse into 3d
        //if causes a NullReferenceException, select main camera
        //in the hierarchy and set its tag to MainCamera in the inspector.

        mousePos2D.z = -Camera.main.transform.position.x;
        
        //Covert the pt from 2d to 3d world space
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
        
        //move the x position of this Basket to the x position of the mouse
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;

    }

	void OnCollisionEnter( Collision coll){
		//Find out what hits basket
		GameObject collidedWith = coll.gameObject;
		if (collidedWith.CompareTag("Apple")){
			Destroy(collidedWith);
		//increase score
			scoreCounter.score += 100;
			HighScore.TRY_SET_HIGH_SCORE(scoreCounter.score);
		}
	}
}
