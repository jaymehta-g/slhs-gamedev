using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public static Player instance {get; private set;}
	private void Start()
	{
		if (instance != null && instance != this) Destroy(gameObject);
		else instance = this;
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
