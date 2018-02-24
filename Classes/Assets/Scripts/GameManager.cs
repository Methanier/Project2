using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance { get; private set; }

    [Tooltip("Address to download file from")]
    public string webAddress;
    [Tooltip("Text Asset to hold playerinfo")]
    public TextAsset saveInfo;

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

    }

    public void SaveInfoToDisk()
    {
        Debug.Log("Save To Disk");
        string infoJSON = JsonUtility.ToJson(playerInfo);

        File.WriteAllText(filePath, infoJSON);
    }

    public void LoadInfoFromDisk()
    {
        Debug.Log("Load From Disk");
        string infoJSON = File.ReadAllText(filePath);

        playerInfo = JsonUtility.FromJson<PlayInfo>(infoJSON);
    }

    public void LoadInfoFromResources()
    {
        if(saveInfo == null)
        {
            saveInfo = Resources.Load<TextAsset>("ClassesgameInfo") as TextAsset;
        }

        string infoJSON = saveInfo.text;

        playerInfo = JsonUtility.FromJson<PlayInfo>(infoJSON);
    }

    public void LoadInfoFromWeb()
    {
        StartCoroutine("GetFromWeb");
    }

    public IEnumerator GetFromWeb()
    {
        Debug.Log("Load From Web");
        yield return null;
    }
}
