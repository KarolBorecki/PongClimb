using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundGenerator : MonoBehaviour {

    public float firstElementDistance = 7;
    public Vector2 minMargin;
    public Vector2 maxMargin;
    public List<Transform> backgroundElements;

    private Transform lastElement;

    void Start () {
        Vector3 stageDimensions = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        minMargin.x = -stageDimensions.x;
        maxMargin.x = stageDimensions.x;
        lastElement = Instantiate(GetRandomBackgroundElement(),
                                  new Vector3(GetRandomXPosition(), firstElementDistance, 0), transform.rotation) as Transform;
	}
	
	void Update () {
        if(transform.position.y >= lastElement.position.y - 8){
            lastElement = Instantiate(GetRandomBackgroundElement(),
                                      new Vector3(GetRandomXPosition(), lastElement.position.y + GetRandomMargin(), 0), transform.rotation) as Transform;
        }
    }

    Transform GetRandomBackgroundElement(){
        return backgroundElements[Random.Range(0, backgroundElements.Count)];
    }

    float GetRandomMargin(){
        return Random.Range(minMargin.y, maxMargin.y);
    }

    float GetRandomXPosition(){
        return Random.Range(minMargin.x, maxMargin.x);
    }

    public void Reset()
    {
        lastElement.transform.position = new Vector3(0, 7, 0);
    }

}
