using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
	public static double minutes;
	public static double seconds;
	public static double miliSecs;
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
				nextLevel();
			}
		}
		else
		{
			
		}
	}

    // Start is called before the first frame update
    void Start()
	{
		if (SceneManager.GetActiveScene().buildIndex == 3)
		{
			miliSecs = 0;
			seconds = 0;
			minutes = 0;
		}
		else if (SceneManager.GetActiveScene().buildIndex == 2)
		{
			miliSecs = 0;
			seconds = 0;
			minutes = 0;
		}
		
		currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
		framesToWait = 20;
	    rb = GetComponent<Rigidbody>();
    }

	void Update()
	{
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
		else if (Input.GetKeyDown(KeyCode.H))
		{
			SceneManager.LoadScene(2);
		}
	}
    void FixedUpdate()
	{
		if (miliSecs <= 960)
		{
			miliSecs += 20;
		}
		else
		{
			miliSecs = 0;
			
			seconds += 1;
			
			if (60 < seconds)
			{
				seconds = 0;
				
				minutes += 1;
			}
		}
		
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
		rb.velocity = new Vector3(0, 0, 0);
		rb.angularVelocity = new Vector3(0, 0, 0);
		transform.rotation = Quaternion.identity;
	}
	bool IsGrounded() 
	{
		return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
	}
	void nextLevel()
	{
		currentLevelIndex++;
		
		if (currentLevelIndex <= (SceneManager.sceneCountInBuildSettings - 1))
		{
			SceneManager.LoadScene(currentLevelIndex);
		}
		else if (SceneManager.GetActiveScene().buildIndex == 2)
		{
			SceneManager.LoadScene(1);
		}
		else
		{
			SceneManager.LoadScene(1);
		}
	}
}

