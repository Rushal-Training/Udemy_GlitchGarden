﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	[SerializeField] float damage = 50f;
	[SerializeField] float speed = 10f;

    void Update()
    {
		transform.Translate( Vector2.right * speed * Time.deltaTime );
    }

	private void OnTriggerEnter2D( Collider2D collision )
	{
		var health = collision.GetComponent<Health>();
		var attacker = collision.GetComponent<Attacker>();

		if ( attacker && health )
		{
			health.DealDamage( damage );
			Destroy( gameObject );
		}
	}
}
