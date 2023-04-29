using System;
using UnityEngine;

public class StackController : IDisposable
{
    public event Action<BlockData> OnBlockClick;

    public Transform FocalPoint => view.FocalPoint;
    
    readonly StackView view;

    public string Key { get; private set; }
    
    public StackController (StackView view)
    {
        this.view = view;
    }

    public void Initialize ()
    {
        AddListeners();
    }

    public void AddBlock (BlockData block) => view.AddBlock(block);

    public void SetGradeText (string key)
    {
        Key = key;
        view.SetGradeText(key);
    }

    public void RemoveGlasses ()
    {
        try
        {
            view.RemoveGlasses();
        }
        catch
        {
        }
    }

    void AddListeners ()
    {
        view.OnBlockClick += HandleBlockClick;
    }

    void RemoveListeners ()
    {
        view.OnBlockClick -= HandleBlockClick;
    }

    void HandleBlockClick (BlockData data)
    {
        OnBlockClick?.Invoke(data);
    }

    public void Dispose ()
    {
        RemoveListeners();
    }
}