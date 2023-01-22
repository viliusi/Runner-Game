using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	public bool isStart;
	public bool isMenu;
	public bool isQuit;
	
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
        
	}
    
	void OnMouseUp(){
		if(isStart)
		{
			SceneManager.LoadScene(2);
		}
		if(isMenu)
		{
			SceneManager.LoadScene(0);
		}
		if (isQuit)
		{
			Application.Quit();
		}
	} 
}
