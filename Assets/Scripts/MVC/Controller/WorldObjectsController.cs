using System;
using System.Collections.Generic;
using UnityEngine;

public class WorldObjectsController : IDisposable
{
    public event Action<string, Transform> OnStackCreated;
    
    readonly WorldObjectsView view;
    readonly StackLoaderModel stackLoaderModel;
    readonly StackTesterController stackTesterController;

    readonly List<StackController> stackControllers = new();

    public WorldObjectsController (
        WorldObjectsView view,
        StackLoaderModel stackLoaderModel,
        StackTesterController stackTesterController
    )
    {
        this.view = view;
        this.stackLoaderModel = stackLoaderModel;
        this.stackTesterController = stackTesterController;
    }

    public void Initialize ()
    {
        AddListeners();
        CreateStacks();
    }

    void AddListeners ()
    {
        stackTesterController.OnTestStackClicked += HandleTestStack;
    }

    void RemoveListeners ()
    {
        stackTesterController.OnTestStackClicked -= HandleTestStack;
    }

    void HandleTestStack (string stack)
    {
        RemoveGlassesFromStack(stack);
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

            stackController.SetGradeText(key);

            OnStackCreated?.Invoke(key, stackController.FocalPoint);
        }
    }

    void RemoveGlassesFromStack (string stack)
    {
        foreach (StackController stackController in stackControllers)
        {
            if (stackController.Key == stack)
            {
                stackController.RemoveGlasses();
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