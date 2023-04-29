using System;

public class GameUIController : IDisposable
{
    readonly GameUIView view;
    readonly StackSelectorController stackSelectorController;
    
    public GameUIController (GameUIView view, StackSelectorController stackSelectorController)
    {
        this.view = view;
        this.stackSelectorController = stackSelectorController;
    }

    public void Initialize ()
    {
        stackSelectorController.Initialize();
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