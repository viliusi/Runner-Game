using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eagle : MonoBehaviour
{
	public int timeToWait;
	
    // Start is called before the first frame update
    void Start()
    {
	  
    }

    // Update is called once per frame
	void FixedUpdate()
    {
	    if (timeToWait > 0)
	    {
	    	timeToWait--;
	    }
	    else
	    {
	    	transform.position = new Vector3(Random.Range(-8f, 8f), 0, Random.Range(-4.5f, 4.5f));
	    	timeToWait = 30;
	    }
    }
}
