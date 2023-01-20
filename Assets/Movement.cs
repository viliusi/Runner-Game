using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
	public double x;
	public double y;
	public double z;
	
	
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 5, 0);
    }

    // Update is called once per frame
    void Update()
	{
		x = transform.position.x;
		y = transform.position.y;
		z = transform.position.z;
    	
		transform.position += new Vector3(-000.1f, 0, 0);
    	
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
	        transform.position += new Vector3(0, 0, -1);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
	        transform.position += new Vector3(0, 0, 1);
        }
    }
}

