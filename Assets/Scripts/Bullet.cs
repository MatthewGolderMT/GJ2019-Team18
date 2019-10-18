using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static MechController;

public class Bullet : MonoBehaviour
{
	public enum BulletSource { Player, Enemy }
	public int Damage = 1;
	public BulletSource bulletSource;
	public MechColour bulletColour;

	public void DestroyBullet()
	{
		Destroy(gameObject);
	}
}
