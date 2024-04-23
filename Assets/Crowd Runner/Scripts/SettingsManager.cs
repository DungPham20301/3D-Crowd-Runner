using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{

    [Header("Elements")]
    [SerializeField] private VibrationManager vibrationManager;
    [SerializeField] private SoundsManager soundsManager;
    [SerializeField] private Sprite optionsOnSprite;
    [SerializeField] private Sprite optionsOffSprite;
    [SerializeField] private Image soundsButtonImage;
    [SerializeField] private Image virbationButtonImage;

    [Header("Settings")]
    private bool soundsState = true;
    private bool vibrationState = true;

    private void Awake()
    {
        soundsState = PlayerPrefs.GetInt("sounds", 1) == 1;
        vibrationState = PlayerPrefs.GetInt("vibration", 1) == 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        Setup();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Setup()
    {
        if (soundsState)
            EnableSounds();
        else
            DisableSounds();


        if (vibrationState)
            EnableVibration();
        else
            DisableVibration();
    }

    public void ChangeSoundsState()
    {
        if (soundsState)
            DisableSounds();
        else
            EnableSounds();

        soundsState = !soundsState;

        // Save the value of the sound state

        PlayerPrefs.SetInt("sounds", soundsState ? 1 : 0);

    }

    private void DisableSounds()
    {
        // Tell the sounds manager to set the volume of all the sounds to 0
        soundsManager.DisableSounds();

        // Change the image of the sounds button
        soundsButtonImage.sprite = optionsOffSprite;
    }

    private void EnableSounds()
    {
        soundsManager.EnableSounds();

        // Change the image of the sounds button
        soundsButtonImage.sprite = optionsOnSprite;
    }

    public void ChangeVibrationState()
    {
        if (vibrationState)
            DisableVibration();
        else 
            EnableVibration();

        vibrationState = !vibrationState; 

        // Save the value of the vibration state

        PlayerPrefs.SetInt("vibration", vibrationState ? 1 : 0);
    }

    private void DisableVibration()
    {
        vibrationManager.DisableVibration();

        virbationButtonImage.sprite = optionsOffSprite;
    }

    private void EnableVibration()
    {
        vibrationManager.EnableVibration();

        virbationButtonImage.sprite = optionsOnSprite;
    }
}
