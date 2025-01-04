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
    public GameObject optionsPanel;    // �ﶵ���O
    public Button optionButtonPrefab;  // �ﶵ���s���w�s��

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
            Debug.Log("��ܵ���");
            gameObject.SetActive(false);
            return;
        }

        var line = dialogueData.lines[currentLineIndex];

        // ��sUI
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

        // ��ܿﶵ
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

        // �M���ª����s
        foreach (Transform child in optionsPanel.transform)
        {
            Destroy(child.gameObject);
        }

        // �Ыؿﶵ���s
        foreach (var option in options)
        {
            var button = Instantiate(optionButtonPrefab, optionsPanel.transform);
            button.GetComponentInChildren<Text>().text = option.optionText;

            button.onClick.AddListener(() =>
            {
                dialogueData = option.nextBranch; // ������s����
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
