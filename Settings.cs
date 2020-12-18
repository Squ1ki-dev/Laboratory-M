using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[SerializeField] private enum Type
{
    None,
    Slider,
    Dropdown,
    Toggle
}

[SerializeField] private class Settings : MonoBehaviour {
    
    //Quality Settings
    [SerializeField] private Type gSelectType;
    [SerializeField] private Slider gSlider;
    [SerializeField] private Dropdown gDropdown;
    [SerializeField] private Text gText;
    [SerializeField] private string gSaveKey = "Quality";

    //Resolution Settings
    [SerializeField] private Type rSelectType;
    [SerializeField] private Slider rSlider;
    [SerializeField] private Dropdown rDropdown;
    [SerializeField] private string rFormat;
    [SerializeField] private Text rText;
    [SerializeField] private string rSaveKey = "Resolution";

    private string[] strRes;
    private Resolution[] res;

    //FullscreenMode
    [SerializeField] private Type wSelectType;
    [SerializeField] private Toggle wToggle;
    [SerializeField] private string wSaveKey = "FullscreenMode";

    // Use this for initialization
    void Start () {

        if (wSelectType == Type.Toggle)
        {
            toggleFullscreenMode();
        }

        if (gSelectType == Type.Dropdown)
        {
            dropdownQuality();
        }
        if(gSelectType == Type.Slider)
        {
            sliderQuality();
        }

        if (rSelectType == Type.Dropdown)
        {
            dropDownResolution();
        }
        if (rSelectType == Type.Slider)
        {
            sliderResolution();
        }
    }

    void sliderQuality()
    {
        gSlider.minValue = 0;
        gSlider.maxValue = QualitySettings.names.Length - 1;
        gSlider.wholeNumbers = true;

        if (PlayerPrefs.HasKey(gSaveKey))
        {
            gSlider.value = PlayerPrefs.GetInt(gSaveKey);
            QualitySettings.SetQualityLevel(PlayerPrefs.GetInt(gSaveKey));
            gText.text = QualitySettings.names[PlayerPrefs.GetInt(gSaveKey)];
        }
        else
        {
            gSlider.value = QualitySettings.GetQualityLevel();
            gText.text = QualitySettings.names[QualitySettings.GetQualityLevel()];
        }
    }

    void dropdownQuality ()
    {
        gDropdown.ClearOptions();
        gDropdown.AddOptions(QualitySettings.names.ToList());
        if (PlayerPrefs.HasKey(gSaveKey))
        {
            gDropdown.value = PlayerPrefs.GetInt(gSaveKey);
            QualitySettings.SetQualityLevel(PlayerPrefs.GetInt(gSaveKey));
        }
        else
        {
            gDropdown.value = QualitySettings.GetQualityLevel();
        }
    }

    void dropDownResolution ()
    {
        Resolution[] resolution = Screen.resolutions;
        res = resolution.Distinct().ToArray();

        strRes = new string[res.Length];
        for (int i = 0; i < res.Length; i++)
        {
            strRes[i] = string.Format(rFormat, res[i].width.ToString(), res[i].height.ToString(), res[i].refreshRate.ToString());
        }
        rDropdown.ClearOptions();
        rDropdown.AddOptions(strRes.ToList());

        if (PlayerPrefs.HasKey(rSaveKey))
        {
            rDropdown.value = PlayerPrefs.GetInt(rSaveKey);
            Screen.SetResolution(res[PlayerPrefs.GetInt(rSaveKey)].width, res[PlayerPrefs.GetInt(rSaveKey)].height, Screen.fullScreen);
        }
        else
        {
            rDropdown.value = res.Length - 1;
            Screen.SetResolution(res[res.Length - 1].width, res[res.Length - 1].height, Screen.fullScreen);
        }
    }

    void sliderResolution()
    {
        Resolution[] resolution = Screen.resolutions;
        res = resolution.Distinct().ToArray();

        strRes = new string[res.Length];
        for (int i = 0; i < res.Length; i++)
        {
            strRes[i] = string.Format(rFormat, res[i].width.ToString(), res[i].height.ToString(), res[i].refreshRate.ToString());
        }

        rSlider.minValue = 0;
        rSlider.maxValue = res.Length - 1;
        rSlider.wholeNumbers = true;

        if (PlayerPrefs.HasKey(rSaveKey))
        {
            rSlider.value = PlayerPrefs.GetInt(rSaveKey);
            Screen.SetResolution(res[PlayerPrefs.GetInt(rSaveKey)].width, res[PlayerPrefs.GetInt(rSaveKey)].height, Screen.fullScreen);
            rText.text = strRes[PlayerPrefs.GetInt(rSaveKey)];
        }
        else
        {
            rSlider.value = res.Length-1;
            rText.text = strRes[res.Length-1];
            Screen.SetResolution(res[res.Length - 1].width, res[res.Length - 1].height, Screen.fullScreen);
        }
    }

    void toggleFullscreenMode ()
    {
        if (PlayerPrefs.HasKey(wSaveKey))
        {
            if (PlayerPrefs.GetInt(wSaveKey) == 0)
            {
                Screen.fullScreen = false;
                wToggle.isOn = !Screen.fullScreen;
            }
            else
            {
                Screen.fullScreen = true;
                wToggle.isOn = !Screen.fullScreen;
            }
        }
        else
        {
            Screen.fullScreen = true;
            wToggle.isOn = !Screen.fullScreen;
        }
    }

    [SerializeField] private void SetQuality()
    {
        if (gSelectType == Type.Dropdown)
        {
            QualitySettings.SetQualityLevel(gDropdown.value);
            PlayerPrefs.SetInt(gSaveKey, gDropdown.value);
        }

        if(gSelectType == Type.Slider)
        {
            QualitySettings.SetQualityLevel((int)gSlider.value);
            gText.text = QualitySettings.names[(int)gSlider.value];
            PlayerPrefs.SetInt(gSaveKey, (int)gSlider.value);
        }
    }

    [SerializeField] private void SetResolution()
    {
        if (rSelectType == Type.Dropdown)
        {
            Screen.SetResolution(res[rDropdown.value].width, res[rDropdown.value].height, Screen.fullScreen);
            PlayerPrefs.SetInt(rSaveKey, rDropdown.value);
        }

        if (rSelectType == Type.Slider)
        {
            Screen.SetResolution(res[(int)rSlider.value].width, res[(int)rSlider.value].height, Screen.fullScreen);
            QualitySettings.SetQualityLevel((int)rSlider.value);
            rText.text = strRes[(int)rSlider.value];
            PlayerPrefs.SetInt(rSaveKey, (int)rSlider.value);
        }
    }

    [SerializeField] private void SetFullscreenMode ()
    {
        if (wSelectType == Type.Toggle)
        {
            Screen.fullScreen = !wToggle.isOn;
            if (Screen.fullScreen)
            {
                PlayerPrefs.SetInt(wSaveKey, 1);
            }
            else
            {
                PlayerPrefs.SetInt(wSaveKey, 0);
            }
        }   
    }

    [SerializeField] private void DeleteSettingsSaves()
    {
        PlayerPrefs.DeleteAll();
    }
}
