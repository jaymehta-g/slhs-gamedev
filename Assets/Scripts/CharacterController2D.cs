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
	[Tooltip("Replaces rigidbody gravity scale"), SerializeField] float gravityScale;
	[Header("Platforming")]
	[SerializeField] Vector2 groundCheck;
	[SerializeField] LayerMask whatIsGround;
	[Header("Input")]
	[SerializeField] string horizontalAxis;
	[SerializeField] string jumpAxis;
	[Header("Debug")]
	[TestButton("Set Velocity", "debugButton")]
	[SerializeField] Vector2 debug;
	//
	float movementInput;
	bool jumpInput;
	bool previousJumpInput;
    void Start()
    {
    }
    void Update()
    {
        rb.gravityScale=gravityScale;
        movementInput = Input.GetAxisRaw(horizontalAxis);
		jumpInput = Input.GetAxisRaw(jumpAxis) > 0;
		if (!jumpInput) previousJumpInput = false;
    }
	private void FixedUpdate() {
		Vector2 velocity = Vector2.zero;
		velocity.x = movementInput*speed;
		if (jumpInput && !previousJumpInput && canJump()) {
			velocity.y = jumpStrength;
			previousJumpInput = true;
		}
		else {
			velocity.y = rb.velocity.y;
		}
		rb.velocity=velocity;
	}
	bool canJump() {
		var box = groundCheckBox();
		var collider = 
			Physics2D.OverlapBoxAll(box.pos, box.size, 0, whatIsGround);
		return collider.Length >0;

	}
	private void OnDrawGizmos() {
		var box = groundCheckBox();
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireCube(box.pos, box.size);
	}
	(Vector2 pos, Vector2 size) groundCheckBox() {
		Vector2 pos;
		Vector2 size = new Vector2();
		pos = transform.position;
		pos.y+=groundCheck.y*0.5f;
		size.y = -groundCheck.y;
		size.x = groundCheck.x;
		return (pos,size);
	}

	void debugButton() {
		rb.velocity = debug;
	}
}
