using System;
using System.Linq;
using UnityEngine;

public class StackSelectorController : IDisposable
{
    public event Action<Transform> OnStackSelected;
    
    readonly StackSelectorView view;
    readonly StackLoaderModel stackLoaderModel;
    
    public StackSelectorController (StackSelectorView view, StackLoaderModel stackLoaderModel)
    {
        this.view = view;
        this.stackLoaderModel = stackLoaderModel;
    }

    public void Initialize ()
    {
        AddListeners();
        CreateButtons();
    }

    void CreateButtons () => view.CreateButtons(stackLoaderModel.Stacks.Keys.ToList());

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