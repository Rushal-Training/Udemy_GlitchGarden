﻿using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
	[SerializeField] int timeToWait = 3;

	int currentSceneIndex;

    void Start()
    {
		currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

		if( currentSceneIndex == 0 )
		{
			StartCoroutine( WaitForTime() );
		}
    }

	IEnumerator WaitForTime()
	{
		yield return new WaitForSeconds( timeToWait );
		LoadNextScene();
	}

	public void LoadMainMenu()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene( "Start Screen" );
	}

	public void RestartScene()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene( currentSceneIndex );
	}

	public void LoadNextScene()
	{
		SceneManager.LoadScene( currentSceneIndex + 1 );
	}

	public void LoadGameOver()
	{
		SceneManager.LoadScene( "Game Over" );
	}

	public void QuitGame()
	{
		Application.Quit();
	}
}