using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Essentials.Internal.PlayerPrefsEditor
{
    public class PlayerPrefsAddEditor : EditorWindow
    {
        private Label titleLabel;
        private TextField keyField;
        private TextField valueField;
        private DropdownField typeField;
        private Button addButton;

        private PlayerPrefsEditorEditor editor;

        public static void ShowWindow(PlayerPrefsEditorEditor editor)
        {
            // Create a modal window
            PlayerPrefsAddEditor window = GetWindow<PlayerPrefsAddEditor>(true, PlayerPrefsEditorEditor.isEditorPrefs ? "Add EditorPref" : "Add PlayerPref", true);
            window.minSize = new Vector2(350, 150);
            window.maxSize = new Vector2(350, 150);

            window.editor = editor;
        }

        public void CreateGUI()
        {
            VisualTreeAsset visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Packages/com.notrewd.essentials/EssentialsCore/Editor/PlayerPrefsEditor/PlayerPrefsAddEditorDocument.uxml");
            visualTree.CloneTree(rootVisualElement);

            titleLabel = rootVisualElement.Q<Label>("TitleLabel");
            keyField = rootVisualElement.Q<TextField>("KeyField");
            valueField = rootVisualElement.Q<TextField>("ValueField");
            typeField = rootVisualElement.Q<DropdownField>("TypeField");
            addButton = rootVisualElement.Q<Button>("AddButton");

            titleLabel.text = PlayerPrefsEditorEditor.isEditorPrefs ? "Add New EditorPref" : "Add New PlayerPref";

            keyField.RegisterValueChangedCallback((_) => CheckFields());

            valueField.RegisterValueChangedCallback((_) => CheckFields());

            typeField.choices = new List<string>() { "String", "Int", "Float" };
            typeField.value = "String";
            typeField.RegisterValueChangedCallback((_) => CheckFields());

            addButton.text = PlayerPrefsEditorEditor.isEditorPrefs ? "Add EditorPref" : "Add PlayerPref";
            addButton.clicked += Add;
        }

        private void Add()
        {
            if (string.IsNullOrEmpty(keyField.value))
            {
                EditorUtility.DisplayDialog("Invalid Key Name", "Key cannot be empty", "OK");
                return;
            }

            if (PlayerPrefs.HasKey(keyField.value))
            {
                EditorUtility.DisplayDialog("Invalid Key Name", "Key already exists", "OK");
                return;
            }

            switch (typeField.value)
            {
                case "String":
                    editor.AddPlayerPref(keyField.value, valueField.value);
                    break;
                case "Int":
                    if (!int.TryParse(valueField.value, out int intValue))
                    {
                        EditorUtility.DisplayDialog("Invalid Value", "Value is not a valid integer", "OK");
                        return;
                    }
                    editor.AddPlayerPref(keyField.value, int.Parse(valueField.value));
                    break;
                case "Float":
                    if (!float.TryParse(valueField.value, out float floatValue))
                    {
                        EditorUtility.DisplayDialog("Invalid Value", "Value is not a valid float", "OK");
                        return;
                    }
                    editor.AddPlayerPref(keyField.value, float.Parse(valueField.value));
                    break;
            }

            Close();
        }

        private void CheckFields()
        {
            addButton.SetEnabled(false);

            if (string.IsNullOrEmpty(keyField.value)) return;
            else if (typeField.value == "Int" && !int.TryParse(valueField.value, out int intValue)) return;
            else if (typeField.value == "Float" && !float.TryParse(valueField.value, out float floatValue)) return;

            addButton.SetEnabled(true);
        }
    }
}