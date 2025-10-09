using UnityEngine;
using UnityEngine.Networking;

public static class HttpService
{
    public async static void PostRequestTest()
    {
        string JSON = "{\"Id\":0,\"Round\":2,\"Wins\":1,\"PetIds\":[\"Turtle\",\"Turtle\",\"Turtle\",\"Turtle\",\"Turtle\"]}";

        var uwr = new UnityWebRequest("https://localhost:7155", "POST");

        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(JSON);
        uwr.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
        uwr.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        uwr.SetRequestHeader("Content-Type", "application/json");

        await uwr.SendWebRequest();

        if(uwr.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.Log("Error while sending: " + uwr.error);
        }
        else
        {
            Debug.Log("Recieved: " + uwr.downloadHandler.text);
        }
    }
}
