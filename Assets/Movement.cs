using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
	public float speed = 0.01f;
	
	private bool valid;
	
    // Start is called before the first frame update
    void Start()
    {
	    transform.position = new Vector3(0, 3, 0);
    }

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
			valid = ValidMove();
        	
			if (valid)
			{
				transform.position -= new Vector3(0, 0, -1);
			}
		}
		else if (Input.GetKeyDown(KeyCode.RightArrow))
		{
			valid = ValidMove();
        	
			if (valid)
			{
				transform.position -= new Vector3(0, 0, 1);
			}
		}
	}
    void FixedUpdate()
	{
		transform.position += new Vector3(speed, 0, 0);
	}
    bool ValidMove()
	{
		// some code here, or sum
        return true;
    }
}

