using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerMove : MonoBehaviour {

    public float speed = 1f;
    private float startSpeed;
    public float speedingUp = 1.3f;

    private void Start()
    {
        startSpeed = speed;
    }
    void Update () {
        transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));
	}
    public void Reset()
    {
        speed = startSpeed;
    }
}
