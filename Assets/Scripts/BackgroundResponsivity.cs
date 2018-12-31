using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundResponsivity : MonoBehaviour {

	void Start () {
        Resize();
	}

    void Resize()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();

        float worldScreenHeight = Camera.main.orthographicSize * 2;
        float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

        transform.localScale = new Vector3(
            worldScreenWidth / sr.sprite.bounds.size.x  + 0.01f,
            worldScreenHeight / sr.sprite.bounds.size.y + 0.01f, 1);


    }
}
