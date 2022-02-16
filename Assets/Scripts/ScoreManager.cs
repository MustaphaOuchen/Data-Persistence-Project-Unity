using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


//Class to handle serialization of highscore between scenes
public class ScoreManager : MonoBehaviour
{

    //Singleton
    public static ScoreManager Instance;

    public int Score = 0;
    public string Name = "";

    //Needed for HS update
    public string EnteredName = "";

    private void Awake()
    {
        //Make sure that ot exists only once, even if we go back
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        Instance = this;
        DontDestroyOnLoad(gameObject);

        //LoadDataJson();

    }

    //Serialization stuff

    [System.Serializable]
    class SaveData
    {
        public int Score;
        public string Name;
    }

    public void SaveDataJson()
    {
        SaveData data = new SaveData();
        data.Score = Score;
        data.Name = Name;
        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public bool LoadDataJson()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            Score = data.Score;
            Name = data.Name;
            return true;
        }

        return false;
    }

}
