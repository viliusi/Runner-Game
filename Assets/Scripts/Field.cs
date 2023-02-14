using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Field : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
	{	    
		SceneManager.LoadScene(4, LoadSceneMode.Additive);
    }

    // Update is called once per frame
    void Update()
	{
		
    }
}
