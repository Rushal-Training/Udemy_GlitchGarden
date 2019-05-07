using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
	AudioSource audioSource;

	private void Awake()
	{
		int numMusicPlayers = FindObjectsOfType<MusicPlayer>().Length;

		if ( numMusicPlayers > 1 )
		{
			gameObject.SetActive( false );
			Destroy( gameObject );
		}
		else
		{
			DontDestroyOnLoad( gameObject );
		}
	}

	void Start()
    {
		audioSource = GetComponent<AudioSource>();
		audioSource.volume = PlayerPrefsController.GetMasterVolume();
    }

	public void SetVolume( float volume )
	{
		audioSource.volume = volume;
	}
}
