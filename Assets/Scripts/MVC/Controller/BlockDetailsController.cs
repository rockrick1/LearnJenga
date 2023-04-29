using System;

public class BlockDetailsController : IDisposable
{
    readonly BlockDetailsView view;
    readonly WorldObjectsController worldObjectsController;
    
    public BlockDetailsController (BlockDetailsView view, WorldObjectsController worldObjectsController)
    {
        this.view = view;
        this.worldObjectsController = worldObjectsController;
    }

    public void Initialize ()
    {
        AddListeners();
    }

    void AddListeners ()
    {
        worldObjectsController.OnBlockClick += HandleBlockClick;
    }

    void RemoveListeners ()
    {
        worldObjectsController.OnBlockClick -= HandleBlockClick;
    }

    void HandleBlockClick (BlockData data)
    {
        view.Setup(data.Grade, data.Domain, data.Cluster, data.Standardid, data.Standarddescription);
        view.Open();
    }

    public void Dispose ()
    {
        RemoveListeners();
    }
}