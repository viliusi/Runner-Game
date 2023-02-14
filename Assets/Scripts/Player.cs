using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
	// Objects
	public Rigidbody rb;
	public MeshRenderer cubeRen;
	public AudioSource jumpy;
	public AudioSource diey;
	public AudioSource finishy;
	public Transform Camera;
	public Transform Light;
	
	// Timer / UI variables
	public static double minutes;
	public static double seconds;
	public static double miliSecs;
	public static int deaths;
	
	// Values
	public float errorBuffer;
	public float speed;
	public Vector3 StartPos;
	public float JumpStrength;
	public float sidewaysVelocity;
	
	// Movement variables
	private float distToGround;
	private bool valid;
	private bool jumpable;
	private bool isPause;
	private int framesToWait;
	private int framesToWaitJump;
	
	// On screen controls
	public static bool tryLeft;
	public static bool tryRight;
	public static bool tryJump;
	public static bool reset;
	public static bool hardReset;
	
	//public static bool woman;
     
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
		/*if (woman == true)
		{
			cubeRen.enabled = false;
		}
		else
		{
			cubeRen.enabled = true;
		}*/
		
		if (SceneManager.GetActiveScene().buildIndex == 6 || SceneManager.GetActiveScene().buildIndex == 5)
		{
			miliSecs = 0;
			seconds = 0;
			minutes = 0;
			
			deaths = 0;
		}
		
		SceneManager.LoadScene(3, LoadSceneMode.Additive);
		framesToWait = 20;
		rb = GetComponent<Rigidbody>();
	}

	void Update()
	{
		transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
		Camera.transform.position = transform.position + new Vector3(-8, 5, 0);
		Light.transform.position = transform.position + new Vector3(-9, 10, 0);
		
		distToGround = GetComponent<Collider>().bounds.extents.y;
		
		inputHander();
		
		timerHandler();
	}
	void FixedUpdate()
	{
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
		
		diey.GetComponent<AudioSource>().Play();
		
		transform.position = StartPos;
		rb.velocity = new Vector3(0, 0, 0);
		rb.angularVelocity = new Vector3(0, 0, 0);
		transform.rotation = Quaternion.identity;
	}
	bool IsGrounded() 
	{
		return Physics.Raycast(transform.position, -Vector3.up, distToGround + errorBuffer);
	}
	void nextLevel()
	{
		DontDestroyOnLoad(finishy.gameObject);
		finishy.GetComponent<AudioSource>().Play();
		
		if (SceneManager.GetActiveScene().buildIndex + 1 <= (SceneManager.sceneCountInBuildSettings - 1))
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}
		else
		{
			SceneManager.LoadScene(1);
		}
	}	
	void inputHander()
	{
		if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
		{
			tryLeft = true;
		}
		else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
		{
			tryRight = true;
		}
		else if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
		{			
			tryJump = true;
		}
		else if (Input.GetKeyDown(KeyCode.R))
		{
			reset = true;
		}
		else if (Input.GetKeyDown(KeyCode.H))
		{
			hardReset = true;
		}
		
		if (tryLeft == true)
		{
			left();
			
			tryLeft = false;
		}
		
		if (tryRight == true)
		{
			right();
			
			tryRight = false;
		}
		
		if (tryJump == true)
		{
			jump();
			
			tryJump = false;
		}
		
		if (reset == true)
		{
			resetPlayer();
			
			reset = false;
		}
		
		if (hardReset == true)
		{
			SceneManager.LoadScene(6);
			
			hardReset = false;
		}
	}
	void timerHandler()
	{
		miliSecs += 1000 * Time.deltaTime;
		
		if (miliSecs >= 1000)
		{
			miliSecs -= 1000;
			
			seconds += 1;
			
			if (58.5 <= seconds)
			{
				seconds = 0;
				
				minutes += 1;
			}
		}
	}
	public void jump()
    {
        if (framesToWaitJump == 0)
        {
            jumpable = IsGrounded();

            if (jumpable == true)
            {
	            rb.velocity += new Vector3(0, JumpStrength, 0);
            	
	            jumpy.GetComponent<AudioSource>().Play();

                jumpable = false;

                framesToWaitJump = 20;
            }
        }
    }
    public void right()
    {
        valid = ValidMove();

        if (valid)
        {
	        rb.velocity += new Vector3(0, 0, -sidewaysVelocity);
        }
    }
    public void left()
    {
        valid = ValidMove();

        if (valid)
        {
            rb.velocity += new Vector3(0, 0, sidewaysVelocity);
        }
    }
}