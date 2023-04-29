using System;

public class StackTesterController : IDisposable
{
    public event Action<string> OnTestStackClicked;
    
    readonly StackTesterView view;
    readonly StackSelectorController stackSelectorController;
    
    public StackTesterController (StackTesterView view, StackSelectorController stackSelectorController)
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
        view.OnClick += HandleClick;
    }

    void RemoveListeners ()
    {
        view.OnClick -= HandleClick;
    }

    void HandleClick ()
    {
        OnTestStackClicked?.Invoke(stackSelectorController.CurrentStack);
    }

    public void Dispose ()
    {
        RemoveListeners();
    }
}