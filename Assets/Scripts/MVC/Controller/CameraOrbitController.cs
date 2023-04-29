using System;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbitController : IDisposable
{
    readonly CameraOrbitView view;
    readonly StackSelectorController stackSelectorController;
    readonly WorldObjectsController worldObjectsController;

    readonly Dictionary<string, Transform> focalPoints = new();

    bool firstStackFocused = false;

    public CameraOrbitController (
        CameraOrbitView view,
        StackSelectorController stackSelectorController,
        WorldObjectsController worldObjectsController
    )
    {
        this.view = view;
        this.stackSelectorController = stackSelectorController;
        this.worldObjectsController = worldObjectsController;
    }

    public void Initialize ()
    {
        AddListeners();
    }

    void AddListeners ()
    {
        worldObjectsController.OnStackCreated += HandleStackCreated;
        stackSelectorController.OnStackSelected += HandleStackSelected;
    }

    void RemoveListeners ()
    {
        worldObjectsController.OnStackCreated -= HandleStackCreated;
        stackSelectorController.OnStackSelected -= HandleStackSelected;
    }

    void HandleStackCreated (string key, Transform focalPoint)
    {
        focalPoints[key] = focalPoint;
        if (firstStackFocused)
            return;
        view.SetFocalPoint(focalPoint);
        firstStackFocused = true;
    }

    void HandleStackSelected (string stack)
    {
        view.SetFocalPoint(focalPoints[stack]);
    }

    public void Dispose ()
    {
        RemoveListeners();
    }
}