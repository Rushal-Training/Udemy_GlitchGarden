using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DefenderButton : MonoBehaviour
{
	[SerializeField] Defender defenderPrefab;

	private void Start()
	{
		LabelButtonWithCost();
	}

	private void OnMouseDown()
	{
		var buttons = FindObjectsOfType<DefenderButton>();
		foreach( DefenderButton button in buttons )
		{
			button.GetComponent<SpriteRenderer>().color = new Color32( 71, 71, 71, 255 );
		}
		GetComponent<SpriteRenderer>().color = Color.white;

		FindObjectOfType<DefenderSpawner>().SetSelectedDefender( defenderPrefab );
	}

	private void LabelButtonWithCost()
	{
		TextMeshPro costText = GetComponentInChildren<TextMeshPro>();
		if( !costText )
		{
			Debug.LogError( name + " has no cost text, add some" );
		}
		else
		{
			costText.text = defenderPrefab.StarCost.ToString();
		}
	}

}
