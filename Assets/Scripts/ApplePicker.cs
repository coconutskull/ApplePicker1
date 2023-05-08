using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
    [Header("inscribed")] 
    public GameObject basketPrefab;
    public int numBaskets = 3;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
	public List<GameObject> basketList;
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0 ; i < numBaskets; i++)
        {
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGO.transform.position = pos;
			basketList.Add (tBasketGO);
        }
    }

	public void AppleMissed() 
	{
		//destroy falling apples
		GameObject[] appleArray=GameObject.FindGameObjectsWithTag("Apple");
			foreach (GameObject tempGO in appleArray)
			{
				Destroy (tempGO);
			}
			//Destroy one of the baskets
			//Get index of last basket
			int basketIndex = basketList.Count -1;
			//Get ref to Basket GameObject
			GameObject basketGO = basketList [basketIndex];
			//Remove basket
			basketList.RemoveAt(basketIndex);
			Destroy(basketGO);

			//If there are no Baskets left, restart the game
			if (basketList.Count ==0){
				SceneManager.LoadScene("_Scene_0");
			}
	}
}
