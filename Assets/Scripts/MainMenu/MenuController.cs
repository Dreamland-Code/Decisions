using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] Button playButton;
    [SerializeField] Button continueButton;
    [SerializeField] Button optionsButton;
    [SerializeField] Button exitButton;

    private void Awake()
    {
        playButton.onClick.AddListener(LoadNewGame);
        exitButton.onClick.AddListener(CloseGame);
    }

    private void CloseGame()
    {
        Application.Quit();
    }

    private void LoadNewGame()
    {
        SceneManager.LoadScene("Game");
    }
}
