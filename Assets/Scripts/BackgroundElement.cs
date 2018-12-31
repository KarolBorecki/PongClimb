using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundElement : MonoBehaviour {

    public float destroyMargin = 6;
    public Vector2 speedRandom;

    private float speed;

    private void Start()
    {

        speed = Random.Range(speedRandom.x, speedRandom.y);
    }

    void Update()
    {
        if (transform.position.y <= Camera.main.transform.position.y - destroyMargin) Destroy(gameObject);

        transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));

    }
}
