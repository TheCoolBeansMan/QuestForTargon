using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    public GameObject nextButton;
    public GameObject storyText;
    public GameObject mainMenuPanel;
    public GameObject helpPanel;
    public GameObject playerPanel;
    public void OnNextButtonPressed()
    {
        nextButton.SetActive(false);
        storyText.SetActive(false);
        mainMenuPanel.SetActive(true);
        helpPanel.SetActive(false);
    }
    public void OnHelpButtonPressed()
    {
        
        helpPanel.SetActive(true);
        mainMenuPanel.SetActive(false);
    }
    public void OnPlayerButtonPressed()
    {

        playerPanel.SetActive(true);
        mainMenuPanel.SetActive(false);
    }
    public void Quit()
    {
        Debug.Log("Game is quitting..."); // For testing in the editor
        Application.Quit();
    }
}
