using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
	
    
	public void start()
	{
		SceneManager.LoadScene(5);
	}
	public void menu()
	{
		SceneManager.LoadScene(0);
	}
	public void sune()
	{
		SceneManager.LoadScene(4);
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
