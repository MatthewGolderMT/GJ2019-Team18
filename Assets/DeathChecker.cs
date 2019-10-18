using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathChecker : MonoBehaviour
{
	public List<Player> players;


	private void Update()
	{
		int deadCount = 0;
		foreach (Player player in players)
		{
			if (player.currentHealth <= 0)
			{
				deadCount++;
			}
		}
		if (deadCount == 3)
		{
			SceneManager.LoadScene("TitleScreen");

		}
	}
}
