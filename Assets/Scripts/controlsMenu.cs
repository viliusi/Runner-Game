using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controlsMenu : MonoBehaviour
{
	public int timer;
	
	// Start is called before the first frame update
	void Start()
	{
		timer = 250;
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		if (timer == 0)
		{
			SceneManager.LoadScene(0);
		}
		else
		{
			timer--;
		}
	}
}
