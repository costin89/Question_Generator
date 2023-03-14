using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonReader : MonoBehaviour
{
    
    public string jsonURL;
    
    // Start is called before the first frame update
    void Start()
    {
        //processJsonData(jsonURL);
        StartCoroutine(getJsonFromURL());
    }
    
    IEnumerator getJsonFromURL()
    {
        Debug.Log("Processing Data, Please Wait");
        WWW _www = new WWW(jsonURL);
        yield return _www;
        if(_www.error == null)
        { 
            processJsonData(_www.text);
        }
        else
        {
            Debug.Log ("Oops something went wrong");
        }
    }
    // Update is called once per frame
     private void processJsonData(string _url)
    {
        jsonClass jsnD = JsonUtility.FromJson<jsonClass>(_url);
        Debug.Log(jsnD.name);
        Debug.Log(jsnD.email);
        Debug.Log(jsnD.age);
    }
}
