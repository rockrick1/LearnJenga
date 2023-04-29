using System;
using UnityEngine;
using UnityEngine.UI;

public class StackTesterView : MonoBehaviour
{
    public event Action OnClick;

    [SerializeField] Button button;

    void Start ()
    {
        button.onClick.AddListener(() => OnClick?.Invoke());
    }
}