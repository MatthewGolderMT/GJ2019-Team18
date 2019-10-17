using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static MechController;

public class MechFactory : MonoBehaviour
{
	public GameObject PurpleMechTemp;
	public GameObject OrangeMechTemp;
	public GameObject GreenMechTemp;

	private List<MechColour> _activeMechColours;

	private void OnEnable()
	{
		MechMergeArea.MergeMechs += MergeMechs;
	}

	private void OnDisable()
	{
		MechMergeArea.MergeMechs -= MergeMechs;
	}

	private void Awake()
	{
		_activeMechColours = new List<MechColour>();
		_activeMechColours.Add(MechColour.Red);
		_activeMechColours.Add(MechColour.Yellow);
		_activeMechColours.Add(MechColour.Blue);
	}

	public void MergeMechs(MechController m1, MechController m2)
	{
		MechColour newMechColour = GetMergedMechColour(m1, m2);

		if (_activeMechColours.Contains(newMechColour) == false)
		{
			if (newMechColour == MechColour.Purple)
			{
				GameObject purpleMech = Instantiate(PurpleMechTemp);
				AssignSecondaryMechControls(purpleMech, m1, m2);
			}
			else if (newMechColour == MechColour.Orange)
			{
				GameObject orangeMech = Instantiate(OrangeMechTemp);
				AssignSecondaryMechControls(orangeMech, m1, m2);
			}
			else if (newMechColour == MechColour.Green)
			{
				GameObject greenMech = Instantiate(GreenMechTemp);
				AssignSecondaryMechControls(greenMech, m1, m2);
			}

			_activeMechColours.Add(newMechColour);
			_activeMechColours.Remove(m1.mechColour);
			_activeMechColours.Remove(m2.mechColour);

			m1.gameObject.SetActive(false);
			m2.gameObject.SetActive(false);

		}

	}

	private void AssignSecondaryMechControls(GameObject newMech, MechController m1, MechController m2)
	{
		MechController purpleMechController = newMech.GetComponent<MechController>();

		float random = Random.Range(0f, 1f);
		if (random > 0.5f)
		{
			m1.player.AssignNewMech(purpleMechController, Player.MechControl.Movement);
			m2.player.AssignNewMech(purpleMechController, Player.MechControl.Shoot);
		}
		else
		{
			m1.player.AssignNewMech(purpleMechController, Player.MechControl.Shoot);
			m2.player.AssignNewMech(purpleMechController, Player.MechControl.Movement);
		}

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
