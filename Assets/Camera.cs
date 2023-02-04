using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{	
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
	public Transform Player;
	public Transform Light;

	// Update is called once per frame
	void Update() 
	{
		transform.position = Player.transform.position + new Vector3(-8, 5, 0);
		Light.transform.position = Player.transform.position + new Vector3(-9, 10, 0);
	}
}
