using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static MechController;

public class PlayerUI : MonoBehaviour
{
	public Image portrait;
	public Image healthBar;
	public int MaxHealth;

	private Sprite _portraitSprite;

	public void SetHealth(int health)
	{
		float barvalue = (float)health / (float)MaxHealth;
		healthBar.fillAmount = barvalue;
	}

	public void SetColour(MechColour mechColour)
	{
		switch (mechColour)
		{
			case MechController.MechColour.Red:
				{
					Color col = Color.white;
					ColorUtility.TryParseHtmlString("#ed1b24ff", out col);
					portrait.color = col;
					break;
				}
			case MechController.MechColour.Blue:
				{
					Color col = Color.white;
					ColorUtility.TryParseHtmlString("#2e3192ff", out col);
					portrait.color = col;
					break;
				}
			case MechController.MechColour.Yellow:
				{
					Color col = Color.white;
					ColorUtility.TryParseHtmlString("#f2e405ff", out col);
					portrait.color = col;
					break;
				}
			case MechController.MechColour.Purple:
				{
					Color col = Color.white;
					ColorUtility.TryParseHtmlString("#92278fff", out col);
					portrait.color = col;
					break;
				}
			case MechController.MechColour.Orange:
				{
					Color col = Color.white;
					ColorUtility.TryParseHtmlString("#f37521ff", out col);
					portrait.color = col;
					break;
				}
			case MechController.MechColour.Green:
				{
					Color col = Color.white;
					ColorUtility.TryParseHtmlString("#1ab359ff", out col);
					portrait.color = col;
					break;
				}
			case MechController.MechColour.Rainbow:
				{
					Color col = Color.white;
					//ColorUtility.TryParseHtmlString("#ed1b24ff", out col);
					ColorUtility.TryParseHtmlString("#111111ff", out col);

					portrait.color = col;
					break;
				}
		}
	}

}
