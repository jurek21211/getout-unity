using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer masterAudioMixer;

    public TMPro.TMP_Dropdown resolutionDropdown;

    Resolution[] resolutions;

    private void Start()
    {
        FillResolutionsDropDown();
    }
    public void SetVolume(float volumeValue)
    {
        masterAudioMixer.SetFloat("Volume", volumeValue);
    }

    public void SetQuality (int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullScreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    private void FillResolutionsDropDown()
    {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int idx = 0; idx < resolutions.Length; idx++)
        {
            if (resolutions[idx].refreshRate == 60)
            {
                string option = resolutions[idx].width + "x" + resolutions[idx].height;
                options.Add(option);

                if (resolutions[idx].width == Screen.currentResolution.width &&
                    resolutions[idx].height == Screen.currentResolution.height)
                {
                    currentResolutionIndex = idx;
                }
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

}
