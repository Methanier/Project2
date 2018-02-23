using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance { get; private set; }

    private string filePath;

    [Header("Player Info")]
    public PlayInfo playerInfo;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        filePath = Application.persistentDataPath + "/" + Application.productName + "gameInfo.txt";
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.S))
        {
            Debug.Log("save");
            SaveInfo();
        }
        if(Input.GetKey(KeyCode.L))
        {
            Debug.Log("load");
            LoadInfo();
        }
    }

    public void SaveInfo()
    {
        string infoJSON = JsonUtility.ToJson(playerInfo);

        File.WriteAllText(filePath, infoJSON);
    }

    public void LoadInfo()
    {
        string infoJSON = File.ReadAllText(filePath);

        playerInfo = JsonUtility.FromJson<PlayInfo>(infoJSON);
    }
}
