using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Square : MonoBehaviour
{
	public float Speed = 5f;
	public float RotationSpeed = 100f;
	private PlayerControls _controls;
	private Vector2 _move;
	private Vector2 _lookDirection;

	private void Awake()
	{
		_controls = new PlayerControls();

		//player input can handle the device assignment, but we need to set it to match our control scheme
		PlayerInput playerInput = GetComponent<PlayerInput>();
		_controls.devices = playerInput.devices;

		_controls.Gameplay.Grow.performed += ctx => Grow();
		_controls.Gameplay.Move.performed += ctx => _move = ctx.ReadValue<Vector2>();
		_controls.Gameplay.Move.canceled += ctx => _move = Vector2.zero;
		_controls.Gameplay.Rotation.performed += ctx => _lookDirection = ctx.ReadValue<Vector2>();
		_controls.Gameplay.Rotation.canceled += ctx => _lookDirection = Vector2.zero;
	}

	private void OnEnable()
	{
		_controls.Gameplay.Enable();
	}

	private void OnDisable()
	{
		_controls.Gameplay.Disable();
	}

	private void Update()
	{
		Vector2 m = new Vector2(_move.x, _move.y) * Time.deltaTime * Speed;
		transform.Translate(m, Space.World);
		/*
		if (_rotate != Vector2.zero)
		{
			Debug.Log(_rotate.x + " , " + _rotate.y);
		}
		*/
		//Vector2 r = new Vector2(_rotate.y, _rotate.x) * Time.deltaTime * RotationSpeed;
		//transform.Rotate(, Space.World);

		float lookAngle = Mathf.Atan2(_lookDirection.y, _lookDirection.x) * Mathf.Rad2Deg - 90;
		transform.rotation = Quaternion.Euler(0, 0, lookAngle);
	}

	private void Grow()
	{
		transform.localScale *= 1.1f;
	}
}
