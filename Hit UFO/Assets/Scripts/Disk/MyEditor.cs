using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(DiskData))]


public class MyEditor : Editor
{
    SerializedProperty speedProp;
    SerializedProperty colorProp;

    void OnEnable()
    {
        speedProp = serializedObject.FindProperty("speed");
        colorProp = serializedObject.FindProperty("color");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.Slider(speedProp, 1, 20, new GUIContent("speed"));
        ProgressBar(speedProp.floatValue / 20f, "speed");

        EditorGUILayout.PropertyField(colorProp);

        serializedObject.ApplyModifiedProperties();
    }

    void ProgressBar(float value, string label)
    {
        // Get a rect for the progress bar using the same margins as a textfield:
        Rect rect = GUILayoutUtility.GetRect(18, 18, "TextField");
        EditorGUI.ProgressBar(rect, value, label);
        EditorGUILayout.Space();
    }
}