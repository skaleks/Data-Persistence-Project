using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    private const string defaultName = "Nobody scored more than";


    private void Awake()
    {

        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Для обмена данными между сессиями
    [System.Serializable]
    class SaveData
    {
        public string BestName;
        public int BestScore;
    }

    public int LoadBestScore()
    {
        string path = Application.persistentDataPath + "/bestscore.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            return data.BestScore;
        }

        return 0;
    }

    public void SaveBestScore(int score)
    {
        SaveData data = new SaveData();
        data.BestScore = score;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/bestscore.json", json);
    }

    public string LoadBestName()
    {
        string path = Application.persistentDataPath + "/bestname.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            return data.BestName;
        }

        return defaultName;
    }

    public void SaveBestName(string name)
    {
        SaveData data = new SaveData();
        data.BestName = name;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/bestname.json", json);
    }

    public void ResetBestResult()
    {
        SaveBestScore(0);
        SaveBestName(defaultName);
    }
}
