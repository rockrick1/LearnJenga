using System;
using System.Collections.Generic;
using UnityEngine;

public class StackSelectorView : MonoBehaviour
{
    public event Action<string> OnStackSelected;
    
    [SerializeField] Transform buttonsParent;
    [SerializeField] StackSelectButtonView buttonPrefab;

    public void CreateButtons (List<string> stackKeys)
    {
        foreach (string key in stackKeys)
        {
            StackSelectButtonView instance = Instantiate(buttonPrefab, buttonsParent.transform);
            instance.Button.onClick.AddListener(() => OnStackSelected?.Invoke(key));
            instance.SetText(key);
        }
    }
}