using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButtonEventsHolder : MonoBehaviour {

    public List<GameObject> objectsToHideOnPlay;
    private GameController gameController;

    void Start()
    {
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
    }

    public void Play(){
        changeMenuActivation(false);
        gameController.Play();
    }

    public void Stop(){
        changeMenuActivation(true);
    }

    private void changeMenuActivation(bool value){
        gameObject.SetActive(value);
        foreach (GameObject obj in objectsToHideOnPlay)
        {
            obj.SetActive(value);
        }
    }
}
