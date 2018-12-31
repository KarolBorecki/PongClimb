using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public int record;
    public int points;
    public bool isInGame = false;
    public bool isFirstGame = true;
    public Vector3 startingPos;

    public string infoRecordText = "record ";
    public Text recordText;

    public string infoPointsText = "";
    public Text pointsText;

    public string infoPointsEarnedText = "";
    public Text pointsEarnedText;

    public Saving gameSaves;
    public Transform pointsReference;

    [HideInInspector] public Transform player;
    private LevelGenerator levelGenerator;
    private ControllerMove controllerMove;
    private PlayButtonEventsHolder playBtn;
    private PlayButtonEventsHolder restartBtn;


    void Start () {
        changeIsInGame(isInGame);
        setRecordText(gameSaves.Load());

        levelGenerator = GameObject.FindWithTag("LevelGenerator").GetComponent<LevelGenerator>();
        player = GameObject.FindWithTag("Ball").GetComponent<Transform>();
        playBtn = GameObject.FindWithTag("PlayBtn").GetComponent<PlayButtonEventsHolder>();
        controllerMove = GetComponent<ControllerMove>();
    }
	
	void Update () {
        int realPoints = (int) pointsReference.position.y * 10;
        if(realPoints>points)
            setPointsText(realPoints);

    }

    public void Play(){
        controllerMove.Reset(); levelGenerator.GetComponent<BackgroundGenerator>().Reset();

        levelGenerator.clearStructures();
        changeIsInGame(true);
        isFirstGame = false;

        setPointsText(0);

        gameObject.transform.position = startingPos;
        pointsText.gameObject.SetActive(true);
        pointsEarnedText.gameObject.SetActive(false);
        levelGenerator.StartGeneratingStructures(record);

        levelGenerator.GetComponent<ColorCycle>().Reset();

    }

    public void GameOver(){
        changeIsInGame(false);
        playBtn.Stop();
        levelGenerator.StopGeneratingStructures();
        if (record<points){
            setRecordText(points);
        }
        setPointsEarnedText();
        pointsEarnedText.gameObject.SetActive(true);
        setPointsText(0);
        pointsText.gameObject.SetActive(false);
    }

    private void changeIsInGame(){
        changeIsInGame(!isInGame);
    }

    private void changeIsInGame(bool inGame){
        isInGame = inGame;
        Time.timeScale = isInGame ? 1 : 0;
    }

    private void setRecordText(int number){
        record = number;
        recordText.text = infoRecordText + record.ToString();
        gameSaves.Save(record);
    }

    private void setPointsText(int number)
    {
        points = number;
        if (number % 75 == 0)
            controllerMove.speed *= controllerMove.speedingUp;
        pointsText.text = infoPointsText + points.ToString();
    }

    private void setPointsEarnedText()
    {
        pointsEarnedText.text = infoPointsEarnedText + points.ToString();
    }
}
