using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockPositioning : MonoBehaviour {

    public int block;
	void Start () {
        Vector3 stageDimensions = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        transform.position = new Vector3(stageDimensions.x * block, stageDimensions.y, 0);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
