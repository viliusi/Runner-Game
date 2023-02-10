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
	public float distToGround;
	public int currentLevelIndex;
	public bool isPause;
	public int framesToWait;
	public int framesToWaitJump;
	public static int deaths;
	public static bool tryLeft;
	public static bool tryRight;
	public static bool tryJump;
	public static bool reset;
	public static bool hardReset;
	//public static bool woman;
	public Rigidbody rb;
	public MeshRenderer cubeRen;
	public AudioSource jumpy;
	public AudioSource diey;
	public AudioSource finishy;
	//public GameObject[] objs;
     
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
		
		//objs = GameObject.FindGameObjectsWithTag("Music");
		
		SceneManager.LoadScene(3, LoadSceneMode.Additive);
		currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
		framesToWait = 20;
		rb = GetComponent<Rigidbody>();
	}

	void Update()
	{
		distToGround = GetComponent<Collider>().bounds.extents.y;
		
		/*if (objs.Length > 2)
		{
			Destroy(finishy);
		}*/
		
		inputHander();
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
		
		diey.GetComponent<AudioSource>().Play();
		
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
		
		finishy.GetComponent<AudioSource>().Play();
		
		if (currentLevelIndex <= (SceneManager.sceneCountInBuildSettings - 1))
		{
			SceneManager.LoadScene(currentLevelIndex);
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
	public void jump()
    {
        if (framesToWaitJump == 0)
        {
            jumpable = IsGrounded();

            if (jumpable == true)
            {
	            rb.velocity += new Vector3(0, 7, 0);
                
	            DontDestroyOnLoad(finishy.gameObject);
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
            rb.velocity += new Vector3(0, 0, -5);
        }
    }
    public void left()
    {
        valid = ValidMove();

        if (valid)
        {
            rb.velocity += new Vector3(0, 0, 5);
        }
    }
}