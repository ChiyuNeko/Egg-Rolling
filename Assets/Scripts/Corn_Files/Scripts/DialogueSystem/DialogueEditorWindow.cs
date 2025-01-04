using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;

public class DialogueEditorWindow : EditorWindow
{
    private DialogueData dialogueData;
    private Vector2 scrollPosition;
    private bool[] foldouts;

    [MenuItem("Tools/Dialogue Editor")]
    public static void ShowWindow()
    {
        GetWindow<DialogueEditorWindow>("對話編輯器");
    }

    private void OnGUI()
    {
        GUILayout.Label("對話編輯器", EditorStyles.boldLabel);

        dialogueData = (DialogueData)EditorGUILayout.ObjectField("Dialogue Data", dialogueData, typeof(DialogueData), false);

        if (dialogueData == null)
        {
            EditorGUILayout.HelpBox("請選擇或創建一個DialogueData", MessageType.Info);
            return;
        }

        if (foldouts == null || foldouts.Length != dialogueData.lines.Count)
        {
            foldouts = new bool[dialogueData.lines.Count];
        }

        scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition);

        for (int i = 0; i < dialogueData.lines.Count; i++)
        {
            var line = dialogueData.lines[i];
            foldouts[i] = EditorGUILayout.Foldout(foldouts[i], $"對話行 {i + 1}");

            if (foldouts[i])
            {
                EditorGUILayout.BeginVertical("box");
                line.speaker = EditorGUILayout.TextField("說話者", line.speaker);
                line.image = (Sprite)EditorGUILayout.ObjectField("圖片", line.image, typeof(Sprite), false);
                line.voice = (AudioClip)EditorGUILayout.ObjectField("語音", line.voice, typeof(AudioClip), false);
                line.text = EditorGUILayout.TextArea(line.text, GUILayout.MinHeight(60));

                line.hasOptions = EditorGUILayout.Toggle("是否有選項", line.hasOptions);
                if (line.hasOptions)
                {
                    if (line.options == null)
                        line.options = new List<DialogueOption>();

                    for (int j = 0; j < line.options.Count; j++)
                    {
                        EditorGUILayout.BeginHorizontal();
                        line.options[j].optionText = EditorGUILayout.TextField("選項文本", line.options[j].optionText);
                        line.options[j].nextBranch = (DialogueData)EditorGUILayout.ObjectField("下一分支", line.options[j].nextBranch, typeof(DialogueData), false);

                        if (GUILayout.Button("刪除", GUILayout.Width(60)))
                        {
                            line.options.RemoveAt(j);
                        }
                        EditorGUILayout.EndHorizontal();
                    }

                    if (GUILayout.Button("新增選項"))
                    {
                        line.options.Add(new DialogueOption());
                    }
                }

                if (GUILayout.Button("刪除這一行"))
                {
                    dialogueData.lines.RemoveAt(i);
                    break;
                }

                EditorGUILayout.EndVertical();
            }
        }

        if (GUILayout.Button("新增對話行"))
        {
            dialogueData.lines.Add(new DialogueLine());
        }

        EditorGUILayout.EndScrollView();

        if (GUI.changed)
        {
            EditorUtility.SetDirty(dialogueData);
        }
    }
}
