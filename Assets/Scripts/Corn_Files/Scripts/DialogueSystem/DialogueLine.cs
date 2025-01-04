using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[System.Serializable]
public class DialogueLine
{
    public string speaker;       // 說話者名稱（可選）
    public Sprite image;         // 圖片（可選）
    public AudioClip voice;      // 語音（可選）
    [TextArea(3, 5)]
    public string text;          // 對話文本

    public bool hasOptions;      // 是否有選項
    public List<DialogueOption> options; // 選項列表
    public UnityEvent unityEvent;
}

