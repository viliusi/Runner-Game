using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public float speed = 0.1f;
	private bool valid;
	bool isCurrentlyColliding;
	bool jumpable;
	public Rigidbody rb;
	public float distToGround;
     
	private void OnTriggerEnter(Collider other)
	{
		print(other.tag);
		
		if (other.tag == "Ouchies")
		{
			isCurrentlyColliding = true;
		}
		else if (other.tag == "Ramps and such" && other.tag == "Field")
		{
			jumpable = true;
		}
	}

    // Start is called before the first frame update
    void Start()
    {
	    rb = GetComponent<Rigidbody>();
	    resetPlayer();
    }

	void Update()
	{
		if (isCurrentlyColliding) 
		{
			resetPlayer();
			
			isCurrentlyColliding = false;
		}
		
		distToGround = GetComponent<Collider>().bounds.extents.y;
		
		if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
			valid = ValidMove();
        	
			if (valid)
			{
				rb.velocity += new Vector3(0, 0, 5);
			}
		}
		else if (Input.GetKeyDown(KeyCode.RightArrow))
		{
			valid = ValidMove();
        	
			if (valid)
			{
				rb.velocity += new Vector3(0, 0, -5);
			}
		}
		else if (Input.GetKeyDown(KeyCode.Space))
		{			
			jumpable = IsGrounded();
			
			if (jumpable == true)
			{
				rb.velocity += new Vector3(0, 7, 0);
				
				jumpable = false;
			}
		}
	}
    void FixedUpdate()
	{
		transform.position += new Vector3(speed, 0, 0);
	}
    bool ValidMove()
	{
		// some code here, or sum
        return true;
	}
	void resetPlayer()
	{
		transform.position = new Vector3(0, 3, 0);
		transform.eulerAngles = new Vector3(0, 0, 0);
	}
	bool IsGrounded() 
	{
		return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
	}
}

