using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //enables use of uGUI classes like text

public class ScoreCounter : MonoBehaviour
{
	[Header("Dynamic")]
	public int		score = 0;
	
	private Text	uiText;

    void Start()
    {
        uiText = GetComponent<Text>();
    }

    void Update()
    {
        uiText.text = score.ToString("#,0"); // 0 is zero!
    }
}
