using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    public AudioSource[] PianoAudioSource;
    public AudioSource[] DrumAudioSource;
    public Text Display, drumBTN, on_off, User_Name;
    public GameObject NameEnterPannel;

    public bool drumEnabled = false;
    public bool Power = false;
    // Start is called before the first frame update
    void Start()
    {
        string nm = PlayerPrefs.GetString("UserName", "NF");
        if (nm == "NF")
        {
            NameEnterPannel.SetActive(true);
        }
        else
        {
            User_Name.text = nm;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayClicked(int AudioIndex)
    {
        if (Power)
        {
            if (drumEnabled)
            {
                Display.text = DrumAudioSource[AudioIndex].name;

                PlayDrumAudio(AudioIndex);
            }
            else
            {
                Display.text = PianoAudioSource[AudioIndex].name;

                PlayPianoAudio(AudioIndex);
            }
        }
    }
    void PlayPianoAudio(int audioNumber)
    {
        if (audioNumber >= 0 && audioNumber < PianoAudioSource.Length) // Check if the index is valid
        {

            PianoAudioSource[audioNumber].Play(); // Play the assigned clip
            StartCoroutine(ClearTextAfterSeconds(2)); // Clear text after 3 seconds

        }
        else
        {
            Debug.LogWarning("Audio number is out of range!");
        }

    }
    void PlayDrumAudio(int audioNumber)
    {
        if (audioNumber >= 0 && audioNumber < DrumAudioSource.Length) // Check if the index is valid
        {
            DrumAudioSource[audioNumber].Play(); // Play the assigned clip
            StartCoroutine(ClearTextAfterSeconds(2)); // Clear text after 3 seconds

        }
        else
        {
            Debug.LogWarning("Audio number is out of range!");
        }

    }

    public void ToggleDrumMode()
    {
        drumEnabled = !drumEnabled; // Toggle the drumEnabled flag
        drumBTN.text = drumEnabled ? "On" : "Off";
        Display.text = drumEnabled ? "Mode: Drums" : "Mode: Piano"; // Update the display text
        StartCoroutine(ClearTextAfterSeconds(2)); // Clear the text after 2 seconds
    }
    public void TogglePower()
    {
        Power = !Power; // Toggle the Power flag
        on_off.text = Power ? "On" : "Off";
        Display.text = Power ? "Power On" : "Power Off";
        StartCoroutine(ClearTextAfterSeconds(2)); // Clear the text after 2 seconds
    }
    IEnumerator ClearTextAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Display.text = "";
    }
    public void setName()
    {
        string nm = PlayerPrefs.GetString("UserName", "NF");
        if (nm == "NF")
        {
            NameEnterPannel.SetActive(true);
        }
        else
        {
            User_Name.text = nm;
        }
    }
}
