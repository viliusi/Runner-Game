using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
	public float spin = 0.0000005f;
	public float camRot;
	public float desiredLength = 10;
	
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
