public class GameController
{
    public GameUIController GameUIController { get; }
    public WorldObjectsController WorldObjectsController { get; }
    public CameraOrbitController CameraOrbitController { get; }
    
    readonly GameView view;
    readonly GameModel model;

    public GameController (
        GameView view,
        GameModel model,
        GameUIController gameUIController,
        WorldObjectsController worldObjectsController,
        CameraOrbitController cameraOrbitController
    )
    {
        this.view = view;
        this.model = model;
        GameUIController = gameUIController;
        WorldObjectsController = worldObjectsController;
        CameraOrbitController = cameraOrbitController;
    }

    public void Initialize ()
    {
        AddListeners();
        GameUIController.Initialize();
        CameraOrbitController.Initialize();
        WorldObjectsController.Initialize();
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
        GameUIController.Dispose();
        WorldObjectsController.Dispose();
        CameraOrbitController.Dispose();
    }
}