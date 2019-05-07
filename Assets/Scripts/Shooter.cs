using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
	[SerializeField] GameObject projectile, gun;

	Animator animator;
	AttackerSpawner myLaneSpawner;
	GameObject projectileParent;

	const string PROJECTILE_PARENT_NAME = "Projectiles";

	void Start()
    {
		animator = GetComponent<Animator>();
		CreateProjectileParent();
		SetLaneSpawner();
    }

	void Update()
    {
        if( IsAttackerInLane() )
		{
			animator.SetBool( "isAttacking", true );
		}
		else
		{
			animator.SetBool( "isAttacking", false );
		}
    }

	private void CreateProjectileParent()
	{
		projectileParent = GameObject.Find( PROJECTILE_PARENT_NAME );
		if ( !projectileParent )
		{
			projectileParent = new GameObject( PROJECTILE_PARENT_NAME );
		}
	}

	private void SetLaneSpawner()
	{
		AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();

		foreach( AttackerSpawner spawner in spawners )
		{
			bool isCloseEnough = ( Mathf.Abs( spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon );

			if( isCloseEnough )
			{
				myLaneSpawner = spawner;
			}
		}
	}

	private bool IsAttackerInLane()
	{
		if( myLaneSpawner.transform.childCount <= 0 )
		{
			return false;
		}
		return true;
	}

	public void Fire()
	{
		GameObject newProjectile = Instantiate( projectile, gun.transform.position, Quaternion.identity ) as GameObject;
		newProjectile.transform.parent = projectileParent.transform;
	}
}
