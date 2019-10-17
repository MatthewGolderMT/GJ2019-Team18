using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechMergeArea : MonoBehaviour
{
	public delegate void MergeEvent(MechController mech1, MechController mech2);
	public static event MergeEvent MergeMechs;

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "MergeArea")
		{
			MechController myMech = GetComponentInParent<MechController>();
			MechController otherMech = col.GetComponentInParent<MechController>();
			if (myMech != null && otherMech != null)
			{
				if (MergeMechs != null)
				{
					MergeMechs(myMech, otherMech);
				}
			}
			/*
			switch (myMech.mechColour)
			{
				case MechController.MechColour.Red:
					if (otherMech.mechColour == MechController.MechColour.Blue)
					{
						Debug.Log("NO PURPLE MECH YET");

					}
					else if (otherMech.mechColour == MechController.MechColour.Yellow)
					{
						Debug.Log("NO ORANGE MECH YET");
					}
					break;
				case MechController.MechColour.Blue:
					if (otherMech.mechColour == MechController.MechColour.Red)
					{
						Debug.Log("NO PURPLE MECH YET");

					}
					else if (otherMech.mechColour == MechController.MechColour.Yellow)
					{
						Debug.Log("NO GREEN MECH YET");
					}
					break;
				case MechController.MechColour.Yellow:
					if (otherMech.mechColour == MechController.MechColour.Blue)
					{
						Debug.Log("NO GREEN MECH YET");
					}
					else if (otherMech.mechColour == MechController.MechColour.Red)
					{
						Debug.Log("NO Orange MECH YET");
					}
					break;
				case MechController.MechColour.Purple://...or any other secondary
					Debug.Log("NO RAINBOW MECH YET");
					break;
			}
			*/

		}
	}
}
