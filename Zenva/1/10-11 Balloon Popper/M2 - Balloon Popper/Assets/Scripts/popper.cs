using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popper : MonoBehaviour {

    public float scaleFactor = 1.2f;
    public float maxScale = 3.0f;
	// Use this for initialization
	void Start ()
    {
		if(scaleFactor <= 1.0)
        {
            Debug.Log("Value too Small");
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnMouseDown()
    {
        transform.localScale *= scaleFactor;
        if(transform.localScale.x >= maxScale)
        {
            Destroy(gameObject);
        }
    }
}
