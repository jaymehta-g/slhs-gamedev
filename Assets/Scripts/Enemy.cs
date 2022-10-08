using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using CustomDrawers;
public class Enemy : MonoBehaviour
{
	public EnemyStats stats;
	[Autohook]
	public Rigidbody2D rigidbody2D;
    protected void initializeEnemy() {
		print("init enemy");
	}
}
