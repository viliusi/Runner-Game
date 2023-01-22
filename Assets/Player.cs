using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
	public float speed = 0.1f;
	private bool valid;
	bool dying;
	bool jumpable;
	public Rigidbody rb;
	public float distToGround;
	public int currentLevelIndex;
	public bool isFinished;
	public int framesToWait;
     
	private void OnTriggerEnter(Collider other)
	{
		if (isFinished == false)
		{
			if (other.tag == "Ouchies")
			{
				dying = true;
			}
			else if (other.tag == "Ramps and such" && other.tag == "Field")
			{
				jumpable = true;
			}
			else if (other.tag == "Finish")
			{
				isFinished = true;
				if (currentLevelIndex < (SceneManager.sceneCountInBuildSettings - 1))
				{
					currentLevelIndex++;
				}
				nextLevel();
			}
		}
		else
		{
			print("Not checking collisions");
		}
	}

    // Start is called before the first frame update
    void Start()
	{
		framesToWait = 20;
	    rb = GetComponent<Rigidbody>();
    }

	void Update()
	{
		if (currentLevelIndex == null)
		{
			currentLevelIndex = 0;
		}
		if (dying == true) 
		{
			resetPlayer();
			
			dying = false;
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
		else if (Input.GetKeyDown(KeyCode.R))
		{
			resetPlayer();
		}
	}
    void FixedUpdate()
	{
		transform.position += new Vector3(speed, 0, 0);
		
		if (isFinished == true)
		{
			if (framesToWait > 0)
			{
				framesToWait--;
			}
			else if (framesToWait == 0)
			{
				isFinished = false;
			}
		}
	}
    bool ValidMove()
	{
		// some code here, or sum
        return true;
	}
	void resetPlayer()
	{
		transform.position = new Vector3(0, 3, 0);
		transform.rotation = Quaternion.Euler(0,0,0);
		rb.velocity = new Vector3(0, 0, 0);
	}
	bool IsGrounded() 
	{
		return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
	}
	void nextLevel()
	{
		SceneManager.LoadScene(currentLevelIndex);
		
		resetPlayer();
	}
}

