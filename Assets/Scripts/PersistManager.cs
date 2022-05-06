using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PersistManager : MonoBehaviour
{
    public static PersistManager persistentManager;
    public string userName;
    public string bestUserName;
    public int bestScore;

    private void Awake()
    {
        if(persistentManager == null)
        {
            persistentManager = this;
            DontDestroyOnLoad(this);
            LoadTheData();
        }
        else
        {
            Destroy(this);
        }
        
    }

   
    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveTheData()
    {
        SaveData data = new SaveData();
        data.userName = this.userName;
        data.bestScore = this.bestScore;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/saveData.json", json);
    }

    public void LoadTheData()
    {
        if(File.Exists(Application.persistentDataPath + "/saveData.json"))
        {
            string json = File.ReadAllText(Application.persistentDataPath + "/saveData.json");
            SaveData saveData = JsonUtility.FromJson<SaveData>(json);
            this.bestUserName = saveData.userName;
            this.bestScore = saveData.bestScore;
        }
               
    }

    public void InitTheData()
    {
        File.Delete(Application.persistentDataPath + "/saveData.json");
        this.bestScore = 0;
        this.bestUserName = "";
    }


    [System.Serializable]
    class SaveData
    {
        public string userName;
        public int bestScore;
    }
}
