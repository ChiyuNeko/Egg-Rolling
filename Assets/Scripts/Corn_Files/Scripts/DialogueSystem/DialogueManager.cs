using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DialogueManager : MonoBehaviour
{
    public DialogueData dialogueData;
    public Image speakerImage;
    public Text speakerNameText;
    public Text dialogueText;
    public AudioSource audioSource;
    public GameObject optionsPanel;    // 選項面板
    public Button optionButtonPrefab;  // 選項按鈕的預製件

    private int currentLineIndex = 0;

    void Start()
    {
        DisplayLine();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && optionsPanel.activeSelf == false)
        {
            ShowNextLine();
        }
    }

    private void DisplayLine()
    {
        if (currentLineIndex >= dialogueData.lines.Count)
        {
            Debug.Log("對話結束");
            gameObject.SetActive(false);
            return;
        }

        var line = dialogueData.lines[currentLineIndex];

        // 更新UI
        speakerNameText.text = string.IsNullOrEmpty(line.speaker) ? "" : line.speaker;
        speakerImage.sprite = line.image;
        dialogueText.text = line.text;
        line.unityEvent?.Invoke();

        if (line.voice != null)
        {
            audioSource.Stop();
            audioSource.clip = line.voice;
            audioSource.Play();
        }

        // 顯示選項
        if (line.hasOptions)
        {
            ShowOptions(line.options);
        }
        else
        {
            optionsPanel.SetActive(false);
        }
    }

    private void ShowOptions(List<DialogueOption> options)
    {
        optionsPanel.SetActive(true);

        // 清除舊的按鈕
        foreach (Transform child in optionsPanel.transform)
        {
            Destroy(child.gameObject);
        }

        // 創建選項按鈕
        foreach (var option in options)
        {
            var button = Instantiate(optionButtonPrefab, optionsPanel.transform);
            button.GetComponentInChildren<Text>().text = option.optionText;

            button.onClick.AddListener(() =>
            {
                dialogueData = option.nextBranch; // 切換到新分支
                currentLineIndex = 0;
                DisplayLine();
            });
        }
    }

    private void ShowNextLine()
    {
        currentLineIndex++;
        DisplayLine();
    }
}
