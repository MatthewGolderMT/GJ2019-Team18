using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergeLoggerTest : MonoBehaviour
{
	private void OnEnable()
	{
		MechFactory.MergedMechs += LogMergedMechs;
	}

	private void OnDisable()
	{
		MechFactory.MergedMechs += LogMergedMechs;
	}

	private void LogMergedMechs(List<Transform> oldMechs, Transform newMech)
	{
		Debug.Log("New Mech = " + newMech);
		string result = string.Empty;
		foreach (Transform t in oldMechs)
		{
			result += (" " + t.name);
		}
		Debug.Log("Old Mechs: " + result);
	}
}
