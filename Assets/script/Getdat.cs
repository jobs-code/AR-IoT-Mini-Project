/*using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Getdat : MonoBehaviour
{
    public InputField tempInputField;
    public InputField humInputField;
    public Button refreshButton;

    void Start()
    {
        // Attach the button click event to the function
        refreshButton.onClick.AddListener(OnRefreshButtonClicked);
    }

    void OnDestroy()
    {
        // Remove the listener when the script is destroyed to avoid memory leaks
        refreshButton.onClick.RemoveListener(OnRefreshButtonClicked);
    }

void OnRefreshButtonClicked()
{
    // Start the coroutine to get data from the API
    StartCoroutine(GetDataCoroutine());
}

    IEnumerator GetDataCoroutine()
    {
        // Set the loading text for input fields
        tempInputField.text = "Loading...";
        humInputField.text = "Loading...";

        // Replace the URL with the actual API endpoint for temperature and humidity data
        string tempUrl = "https://blynk.cloud/external/api/get?token=t9SRm0uM7lAQNHJ0bJ8JsFlaWRzapMxh&v4";
        string humUrl = "https://blynk.cloud/external/api/get?token=t9SRm0uM7lAQNHJ0bJ8JsFlaWRzapMxh&v5";

        // Send the UnityWebRequest to get temperature data
        using (UnityWebRequest tempRequest = UnityWebRequest.Get(tempUrl))
        {
            yield return tempRequest.SendWebRequest();
            if (tempRequest.result == UnityWebRequest.Result.ConnectionError || tempRequest.result == UnityWebRequest.Result.ProtocolError)
                tempInputField.text = tempRequest.error;
            else
            {
                // Set the temperature data to the input field
                tempInputField.text = tempRequest.downloadHandler.text;
            }
        }

        // Send the UnityWebRequest to get humidity data
        using (UnityWebRequest humRequest = UnityWebRequest.Get(humUrl))
        {
            yield return humRequest.SendWebRequest();
            if (humRequest.result == UnityWebRequest.Result.ConnectionError || humRequest.result == UnityWebRequest.Result.ProtocolError)
                humInputField.text = humRequest.error;
            else
            {
                // Set the humidity data to the input field
                humInputField.text = humRequest.downloadHandler.text;
            }
        }
    }
}
*/
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Getdat : MonoBehaviour
{
    public InputField tempInputField;
    public InputField humInputField;

    public void OnRefreshButtonClicked()
    {
        // Start the coroutine to get data from the API
        StartCoroutine(GetDataCoroutine());
    }

    IEnumerator GetDataCoroutine()
    {
        // Set the loading text for input fields
        tempInputField.text = "Loading...";
        humInputField.text = "Loading...";

        // Replace the URL with the actual API endpoint for temperature and humidity data
        string tempUrl = "https://blynk.cloud/external/api/get?token=t9SRm0uM7lAQNHJ0bJ8JsFlaWRzapMxh&v4";
        string humUrl = "https://blynk.cloud/external/api/get?token=t9SRm0uM7lAQNHJ0bJ8JsFlaWRzapMxh&v5";

        // Send the UnityWebRequest to get temperature data
        using (WWW tempRequest = new WWW(tempUrl))
        {
            yield return tempRequest;
            if (!string.IsNullOrEmpty(tempRequest.error))
                tempInputField.text = tempRequest.error;
            else
            {
                // Set the temperature data to the input field
                string temperatureWithSymbol = tempRequest.text + " \u2103";
                tempInputField.text = temperatureWithSymbol;
            }
        }

        // Send the UnityWebRequest to get humidity data
        using (WWW humRequest = new WWW(humUrl))
        {
            yield return humRequest;
            if (!string.IsNullOrEmpty(humRequest.error))
                humInputField.text = humRequest.error;
            else
            {
                // Set the humidity data to the input field
                humInputField.text = humRequest.text;
            }
        }
    }
}
