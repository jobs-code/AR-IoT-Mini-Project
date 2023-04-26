using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine.Networking;

public class SliderText : MonoBehaviour
{
    public Slider slider; // Reference to the Slider component in the Unity editor
    public string token ; // Blynk token
    public string pinNumber; // Blynk virtual pin number

    // URL format for the Blynk API
    private string apiUrlFormat = "https://blynk.cloud/external/api/update?token={0}&v{1}={2}";

    // Method to be called when the slider value changes
    public void OnSliderValueChanged()
    {
        float sliderValue = slider.value; // Get the current value of the slider

        // Build the URL with the token, pin number, and slider value
        string apiUrl = string.Format(apiUrlFormat, token, pinNumber, sliderValue);

        // Send a UnityWebRequest to the API endpoint
        StartCoroutine(SendRequest(apiUrl));
    }

    // Coroutine to send the API request
    private IEnumerator SendRequest(string url)
    {
        UnityWebRequest request = UnityWebRequest.Get(url);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError("Error sending request: " + request.error);
        }
        else
        {
            Debug.Log("Request sent successfully.");
        }
    }
}


/*using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine.Networking;

public class SliderText : MonoBehaviour
{
    public Slider slider; // Reference to the Slider component in the Unity editor
    public string token ; // Blynk token
    public string pinNumber; // Blynk virtual pin number

    // URL format for the Blynk API
    private string apiUrlFormat = "https://blynk.cloud/external/api/update?token={0}&v{1}={2}";

    // Method to be called when the slider value changes
    public void OnSliderValueChanged()
    {
        if (slider != null)
        {
            float sliderValue = slider.value; // Get the current value of the slider

            // Build the URL with the token, pin number, and slider value
            string apiUrl = string.Format(apiUrlFormat, token, pinNumber, sliderValue);

            // Send a UnityWebRequest to the API endpoint
            StartCoroutine(SendRequest(apiUrl));
        }
    }

    // Coroutine to send the API request
    private IEnumerator SendRequest(string url)
    {
        UnityWebRequest request = UnityWebRequest.Get(url);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError("Error sending request: " + request.error);
        }
        else
        {
            if (request.responseCode == 200)
            {
                Debug.Log("Request sent successfully.");
            }
            else
            {
                Debug.LogError("Bad Request. Response code: " + request.responseCode);
            }
        }
    }
}
*/