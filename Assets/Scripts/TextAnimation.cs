using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextAnimation : MonoBehaviour
{
    private string historyTextContent;
    private bool doingAnimation;
    private IEnumerator coroutine;

    [SerializeField] TextMeshProUGUI historyText;

    public bool IsDoingAnimation() => doingAnimation;

    public void AnimateText()
    {
        coroutine = AnimateHistoryText();
        if (!doingAnimation)
            StartCoroutine(coroutine);
    }

    /*private void Update()
    {
        if(doingAnimation)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
            {
                
                
                StartCoroutine(FinishDialog());
                //doingAnimation = false;
            }
            
        }
    }*/

    private IEnumerator FinishDialog()
    {
        //yield return new WaitForSeconds(0.5f);
        yield return new WaitUntil(() =>
        (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return)));
        StopCoroutine(coroutine);
        historyText.text = historyTextContent;
        yield return new WaitForSeconds(0.02f);
        yield return new WaitUntil(() =>
        (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return)));
        doingAnimation = false;
    }

    private IEnumerator AnimateHistoryText()
    {
        doingAnimation = true;
        historyTextContent = historyText.text;
        historyText.text = "";

        char[] historyLetters = historyTextContent.ToCharArray();
        IEnumerator finish = FinishDialog();
        StartCoroutine(finish);
        for (int i = 0; i < historyLetters.Length; i++)
        {
            historyText.text += historyLetters[i];
            yield return new WaitForSeconds(0.03f);
        }
        StopCoroutine(finish);
        yield return new WaitUntil(() => 
        (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return)));
        doingAnimation = false;
    }
}
