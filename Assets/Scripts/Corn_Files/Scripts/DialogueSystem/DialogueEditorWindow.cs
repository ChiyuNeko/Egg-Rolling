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
        GetWindow<DialogueEditorWindow>("��ܽs�边");
    }

    private void OnGUI()
    {
        GUILayout.Label("��ܽs�边", EditorStyles.boldLabel);

        dialogueData = (DialogueData)EditorGUILayout.ObjectField("Dialogue Data", dialogueData, typeof(DialogueData), false);

        if (dialogueData == null)
        {
            EditorGUILayout.HelpBox("�п�ܩγЫؤ@��DialogueData", MessageType.Info);
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
            foldouts[i] = EditorGUILayout.Foldout(foldouts[i], $"��ܦ� {i + 1}");

            if (foldouts[i])
            {
                EditorGUILayout.BeginVertical("box");
                line.speaker = EditorGUILayout.TextField("���ܪ�", line.speaker);
                line.image = (Sprite)EditorGUILayout.ObjectField("�Ϥ�", line.image, typeof(Sprite), false);
                line.voice = (AudioClip)EditorGUILayout.ObjectField("�y��", line.voice, typeof(AudioClip), false);
                line.text = EditorGUILayout.TextArea(line.text, GUILayout.MinHeight(60));

                line.hasOptions = EditorGUILayout.Toggle("�O�_���ﶵ", line.hasOptions);
                if (line.hasOptions)
                {
                    if (line.options == null)
                        line.options = new List<DialogueOption>();

                    for (int j = 0; j < line.options.Count; j++)
                    {
                        EditorGUILayout.BeginHorizontal();
                        line.options[j].optionText = EditorGUILayout.TextField("�ﶵ�奻", line.options[j].optionText);
                        line.options[j].nextBranch = (DialogueData)EditorGUILayout.ObjectField("�U�@����", line.options[j].nextBranch, typeof(DialogueData), false);

                        if (GUILayout.Button("�R��", GUILayout.Width(60)))
                        {
                            line.options.RemoveAt(j);
                        }
                        EditorGUILayout.EndHorizontal();
                    }

                    if (GUILayout.Button("�s�W�ﶵ"))
                    {
                        line.options.Add(new DialogueOption());
                    }
                }

                if (GUILayout.Button("�R���o�@��"))
                {
                    dialogueData.lines.RemoveAt(i);
                    break;
                }

                EditorGUILayout.EndVertical();
            }
        }

        if (GUILayout.Button("�s�W��ܦ�"))
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
