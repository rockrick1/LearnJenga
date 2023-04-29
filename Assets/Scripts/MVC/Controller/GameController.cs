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
        WorldObjectsController.Initialize();
        CameraOrbitController.Initialize();
    }

    void AddListeners ()
    {
        // model.OnAudioStartTimeReached += HandleAudioStartTimeReached;
        // model.OnNoteHit += HandleNoteHit;
        // model.OnLongNoteHit += HandleNoteHit;
        // model.OnLongNoteReleased += HandleNoteHit;
    }

    void RemoveListeners ()
    {
        // model.OnAudioStartTimeReached -= HandleAudioStartTimeReached;
        // model.OnNoteHit -= HandleNoteHit;
        // model.OnLongNoteHit -= HandleNoteHit;
        // model.OnLongNoteReleased -= HandleNoteHit;
    }
    
    public void Dispose ()
    {
        RemoveListeners();
        GameUIController.Dispose();
        WorldObjectsController.Dispose();
        CameraOrbitController.Dispose();
    }
}