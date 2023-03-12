using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class JsonReader : MonoBehaviour
{
    public string webURL;
    private string logFilePath = "log.txt";

    void Start()
    {
        StartCoroutine(GetJSONData());
    }

    IEnumerator GetJSONData()
    {
        UnityWebRequest www = UnityWebRequest.Get(webURL);

        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Error while fetching JSON data: " + www.error);
            yield break;
        }

        string json = www.downloadHandler.text;
        Debug.Log(json);

        WriteToLog(json);
    }

    void WriteToLog(string json)
    {
        // write to log file
        using (System.IO.StreamWriter file = new System.IO.StreamWriter(logFilePath, true))
        {
            file.WriteLine(json);
        }
    }
}