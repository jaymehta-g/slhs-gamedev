using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Enemy : MonoBehaviour
{
    Action enemyStart;
	Action enemyUpdate;
	Action enemyFixedUpdate;
    void Start()
    {
        enemyStart();
    }
    void Update()
    {
        enemyUpdate();
    }
	private void FixedUpdate() {
		enemyFixedUpdate();
	}
}
