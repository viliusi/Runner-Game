using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
        
	}
    
	public void start()
	{
		SceneManager.LoadScene(4);
	}
	public void menu()
	{
		SceneManager.LoadScene(0);
	}
	public void sune()
	{
		SceneManager.LoadScene(3);
	}
	public void quit()
	{
		Application.Quit();
	}
	public void controls()
	{
		SceneManager.LoadScene(2);
	}
}
