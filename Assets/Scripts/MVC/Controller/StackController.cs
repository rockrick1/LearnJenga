using System;
using System.Collections.Generic;

public class StackController : IDisposable
{
    readonly StackView view;
    
    public StackController (StackView view)
    {
        this.view = view;
    }

    public void Initialize ()
    {
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
        RemoveListeners();
    }

    public void AddBlock (BlockData block)
    {
        view.AddBlock(block);
    }
}