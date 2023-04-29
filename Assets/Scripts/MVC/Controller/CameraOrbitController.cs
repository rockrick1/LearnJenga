using System;
using UnityEngine;

public class CameraOrbitController : IDisposable
{
    readonly CameraOrbitView view;
    readonly StackSelectorController stackSelectorController;
    
    public CameraOrbitController (CameraOrbitView view, StackSelectorController stackSelectorController)
    {
        this.view = view;
        this.stackSelectorController = stackSelectorController;
    }

    public void Initialize ()
    {
        AddListeners();
    }

    void AddListeners ()
    {
        stackSelectorController.OnStackSelected += HandleStackSelected;
    }

    void RemoveListeners ()
    {
        stackSelectorController.OnStackSelected -= HandleStackSelected;
    }

    void HandleStackSelected (Transform stack) => view.SetFocalPoint(stack);

    public void Dispose ()
    {
        // model.Dispose();
        RemoveListeners();
    }
}