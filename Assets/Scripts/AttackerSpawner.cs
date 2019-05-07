using System.Collections;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
	[SerializeField] Attacker[] attackers;
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

	public void StopSpawning()
	{
		isSpawning = false;
	}

	private void SpawnAttacker()
	{
		int attackerIndex = UnityEngine.Random.Range( 0, attackers.Length );

		Attacker newAttacker = Instantiate( attackers[attackerIndex], transform.position, Quaternion.identity ) as Attacker;
		newAttacker.transform.parent = transform;
	}
}