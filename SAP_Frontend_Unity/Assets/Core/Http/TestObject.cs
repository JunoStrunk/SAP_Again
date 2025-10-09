using System;
using System.Collections;
using System.Net;
using UnityEngine;
using UnityEngine.Networking;

public class TestObject : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void PostTest()
    {
        StartCoroutine(PostRequest());
    }

    public void GetTest()
    {
        StartCoroutine(GetRequest());
    }

    IEnumerator GetRequest()
    {
        string uri = "https://localhost:7155/api/teams";
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                    break;
            }
        }
    }

    IEnumerator PostRequest()
    {
        string JSON = "{\"Id\":0,\"Round\":2,\"Wins\":1,\"PetIds\":[\"Turtle\",\"Turtle\",\"Turtle\",\"Turtle\",\"Turtle\"]}";

        var uwr = new UnityWebRequest("https://localhost:7155/api/teams", "POST");

        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(JSON);
        uwr.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
        uwr.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        uwr.SetRequestHeader("Content-Type", "application/json");

        //Send the request then wait here until it returns
        yield return uwr.SendWebRequest();

        if (uwr.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.Log("Error while sending: " + uwr.error);
        }
        else
        {
            Debug.Log("Recieved: " + uwr.downloadHandler.text);
        }
    }
}
