using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class MechController : MonoBehaviour
{
	public float Speed = 5f;
	public Transform BulletSpawnPosition;
	public GameObject BulletTemplate;
	public float BulletForce = 5f;
	public float FireCooldown = 0.5f;

	private Vector2 _move;
	private Vector2 _lookDirection;
	private float _timeSinceLastFire;
	private bool _firing;

	private void Update()
	{
		//handle move
		Vector2 m = new Vector2(_move.x, _move.y) * Time.deltaTime * Speed;
		transform.Translate(m, Space.World);

		//handle rotate
		float lookAngle = Mathf.Atan2(_lookDirection.y, _lookDirection.x) * Mathf.Rad2Deg - 90;
		transform.rotation = Quaternion.Euler(0, 0, lookAngle);

		//hadnle Fire cooldown
		_timeSinceLastFire += Time.deltaTime;
		if (_firing == true)
		{
			if (_timeSinceLastFire >= FireCooldown)
			{
				Fire();
			}
		}
	}

	public void Move(Vector2 moveVector)
	{
		_move = moveVector;
	}

	public void Rotate(Vector2 rotateVector)
	{
		_lookDirection = rotateVector;
	}
	/*
	public void Grow()
	{
		transform.localScale *= 1.1f;
	}
	*/

	public void SetFiringState(bool isFiring)
	{
		_firing = isFiring;
	}

	private void Fire()
	{
		GameObject bullet = Instantiate(BulletTemplate, BulletSpawnPosition.position, BulletSpawnPosition.rotation);
		Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();

		Vector2 impulseDirection = BulletSpawnPosition.position - transform.position;
		bulletRigidbody.AddForce(impulseDirection * BulletForce, ForceMode2D.Impulse);

		Destroy(bullet, 1.5f);
		_timeSinceLastFire = 0;
	}
}
