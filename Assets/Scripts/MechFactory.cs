using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static MechController;

public class MechFactory : MonoBehaviour
{
	public GameObject RedMech;
	public GameObject BlueMech;
	public GameObject YellowMech;
	public GameObject PurpleMech;
	public GameObject OrangeMech;
	public GameObject GreenMech;

	private List<MechColour> _activeMechColours;

	private void OnEnable()
	{
		MechMergeArea.MergeMechs += MergeMechs;
		MechController.DisbandMech += DisbandMech;
	}

	private void OnDisable()
	{
		MechMergeArea.MergeMechs -= MergeMechs;
		MechController.DisbandMech -= DisbandMech;
	}

	private void Awake()
	{
		_activeMechColours = new List<MechColour>();
		_activeMechColours.Add(MechColour.Red);
		_activeMechColours.Add(MechColour.Yellow);
		_activeMechColours.Add(MechColour.Blue);
	}

	private void MergeMechs(MechController m1, MechController m2)
	{
		MechColour newMechColour = GetMergedMechColour(m1, m2);
		Vector2 spawnPosition = (m1.transform.position + m2.transform.position) / 2;
		if (_activeMechColours.Contains(newMechColour) == false)
		{
			if (newMechColour == MechColour.Purple)
			{
				ShowMech(PurpleMech, spawnPosition);
				AssignSecondaryMechControls(PurpleMech, m1, m2);
				HideMech(RedMech);
				HideMech(BlueMech);
			}
			else if (newMechColour == MechColour.Orange)
			{
				ShowMech(OrangeMech, spawnPosition);
				AssignSecondaryMechControls(OrangeMech, m1, m2);
				HideMech(RedMech);
				HideMech(YellowMech);
			}
			else if (newMechColour == MechColour.Green)
			{
				ShowMech(GreenMech, spawnPosition);
				AssignSecondaryMechControls(GreenMech, m1, m2);
				HideMech(BlueMech);
				HideMech(YellowMech);
			}

			m1.SetMergingState(false);
			m2.SetMergingState(false);

			_activeMechColours.Add(newMechColour);
			_activeMechColours.Remove(m1.mechColour);
			_activeMechColours.Remove(m2.mechColour);
		}
	}

	private void ShowMech(GameObject mech, Vector2 position)
	{
		mech.transform.position = position;
		mech.SetActive(true);
	}

	private void HideMech(GameObject mech)
	{
		mech.SetActive(false);
		mech.transform.position = new Vector2(-500, -500);
	}

	private void AssignSecondaryMechControls(GameObject newMech, MechController m1, MechController m2)
	{
		MechController mechController = newMech.GetComponent<MechController>();

		float random = Random.Range(0f, 1f);
		if (random > 0.5f)
		{
			//assuming primary mechs have only one player
			m1.players[0].AssignNewMech(mechController, Player.MechControl.Movement);
			m2.players[0].AssignNewMech(mechController, Player.MechControl.Shoot);
		}
		else
		{
			m1.players[0].AssignNewMech(mechController, Player.MechControl.Shoot);
			m2.players[0].AssignNewMech(mechController, Player.MechControl.Movement);
		}

		//give mech it's new players
		List<Player> mechPlayers = new List<Player>(2);
		mechPlayers.Add(m1.players[0]);
		mechPlayers.Add(m2.players[0]);
		mechController.players = mechPlayers;

		//remove old players
		m1.players = new List<Player>(3);
		m2.players = new List<Player>(3);

	}

	private void DisbandMech(MechController mech)
	{
		Vector2 oldMechPos = mech.transform.position;
		//depending on colour....
		if (mech.mechColour == MechColour.Orange)
		{
			HideMech(OrangeMech);
			ShowMech(RedMech, oldMechPos + new Vector2(-1, 0));
			ShowMech(YellowMech, oldMechPos + new Vector2(1, 0));

			_activeMechColours.Remove(MechColour.Orange);
			_activeMechColours.Add(MechColour.Red);
			_activeMechColours.Add(MechColour.Yellow);

		}
		else if (mech.mechColour == MechColour.Purple)
		{
			HideMech(PurpleMech);
			ShowMech(RedMech, oldMechPos + new Vector2(-1, 0));
			ShowMech(BlueMech, oldMechPos + new Vector2(1, 0));

			_activeMechColours.Remove(MechColour.Purple);
			_activeMechColours.Add(MechColour.Red);
			_activeMechColours.Add(MechColour.Blue);
		}
		else if (mech.mechColour == MechColour.Green)
		{
			HideMech(GreenMech);
			ShowMech(YellowMech, oldMechPos + new Vector2(-1, 0));
			ShowMech(BlueMech, oldMechPos + new Vector2(1, 0));

			_activeMechColours.Remove(MechColour.Green);
			_activeMechColours.Add(MechColour.Blue);
			_activeMechColours.Add(MechColour.Yellow);
		}

		//reassign controls
		foreach (Player player in mech.players)
		{
			player.AssignStartingMech();
			player.activeMech.players = new List<Player>() { player };

		}
		//create lower level mechs
		//assign controls
		//remove upper level mech
	}

	private MechColour GetMergedMechColour(MechController m1, MechController m2)
	{
		MechColour mechColour = MechColour.Red;
		switch (m1.mechColour)
		{
			case MechController.MechColour.Red:
				if (m2.mechColour == MechController.MechColour.Blue)
				{
					mechColour = MechColour.Purple;

				}
				else if (m2.mechColour == MechController.MechColour.Yellow)
				{
					mechColour = MechColour.Orange;
				}
				break;
			case MechController.MechColour.Blue:
				if (m2.mechColour == MechController.MechColour.Red)
				{
					mechColour = MechColour.Purple;

				}
				else if (m2.mechColour == MechController.MechColour.Yellow)
				{
					mechColour = MechColour.Green;
				}
				break;
			case MechController.MechColour.Yellow:
				if (m2.mechColour == MechController.MechColour.Blue)
				{
					mechColour = MechColour.Green;
				}
				else if (m2.mechColour == MechController.MechColour.Red)
				{
					mechColour = MechColour.Orange;
				}
				break;
			case MechController.MechColour.Purple:
			case MechController.MechColour.Orange:
			case MechController.MechColour.Green:

				mechColour = MechColour.Rainbow;
				break;
			default:
				Debug.LogError("Failed to get correct mech colour combination!!! making a second red");
				mechColour = MechColour.Red;
				break;
		}

		return mechColour;
	}
}
