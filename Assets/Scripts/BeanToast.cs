using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomDrawers;
public class BeanToast : Enemy
{
	[SerializeField] float maxCooldown;
	float cooldown;
	[Blend2D("x","y",0,0,10,10)] [SerializeField]
	Vector2 jumpVector;
	private void Start() {
		initializeEnemy();
		print("init bean");
	}
	private void Update() {
		cooldown-=Time.deltaTime;
		if (cooldown<=0) {
			jump(
				//difference of enemy and player vectors
				(Player.instance.transform.position-transform.position)
				// if x is positive, player is o the right and need to jump right
				.x>0
			);
			cooldown = maxCooldown;
		}
	}
	void jump(bool right) {
		print(right);
		Vector2 jump = jumpVector;
		jump.x = Mathf.Abs(jump.x);
		jump.x*=(right?1:-1);
		rigidbody2D.velocity = jump;
	}
}
