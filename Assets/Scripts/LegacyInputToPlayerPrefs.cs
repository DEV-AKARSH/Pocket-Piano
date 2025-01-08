using UnityEngine;
using UnityEngine.UI; // Required for UI components

public class LegacyInputToPlayerPrefs : MonoBehaviour
{
    public InputField legacyInputField; // Reference to the legacy InputField component
    public string playerPrefKey = "UserName"; // Key to store the value in PlayerPrefs
    public GameObject NameEnterPannel;

    void Start()
    {
        string nm = PlayerPrefs.GetString("UserName", "NF");
        if (nm == "NF")
        {
            NameEnterPannel.SetActive(true);
        }else
        {
            NameEnterPannel.SetActive(false);
            
        }
    }

    public void SaveInputToPlayerPrefs()
    {
        // Get the value from the input field
        string userInput = legacyInputField.text;

        // Save the value to PlayerPrefs
        PlayerPrefs.SetString(playerPrefKey, userInput);

        // Optionally, save PlayerPrefs to disk immediately
        PlayerPrefs.Save();

        Debug.Log($"Input saved to PlayerPrefs: {userInput}");
    }
}
