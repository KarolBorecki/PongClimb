using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {

    public Transform player;
    public float firstSetDistance = 5f;
    public float generalMargin = 1f;
    public bool isGenerating = false;

    public List<BlocksSet> blockSets;

    private Vector2 playerStartingPos;
    private BlocksSet next, actuall, earlier;

    void Start () {
        playerStartingPos = player.position;
        actuall = InstantiateBlockSet(GetRandomSet(), firstSetDistance-200);

        next = InstantiateBlockSet(GetRandomSet(), actuall.transform.position.y + actuall.margin-200);

        earlier = InstantiateBlockSet(GetRandomSet(), actuall.transform.position.y - 200);
    }
	
	void Update () {
        if(actuall != null && player.position.y >= actuall.transform.position.y + 1f && isGenerating){
            generatenext();
        }
	}

    void generatenext(){
        if (earlier != null) Destroy(earlier.gameObject);
        earlier = actuall;
        actuall = next;
        next = InstantiateBlockSet(GetRandomSet(), actuall.transform.position.y + actuall.margin + generalMargin);
    }

    void firstGenerate(){
        actuall = InstantiateBlockSet(GetRandomSet(), firstSetDistance);

        next = InstantiateBlockSet(GetRandomSet(), actuall.transform.position.y + actuall.margin);

        earlier = InstantiateBlockSet(GetRandomSet(), actuall.transform.position.y - 200);

    }

    public void StartGeneratingStructures(int level){
        isGenerating = true;

        firstGenerate();
    }

    public void StopGeneratingStructures(){
        isGenerating = false;
    }

    public void clearStructures(){
        Destroy(next.gameObject);
        Destroy(actuall.gameObject);
        Destroy(earlier.gameObject);

        GameObject[] objs = GameObject.FindGameObjectsWithTag("ShootBall");

        foreach (GameObject obj in objs) Destroy(obj);
    }

    BlocksSet GetRandomSet(){
        return blockSets[Random.Range(0, blockSets.Count)];
    }

    BlocksSet InstantiateBlockSet(BlocksSet set, float y){
        return Instantiate(set, new Vector3(0, y, 0), player.rotation);
    }
}
