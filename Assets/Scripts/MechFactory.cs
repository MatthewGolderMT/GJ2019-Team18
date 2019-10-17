using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static MechController;

public class MechFactory : Singleton<MechFactory>
{
	public GameObject RedMech;
	public GameObject BlueMech;
	public GameObject YellowMech;
	public GameObject PurpleMech;
	public GameObject OrangeMech;
	public GameObject GreenMech;
	public GameObject RainbowMech;

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

	protected override void Awake()
	{
		base.Awake();
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
			else if (newMechColour == MechColour.Rainbow)
			{
				ShowMech(RainbowMech, spawnPosition);
				AssignTertiaryMechControls(m1, m2);
				HideMech(BlueMech);
				HideMech(YellowMech);
				HideMech(RedMech);
				HideMech(GreenMech);
				HideMech(OrangeMech);
				HideMech(PurpleMech);
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

	//should just be used for rainbow
	private void AssignTertiaryMechControls(MechController m1, MechController m2)
	{
		MechController mechController = RainbowMech.GetComponent<MechController>();
		List<Player> players = new List<Player>(3);
		players.AddRange(m1.players);
		players.AddRange(m2.players);

		//TODO: Randomise role assignments
		//all playes need to be assigned a new mech with a role
		players[0].AssignNewMech(mechController, Player.MechControl.Shoot);
		players[1].AssignNewMech(mechController, Player.MechControl.Shoot);
		players[2].AssignNewMech(mechController, Player.MechControl.Movement);

		//give rainbow mech it's new players
		mechController.players = players;

		//remove old players
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
		else if (mech.mechColour == MechColour.Rainbow)
		{
			HideMech(RainbowMech);
			ShowMech(YellowMech, oldMechPos + new Vector2(-1, 0));
			ShowMech(BlueMech, oldMechPos + new Vector2(1, 0));
			ShowMech(RedMech, oldMechPos + new Vector2(0, 1));

			_activeMechColours.Remove(MechColour.Rainbow);
			_activeMechColours.Add(MechColour.Blue);
			_activeMechColours.Add(MechColour.Yellow);
			_activeMechColours.Add(MechColour.Red);

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

	private void PrintActiveMechs()
	{
		string result = string.Empty;
		foreach (MechColour colour in _activeMechColours)
		{
			result += (" " + colour);
		}
		Debug.Log(result);
	}

	public Transform GetRandomActiveMech()
	{
		int randomIndex = Random.Range(0, _activeMechColours.Count);
		MechColour randomMechColour = _activeMechColours[randomIndex];
		Transform mechTransform = null;
		switch (randomMechColour)
		{
			case MechColour.Blue:
				mechTransform = BlueMech.transform;
				break;
			case MechColour.Red:
				mechTransform = RedMech.transform;
				break;
			case MechColour.Yellow:
				mechTransform = YellowMech.transform;
				break;
			case MechColour.Purple:
				mechTransform = PurpleMech.transform;
				break;
			case MechColour.Orange:
				mechTransform = OrangeMech.transform;
				break;
			case MechColour.Green:
				mechTransform = GreenMech.transform;
				break;
			case MechColour.Rainbow:
				mechTransform = RainbowMech.transform;
				break;
			default:
				Debug.LogError("Tried to get random mech but did not recognise the colour: " + randomMechColour);
				break;
		}
		return mechTransform;
	}

	private MechColour GetMergedMechColour(MechController m1, MechController m2)
	{
		MechColour mechColour = MechColour.Red;

		if (m1.mechColour == MechColour.Purple || m1.mechColour == MechColour.Orange || m1.mechColour == MechColour.Green ||
			m2.mechColour == MechColour.Purple || m2.mechColour == MechColour.Orange || m2.mechColour == MechColour.Green)
		{
			mechColour = MechColour.Rainbow;
		}
		else
		{

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
				default:
					Debug.LogError("Failed to get correct mech colour combination!!! making a second red");
					mechColour = MechColour.Red;
					break;
			}
		}

		return mechColour;
	}
}
