using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
	[SerializeField] Attacker attackerPrefab;
	[SerializeField] float minSpawnDelay = 1f;
	[SerializeField] float maxSpawnDelay = 5f;

	bool isSpawning = true;

    IEnumerator Start()
    {
        while(isSpawning)
		{
			yield return new WaitForSeconds( UnityEngine.Random.Range( minSpawnDelay, maxSpawnDelay ) );
			SpawnAttacker();
		}
    }

	private void SpawnAttacker()
	{
		Instantiate( attackerPrefab, transform.position, Quaternion.identity );
	}

	void Update()
    {
        
    }
}
