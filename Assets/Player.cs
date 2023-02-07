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
	bool jumpable;
	public Rigidbody rb;
	public float distToGround;
	public int currentLevelIndex;
	public bool isPause;
	public int framesToWait;
	public int framesToWaitJump;
	public static int deaths;
     
	private void OnTriggerEnter(Collider other)
	{
		if (isPause == false)
		{
			if (other.tag == "Ouchies")
			{
				isPause = true;
				resetPlayer();
			}
			else if (other.tag == "Finish")
			{
				isPause = true;
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
		if (SceneManager.GetActiveScene().buildIndex == 5 || SceneManager.GetActiveScene().buildIndex == 4)
		{
			miliSecs = 0;
			seconds = 0;
			minutes = 0;
			
			deaths = 0;
		}
		
		SceneManager.LoadScene(3, LoadSceneMode.Additive);
		currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
		framesToWait = 20;
	    rb = GetComponent<Rigidbody>();
    }

	void Update()
	{
		distToGround = GetComponent<Collider>().bounds.extents.y;
		
		if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
		{
			left();
		}
		else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
		{
			right();
		}
		else if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
		{			
			jump();
		}
		else if (Input.GetKeyDown(KeyCode.R))
		{
			resetPlayer();
		}
		else if (Input.GetKeyDown(KeyCode.H))
		{
			SceneManager.LoadScene(5);
		}
	}
    void FixedUpdate()
	{
		if (miliSecs <= 970)
		{
			miliSecs += 20;
		}
		else
		{
			miliSecs = 0;
			
			seconds += 1;
			
			if (58.5 <= seconds)
			{
				seconds = 0;
				
				minutes += 1;
			}
		}
		
		transform.position += new Vector3(speed, 0, 0);
		
		if (isPause == true)
		{
			if (framesToWait > 0)
			{
				framesToWait--;
			}
			else if (framesToWait == 0)
			{
				isPause = false;
			}
		}
		if (framesToWaitJump > 0)
		{
			framesToWaitJump--;
		}
	}
    bool ValidMove()
	{
		// some code here, or sum
        return true;
	}
	void resetPlayer()
	{
		deaths++;
		
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
		else if (SceneManager.GetActiveScene().buildIndex == 4)
		{
			SceneManager.LoadScene(1);
		}
		else
		{
			SceneManager.LoadScene(1);
		}
	}
	public static void jump()
	{
		if (Player.framesToWaitJump == 0)
		{
			jumpable = IsGrounded();
			
			if (jumpable == true)
			{
				rb.velocity += new Vector3(0, 7, 0);
				
				jumpable = false;
					
				framesToWaitJump = 20;
			}
		}
	}
	public static void right()
	{
		valid = ValidMove();
        	
		if (valid)
		{
			rb.velocity += new Vector3(0, 0, -5);
		}
	}
	public static void left()
	{
		valid = ValidMove();
        	
		if (valid)
		{
			rb.velocity += new Vector3(0, 0, 5);
		}
	}
}