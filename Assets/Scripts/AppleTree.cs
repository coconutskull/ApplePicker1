using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Inscribed")]
    //Prefab for instantiating apples
    public GameObject applePrefab;
        //Speed of Tree
    public float speed = 1f;
        //Distance that the Tree turns around
    public float leftAndRightEdge = 10f;
        //Chance the Tree will change directions
    public float changeDirChance = 0.1f;
        //Seconds between Apples instantiations
    public float appleDropDelay = 1f;
        // Start is called before the first frame update
    void Start()
    {
        //Drop apples
        Invoke("DropApple", 2f);
    }

    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", appleDropDelay);
    }

    // Update is called once per frame
    void Update()
    {
        //Basic movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
        
        //Changing Direction
        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed); //Move Right
        } else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed); //Move Left
        //} else if (Random.value < changeDirChance)
        //{
        //    speed *= -1; //Change direction
        }
    }

    void FixedUpdate()
    {
        // Random direction changes are now time-based due to FixedUpdate()
        if (Random.value < changeDirChance)
        {
            speed *= -1; // Change direction
        }
    }

	void OnCollisionEnter (Collision coll)
	{
		//find out what hit this basket
		GameObject collidedWith = coll.gameObject;
		if (collidedWith.CompareTag("Apple"))
			{
				Destroy(collidedWith);
			}
	}
}
