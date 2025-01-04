using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[System.Serializable]
public class DialogueLine
{
    public string speaker;       // ���ܪ̦W�١]�i��^
    public Sprite image;         // �Ϥ��]�i��^
    public AudioClip voice;      // �y���]�i��^
    [TextArea(3, 5)]
    public string text;          // ��ܤ奻

    public bool hasOptions;      // �O�_���ﶵ
    public List<DialogueOption> options; // �ﶵ�C��
    public UnityEvent unityEvent;
}

