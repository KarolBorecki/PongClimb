using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ColorCycle : MonoBehaviour{

    public float timeOfFirstTransition;
    public float timeOfTransition;
    public Color firstColor;
    public Vector2 colors;

    private float timeLeft;
    private Color targetColor;

    public GameController gameController;

    void Start()
    {
        Reset();
    }

    void Update()
    {
        if (timeLeft <= Time.deltaTime)
        {
            Camera.main.backgroundColor = targetColor;

            targetColor = new Color(Random.Range(colors.x, colors.y), Random.Range(colors.x, colors.y), Random.Range(colors.x, colors.y));
            timeLeft = timeOfTransition;
        }
        else
        {
            Camera.main.backgroundColor = Color.Lerp(Camera.main.backgroundColor, targetColor, Time.deltaTime / timeLeft);

            timeLeft -= Time.deltaTime;
        }
    }

    public void Reset()
    {
        timeLeft = timeOfTransition;
        targetColor = firstColor;
        Camera.main.backgroundColor = firstColor;
    }

    public void SetColorToDefault(){
        Camera.main.backgroundColor = Color.Lerp(Camera.main.backgroundColor, firstColor, Time.deltaTime / timeLeft);
    }
}
