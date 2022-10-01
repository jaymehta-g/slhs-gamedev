using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomDrawers;

public class CharacterController2D : MonoBehaviour
{
	[Header("Physics")]
	[SerializeField] Rigidbody2D rb;
	[SerializeField] float speed;
	[SerializeField] float jumpStrength;
	[Header("Input")]
	[SerializeField] string horizontalAxis;
	[SerializeField] string jumpAxis;
	[Header("Debug")]
	[TestButton("Set Velocity", "debugButton")]
	[SerializeField] Vector2 debug;
	//
	float movementInput;
	bool jumpInput;
    void Start()
    {
        
    }
    void Update()
    {
        movementInput = Input.GetAxisRaw(horizontalAxis);
		jumpInput = Input.GetAxisRaw(jumpAxis) > 0;
    }
	private void FixedUpdate() {
		
	}

	void debugButton() {
		rb.velocity = debug;
	}
}
