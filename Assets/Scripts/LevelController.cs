﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
	[SerializeField] float waitToLoadNextScene = 4f;
	[SerializeField] GameObject loseLabel;
	[SerializeField] GameObject winLabel;

	int numberOfAttackers = 0;
	bool levelTimerFinished = false;

	private void Start()
	{
		loseLabel.SetActive( false );
		winLabel.SetActive( false );
	}

	public void AttackerSpawned()
	{
		numberOfAttackers++;
	}

	public void AttackerKilled()
	{
		numberOfAttackers--;

		if( numberOfAttackers <= 0 && levelTimerFinished )
		{
			StartCoroutine( HandleWinCondition() );
		}
	}

	IEnumerator HandleWinCondition()
	{
		GetComponent<AudioSource>().Play();
		winLabel.SetActive( true );
		yield return new WaitForSeconds( waitToLoadNextScene );
		GetComponent<LevelLoader>().LoadNextScene();
	}

	public void HandleLoseCondition()
	{
		loseLabel.SetActive( true );
		Time.timeScale = 0;
	}

	public void LevelTimerFinished()
	{
		levelTimerFinished = true;
		StopSpawners();
	}

	private void StopSpawners()
	{
		AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();

		foreach ( AttackerSpawner spawner in spawners )
		{
			spawner.StopSpawning();
		}
	}
}