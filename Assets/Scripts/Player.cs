using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
	public enum MechControl { Full, Movement, Shoot }

	public MechController activeMech;
	public MechController startingMech;
	private PlayerControls input;
	private PlayerInput _playerInput;

	private void Awake()
	{
		startingMech = activeMech;
		input = new PlayerControls();

		//player input can handle the device assignment, but we need to set it to match our control scheme
		_playerInput = GetComponent<PlayerInput>();
		input.devices = _playerInput.devices;

		SetInputMappings();

		AssignNewMech(activeMech, MechControl.Full);
	}

	private void OnEnable()
	{
		input.MovementControl.Enable();
		input.ShootControl.Enable();
		input.MergeControl.Enable();
	}

	private void OnDisable()
	{
		input.MovementControl.Disable();
		input.ShootControl.Disable();
		input.MergeControl.Disable();
	}

	public void AssignStartingMech()
	{
		AssignNewMech(startingMech, MechControl.Full);
	}

	public void AssignNewMech(MechController mech, MechControl control)
	{
		activeMech = mech;

		switch (control)
		{
			case MechControl.Full:
				//_playerInput.SwitchCurrentActionMap("FullControl"); /// used to switch the current action map, but didn't notice the diffference
				input.MovementControl.Enable();
				input.ShootControl.Enable();

				break;
			case MechControl.Movement:
				//_playerInput.SwitchCurrentActionMap("MovementControl");
				input.MovementControl.Enable();
				input.ShootControl.Disable();

				break;
			case MechControl.Shoot:
				//_playerInput.SwitchCurrentActionMap("ShootControl");
				input.MovementControl.Disable();
				input.ShootControl.Enable();

				break;

		}
	}

	private void SetInputMappings()
	{
		//full control might be obselete now
		/*
		input.FullControl.Move.performed += ctx => activeMech.Move(ctx.ReadValue<Vector2>());
		input.FullControl.Move.canceled += ctx => activeMech.Move(new Vector2());
		input.FullControl.Rotation.performed += ctx => activeMech.Rotate(ctx.ReadValue<Vector2>());
		input.FullControl.Rotation.canceled += ctx => activeMech.Rotate(new Vector2());
		input.FullControl.Grow.performed += ctx => activeMech.Grow();
		*/

		input.MovementControl.Move.performed += ctx => activeMech.Move(ctx.ReadValue<Vector2>());
		input.MovementControl.Move.canceled += ctx => activeMech.Move(new Vector2());

		input.ShootControl.Rotation.performed += ctx => activeMech.Rotate(ctx.ReadValue<Vector2>());
		input.ShootControl.Rotation.canceled += ctx => activeMech.Rotate(new Vector2());

		input.ShootControl.Shoot.started += ctx => activeMech.SetFiringState(true);
		input.ShootControl.Shoot.canceled += ctx => activeMech.SetFiringState(false);

		input.MergeControl.Merge.started += ctx => activeMech.SetMergingState(true);
		input.MergeControl.Merge.canceled += ctx => activeMech.SetMergingState(false);

		input.MergeControl.Disband.started += ctx => activeMech.IncrementDisbandingPlayers(1);
		input.MergeControl.Disband.canceled += ctx => activeMech.IncrementDisbandingPlayers(-1);

	}
}
