using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public enum BulletSource { Player, Enemy }
	public int Damage = 1;
	public BulletSource bulletSource;

	public void DestroyBullet()
	{
		Destroy(gameObject);
	}
}
