using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
	[Tooltip("The time a level lasts in seconds.")]
	[SerializeField] float levelTime = 10f;

	bool isLevelFinished = false;

	void Update()
    {

		if(isLevelFinished) { return; }

		GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;

		bool timerFinished = ( Time.timeSinceLevelLoad >= levelTime );
		if( timerFinished )
		{
			FindObjectOfType<LevelController>().LevelTimerFinished();
			isLevelFinished = true;
		}
    }
}
