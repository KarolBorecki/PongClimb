using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalFollower : MonoBehaviour {

    public Transform objectToFollow;
    private float objectStartY;
    private void Start()
    {
        objectStartY = objectToFollow.position.y;


    }
    void Update () {
        transform.position = new Vector3(transform.position.x, objectToFollow.position.y-objectStartY,transform.position.z);
	}
}
