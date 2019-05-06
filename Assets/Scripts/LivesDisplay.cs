using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LivesDisplay : MonoBehaviour
{
	[SerializeField] int lives = 60;

	TextMeshProUGUI livesText;

	void Start()
	{
		livesText = GetComponent<TextMeshProUGUI>();
		UpdateDisplay();
	}

	private void UpdateDisplay()
	{
		livesText.text = lives.ToString();
	}

	public void TakeLives( int amount )
	{
		if ( lives >= amount )
		{
			lives -= amount;
			UpdateDisplay();
		}

		if( lives <= 0 )
		{
			FindObjectOfType<LevelLoader>().LoadGameOver();
		}
	}
}