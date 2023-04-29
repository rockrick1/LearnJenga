using System;
using UnityEngine;

public class StackController : IDisposable
{
    public Transform FocalPoint => view.FocalPoint;
    
    readonly StackView view;
    
    public StackController (StackView view)
    {
        this.view = view;
    }

    public void Initialize ()
    {
        AddListeners();
    }

    public void AddBlock (BlockData block) => view.AddBlock(block);

    public void SetGradeText (string key) => view.SetGradeText(key);

    void AddListeners ()
    {
    }

    void RemoveListeners ()
    {
    }

    public void Dispose ()
    {
        RemoveListeners();
    }
}