using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

public class GameManager : MonoBehaviour {

    public static GameManager instance { get; private set; }

    [Tooltip("Address to download file from")]
    public string webAddress;
    [Tooltip("Text Asset to hold playerinfo")]
    public TextAsset saveInfo;

    public List<TextAsset> saves;

    private string filePath;

    [Header("Player Info")]
    public PlayInfo playerInfo;

    public MenuManager mm;

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
        Debug.Log("Load from Resources");
        if(saveInfo == null)
        {
            saveInfo = Resources.Load<TextAsset>("ClassesgameInfo") as TextAsset;
        }

        string infoJSON = saveInfo.text;

        playerInfo = JsonUtility.FromJson<PlayInfo>(infoJSON);
    }

    public void LoadAllFromResources()
    {
        Debug.Log("Load all from resources");
        TextAsset[] temp = Resources.LoadAll<TextAsset>("Data");

        saves = new List<TextAsset>(temp);
    }

    public void LoadInfoFromWeb()
    {
        StartCoroutine("GetFromWeb");
    }

    public IEnumerator GetFromWeb()
    {
        UnityWebRequest request;
        string infoJSON;

        request = UnityWebRequest.Get(webAddress);

        yield return request.SendWebRequest();

        if (request.isNetworkError)
        {
            Debug.Log(request.error);
        }
        else
        {
            infoJSON = ((DownloadHandler)request.downloadHandler).text;
            playerInfo = JsonUtility.FromJson<PlayInfo>(infoJSON);
        }

        mm.UpdateInputFields();
    }

    public void DispalySaves()
    {
        StartCoroutine("DisplayLoads");
    }

    public IEnumerator DisplayLoads()
    {
        foreach(TextAsset ta in saves)
        {
            string temp = ta.text;
            playerInfo = JsonUtility.FromJson<PlayInfo>(temp);
            mm.UpdateInputFields();
            yield return new WaitForSeconds(2);
        }
    }
}
