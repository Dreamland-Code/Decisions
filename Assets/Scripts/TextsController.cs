using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextsController : MonoBehaviour
{
    private List<GameObject> buttonsPool = new List<GameObject>();
    private TextAnimation textAnimation;

    [SerializeField] int poolAmount = 6;

    [SerializeField] TextsTemplate template;
    [SerializeField] TextsTemplate[] arrayTemplates;

    [SerializeField] TextMeshProUGUI mainText;
    private List<TextMeshProUGUI> responsesTexts = new List<TextMeshProUGUI>();


    [SerializeField] GameObject buttonResponsePrefab;
    [SerializeField] GameObject buttonsParent;

    private void Awake()
    {
        textAnimation = GetComponent<TextAnimation>();
        ObjectPooling();
    }

    // Start is called before the first frame update
    void Start()
    {
        template = arrayTemplates[0];
        if (template.chargeAnotherOptions)
            ShowText();
        else
        {
            StartCoroutine(ShowDialog());
        }
    }

    private void ObjectPooling()
    {
        for (int i = 0; i < poolAmount; i++)
        {
            GameObject go = Instantiate(buttonResponsePrefab, buttonsParent.transform);
            responsesTexts.Add(go.GetComponentInChildren<TextMeshProUGUI>());
            go.SetActive(false);
            buttonsPool.Add(go);
        }
    }

    private GameObject GetObjectInPool()
    {
        foreach (var item in buttonsPool)
        {
            if (!item.activeInHierarchy)
                return item;
        }

        return null;
    }

    private void CreateResponses(int amount)
    {
        List<int> indexes = new List<int>();
        for (int i = 0; i < amount; i++)
        {
            Button responseButton = GetObjectInPool().GetComponent<Button>();
            if(responseButton != null)
            {
                responseButton.onClick.RemoveAllListeners();
                indexes.Add(i);
                int currentIndex = indexes[i];
                responseButton.onClick.AddListener(() => { ControlButtons(currentIndex); });

                responsesTexts[i].text = template.responses[i];
                responseButton.gameObject.SetActive(true);
            }
        }
    }

    private void ShowText()
    {
        mainText.text = template.mainText;
        CreateResponses(template.optionsAmount);
        textAnimation.AnimateText();
    }

    public void ControlButtons(int index)
    {
        template = arrayTemplates[template.arrayReferences[index]];
        if (template.quitButtons)
            DisableButtons();

        if (template.chargeAnotherOptions)
            ShowText();
        else
        {
            StartCoroutine(ShowDialog());
        }
            
    }

    private IEnumerator ShowDialog()
    {
        int i = 0;
        do
        {
            mainText.text = template.dialogs[i];
            textAnimation.AnimateText();
            yield return new WaitUntil(() => !textAnimation.IsDoingAnimation());
            i++;
        } while (i < template.dialogs.Count);

        if (template.endGame) SceneManager.LoadScene("MainMenu");
        
        template = arrayTemplates[template.optionsIndex];
        if (template.quitButtons)
            DisableButtons();

        if (template.chargeAnotherOptions)
            ShowText();
        else
        {
            StartCoroutine(ShowDialog());
        }

    }

    private void DisableButtons()
    {
        foreach (var item in buttonsPool)
        {
            if (item.activeInHierarchy)
                item.SetActive(false);
        }
    }
}
