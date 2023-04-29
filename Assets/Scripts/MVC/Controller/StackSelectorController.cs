using System;
using System.Linq;
using UnityEngine;

public class StackSelectorController : IDisposable
{
    public event Action<string> OnStackSelected;
    
    readonly StackSelectorView view;
    readonly StackLoaderModel stackLoaderModel;

    public StackSelectorController (
        StackSelectorView view,
        StackLoaderModel stackLoaderModel
    )
    {
        this.view = view;
        this.stackLoaderModel = stackLoaderModel;
    }

    public void Initialize ()
    {
        AddListeners();
        CreateButtons();
    }

    void AddListeners ()
    {
        view.OnStackSelected += HandleStackSelected;
    }

    void RemoveListeners ()
    {
        view.OnStackSelected -= HandleStackSelected;
    }

    void HandleStackCreated (string key, Transform focalPoint)
    {
        
    }

    void HandleStackSelected (string stack) => OnStackSelected?.Invoke(stack);

    void CreateButtons () => view.CreateButtons(stackLoaderModel.Stacks.Keys.ToList());

    public void Dispose ()
    {
        RemoveListeners();
    }
}