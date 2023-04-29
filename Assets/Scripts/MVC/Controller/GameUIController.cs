using System;

public class GameUIController : IDisposable
{
    readonly GameUIView view;
    readonly StackSelectorController stackSelectorController;
    readonly StackTesterController stackTesterController;
    readonly BlockDetailsController blockDetailsController;

    public GameUIController (
        GameUIView view,
        StackSelectorController stackSelectorController,
        StackTesterController stackTesterController,
        BlockDetailsController blockDetailsController
    )
    {
        this.view = view;
        this.stackSelectorController = stackSelectorController;
        this.stackTesterController = stackTesterController;
        this.blockDetailsController = blockDetailsController;
    }

    public void Initialize ()
    {
        stackSelectorController.Initialize();
        stackTesterController.Initialize();
        blockDetailsController.Initialize();
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
        stackTesterController.Dispose();
        blockDetailsController.Dispose();
        RemoveListeners();
    }
}