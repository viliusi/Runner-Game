using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
	public float maxRot;
	public float minRot;
	public float speed;
	public bool x;
	public bool y;
	public bool z;
	float angleIdentified;
	bool forward;
	int pause;

    // Start is called before the first frame update
    void Start()
	{
		
    }

	void FixedUpdate()
	{
		if (x == true)
		{
			angleIdentified = transform.localRotation.eulerAngles.x;
		}
		else if (y == true)
		{
			angleIdentified = transform.localRotation.eulerAngles.y;
		}
		else if (z == true)
		{
			angleIdentified = transform.localRotation.eulerAngles.z;
		}
		

		if (angleIdentified > maxRot - speed && angleIdentified < maxRot + speed)
		{
			forward = true;
		}
		else if (angleIdentified > minRot - speed && angleIdentified < minRot + speed)
		{
			forward = false;
		}

		if (x == true)
		{
			if (forward == false)
			{
				transform.Rotate(speed, 0f, 0f, Space.Self);
			}
			else if (forward == true)
			{
				transform.Rotate(speed * -1, 0f, 0f, Space.Self);
			}
		}
		else if (y == true)
		{
			if (forward == false)
			{
				transform.Rotate(0f, speed, 0f, Space.Self);
			}
			else if (forward == true)
			{
				transform.Rotate(0f, speed * -1, 0f, Space.Self);
			}
		}
		else if (z == true)
		{
			if (forward == false)
			{
				transform.Rotate(0f, 0f, speed, Space.Self);
			}
			else if (forward == true)
			{
				transform.Rotate(0f, 0f, speed * -1, Space.Self);
			}
		}
	}
    
}
