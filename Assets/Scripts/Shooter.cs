using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
	[SerializeField] GameObject projectile, gun;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

	public void Fire()
	{
		Instantiate( projectile, gun.transform.position, Quaternion.identity );
	}
}
