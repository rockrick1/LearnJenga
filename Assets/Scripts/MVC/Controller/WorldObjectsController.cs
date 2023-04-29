using System;
using System.Collections.Generic;

public class WorldObjectsController : IDisposable
{
    readonly WorldObjectsView view;
    readonly StackLoaderModel stackLoaderModel;

    readonly List<StackController> stackControllers = new();
    
    public WorldObjectsController (WorldObjectsView view, StackLoaderModel stackLoaderModel)
    {
        this.view = view;
        this.stackLoaderModel = stackLoaderModel;
    }

    public void Initialize ()
    {
        AddListeners();
        CreateStacks();
    }

    void AddListeners ()
    {
    }

    void RemoveListeners ()
    {
    }

    void CreateStacks ()
    {
        foreach (string key in stackLoaderModel.Stacks.Keys)
        {
            StackController stackController = new StackController(view.CreateStack(key));
            stackControllers.Add(stackController);
            foreach (BlockData value in stackLoaderModel.Stacks[key])
            {
                stackController.AddBlock(value);
            }
        }
    }

    public void Dispose ()
    {
        RemoveListeners();
        foreach (StackController stackController in stackControllers)
            stackController.Dispose();
    }
}