using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MergeTester : MonoBehaviour //obselete
{
	public Player player1;
	public Player player2;
	public GameObject PurpleMechTemp;

	public void Merge()
	{
		GameObject purpleMech = Instantiate(PurpleMechTemp);
		MechController purpleMechController = purpleMech.GetComponent<MechController>();


		float random = Random.Range(0f, 1f);
		if (random > 0.5f)
		{
			player1.AssignNewMech(purpleMechController, Player.MechControl.Movement);
			player2.AssignNewMech(purpleMechController, Player.MechControl.Shoot);
		}
		else
		{
			player1.AssignNewMech(purpleMechController, Player.MechControl.Shoot);
			player2.AssignNewMech(purpleMechController, Player.MechControl.Movement);
		}
	}

}
