using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIGameController : MonoBehaviour
{
    [SerializeField] Button goToMenuButton;

    private void Awake()
    {
        goToMenuButton.onClick.AddListener(GoToMenu);
    }

    private void GoToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
