using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
	public bool x;
	public bool y;
	public bool z;
	public float maxRot;
	public float minRot;
	public float xSpeed;
	public float ySpeed;
	public float zSpeed;
	float xIdentified;
	float yIdentified;
	float zIdentified;
	bool xForward;
	bool yForward;
	bool zForward;

    // Start is called before the first frame update
    void Start()
	{
		
    }

	void FixedUpdate()
	{
		Identify();
		
		RotationHandler();

		if (x == true)
		{
			if (xForward == false)
			{
				transform.Rotate(xSpeed, 0f, 0f, Space.Self);
			}
			else if (xForward == true)
			{
				transform.Rotate(xSpeed * -1, 0f, 0f, Space.Self);
			}
		}
		else if (y == true)
		{
			if (yForward == false)
			{
				transform.Rotate(0f, ySpeed, 0f, Space.Self);
			}
			else if (yForward == true)
			{
				transform.Rotate(0f, ySpeed * -1, 0f, Space.Self);
			}
		}
		else if (z == true)
		{
			if (zForward == false)
			{
				transform.Rotate(0f, 0f, zSpeed, Space.Self);
			}
			else if (zForward == true)
			{
				transform.Rotate(0f, 0f, zSpeed * -1, Space.Self);
			}
		}
	}
	public void Identify()
	{
		if (x == true)
		{
			xIdentified = transform.localRotation.eulerAngles.x;
		}
		else
		{
			xIdentified = 0f;
		}
		
		if (y == true)
		{
			yIdentified = transform.localRotation.eulerAngles.y;
		}
		else
		{
			yIdentified = 0f;
		}
		
		if (z == true)
		{
			zIdentified = transform.localRotation.eulerAngles.z;
		}
		else
		{
			zIdentified = 0f;
		}
	}
	public void RotationHandler()
	{
		if (x == true)
		{
			if (xIdentified > maxRot - xSpeed && xIdentified < maxRot + xSpeed)
			{
				xForward = true;
			}
			else if (xIdentified > minRot - xSpeed && xIdentified < minRot + xSpeed)
			{
				xForward = false;
			}
		}
		if (y == true)
		{
			if (yIdentified > maxRot - ySpeed && yIdentified < maxRot + ySpeed)
			{
				yForward = true;
			}
			else if (yIdentified > minRot - ySpeed && yIdentified < minRot + ySpeed)
			{
				yForward = false;
			}
		}
		if (z == true)
		{
			if (zIdentified > maxRot - zSpeed && zIdentified < maxRot + zSpeed)
			{
				zForward = true;
			}
			else if (zIdentified > minRot - zSpeed && zIdentified < minRot + zSpeed)
			{
				zForward = false;
			}
		}
	}
}
