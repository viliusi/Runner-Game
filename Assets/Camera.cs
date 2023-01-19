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
	public Transform CameraPos;

	// Update is called once per frame
	void Update () 
	{
		CameraPos.transform.eulerAngles = new Vector3(0, CameraPos.transform.eulerAngles.y - spin, 0);

		//camRot = tofloat getAngle(CameraPos.eulerAngles.y);
		
		print(camRot);
		
		float x = desiredLength * Mathf.Sin(camRot);
		
		float y = desiredLength * Mathf.Cos(camRot);
		
		transform.position = Player.transform.position + new Vector3(x + 10, 3, y + 0);
	}
	float getAngle(float Angle){
	
	if (Angle > 180) Angle -= 360;
	return Angle;
	}
}
