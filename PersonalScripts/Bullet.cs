using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	private Transform target; 


	
	public int damage = 50;

	public float distanceOfExplosion = 0f;
	public GameObject effetDimpact;
	public float speed = 70f;
	
	public void  Start()
    {
		
	}
	public void Seek(Transform _target) // initialise la variable target a _target
	{
		target = _target;
	}

	// Update is called once per frame
	void Update()
	{

		if (target == null) // si est null le detruire et return
		{
			Destroy(gameObject);
			return;
		}

		Vector3 dir = target.position - transform.position;
		float distanceThisFrame = speed * Time.deltaTime;

		if (dir.magnitude <= distanceThisFrame)
		{
			HitTarget();
			return;
		}

		transform.Translate(dir.normalized * distanceThisFrame, Space.World);
		transform.LookAt(target);

	}

	void HitTarget()  // Instantiate the impac effect and call the explosion or damage function
	{
		Destroy(gameObject);
		GameObject effectIns = (GameObject)Instantiate(effetDimpact, transform.position, transform.rotation);
		Destroy(effectIns, 5f);

		if (distanceOfExplosion > 0f)
		{
			Explode();
		}
		else
		{
			Damage(target);
		}

		Destroy(gameObject);
	}

	void Explode()                //  i used a array of coliders to make the bullet be able to damage more than enemmy
	{
		Collider[] colliders = Physics.OverlapSphere(transform.position, distanceOfExplosion);
		foreach (Collider collider in colliders)
		{
			if (collider.CompareTag("Enemy"))
			{
				Damage(collider.transform);
			}
		}
	}


	void Damage(Transform enemy)  // receive the damage
	{
		
		
		Enemy e = enemy.GetComponent<Enemy>();

		if (e != null)
		{
			e.TakeDamage(damage);
		}
	}

	void OnDrawGizmosSelected() // allow us to see the range 
	{
		Gizmos.color = Color.gray;
		Gizmos.DrawWireSphere(transform.position, distanceOfExplosion);
	}
}
