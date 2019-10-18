using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpriteSwap : MonoBehaviour
{
	public Animator mechAnimator;
	Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        mechAnimator.SetFloat("Horizontal", movement.x);
        mechAnimator.SetFloat("Vertical", movement.y);
        mechAnimator.SetFloat("Vertical", movement.sqrMagnitude);
    }

}
