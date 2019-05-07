using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LivesDisplay : MonoBehaviour
{
	[SerializeField] float baseLives = 3f;

	float lives;
	TextMeshProUGUI livesText;

	void Start()
	{
		lives = baseLives - PlayerPrefsController.GetDifficulty();
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
			FindObjectOfType<LevelController>().HandleLoseCondition();
		}
	}
}