using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class MechController : MonoBehaviour
{
	public float Speed = 5f;

	private Vector2 _move;
	private Vector2 _lookDirection;

	private void Update()
	{
		//handle move
		Vector2 m = new Vector2(_move.x, _move.y) * Time.deltaTime * Speed;
		transform.Translate(m, Space.World);

		//handle rotate
		float lookAngle = Mathf.Atan2(_lookDirection.y, _lookDirection.x) * Mathf.Rad2Deg - 90;
		transform.rotation = Quaternion.Euler(0, 0, lookAngle);
	}

	public void Move(Vector2 moveVector)
	{
		_move = moveVector;
	}

	public void Rotate(Vector2 rotateVector)
	{
		_lookDirection = rotateVector;
	}

	public void Grow()
	{
		transform.localScale *= 1.1f;
	}
}
