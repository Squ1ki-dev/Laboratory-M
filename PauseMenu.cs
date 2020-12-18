using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PauseType
{
    Keyboard,
    UIButton
}

public class PauseMenu : MonoBehaviour
{
    public PauseType buttonType;
    public KeyCode pauseButton;
    public GameObject pausePanel;
    public GameObject settingsPanel;
    
    public bool useSettingsPanel;
    public bool controlCursor;
    public bool showMenuCursor;
    public bool hideGameCursor;

    public bool isPaused;

    // Update is called once per frame
    void Update()
    {
        if (buttonType == PauseType.Keyboard)
        {
            if (Input.GetKeyDown(pauseButton))
            {
                SetState();
            }
        }
        CheckSettingsPanel();
    }

    void SetState()
    {
        if (useSettingsPanel)
        {
            if (!settingsPanel.activeSelf)
            {
                ChangeState();
            }
            else
            {
                HideSettings();
            }
        }
        else
        {
            ChangeState();
        }
    }

    void ChangeState()
    {
        isPaused = !isPaused;
    }

    void CheckSettingsPanel()
    {
        if (useSettingsPanel)
        {
            if (settingsPanel.activeSelf)
            {
                return;
            }
        }
        CheckState();
    }

    void CheckState()
    {
        if (isPaused)
        {
            OnPaused();
        }
        else
        {
            OnResume();
        }
    }

    void HideSettings()
    {
        settingsPanel.SetActive(false);
    }

    void OnPaused()
    {
        pausePanel.SetActive(true);
        if (controlCursor)
        {
            if (showMenuCursor)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
        }
        Time.timeScale = 0;
    }

    void OnResume()
    {
        pausePanel.SetActive(false);
        if (controlCursor)
        {
            if (hideGameCursor)
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
        Time.timeScale = 1;
    }

    public void Resume()
    {
        isPaused = false;
    }

    public void Pause()
    {
        if (buttonType== PauseType.UIButton)
        {
            isPaused = true;
        }
    }
}
