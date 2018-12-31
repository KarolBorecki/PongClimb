using UnityEngine;

public class Saving : MonoBehaviour
{
   public void SaveRecord(int record){
        PlayerPrefs.SetInt("record", record);
        PlayerPrefs.Save();
    }

    public static int LoadRecord(){
        int record = PlayerPrefs.GetInt("record");
        return record;
    }
    public void Save(int record){
        SaveRecord(record);
    }
    public int Load(){
        return LoadRecord();
    }
}