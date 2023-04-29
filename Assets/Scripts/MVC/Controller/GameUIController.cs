using System;

public class GameUIController : IDisposable
{
    readonly GameUIView view;
    readonly StackSelectorController stackSelectorController;
    readonly StackTesterController stackTesterController;

    public GameUIController (
        GameUIView view,
        StackSelectorController stackSelectorController,
        StackTesterController stackTesterController
    )
    {
        this.view = view;
        this.stackSelectorController = stackSelectorController;
        this.stackTesterController = stackTesterController;
    }

    public void Initialize ()
    {
        stackSelectorController.Initialize();
        stackTesterController.Initialize();
        AddListeners();
    }

    void AddListeners ()
    {
    }

    void RemoveListeners ()
    {
    }

    public void Dispose ()
    {
        stackSelectorController.Dispose();
        RemoveListeners();
    }
}