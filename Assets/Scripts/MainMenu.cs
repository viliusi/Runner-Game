using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
	public void Update()
	{
		
	}    
	public void start()
	{
		SceneManager.LoadScene(6);
	}
	public void menu()
	{
		SceneManager.LoadScene(0);
	}
	public void sune()
	{
		SceneManager.LoadScene(5);
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
