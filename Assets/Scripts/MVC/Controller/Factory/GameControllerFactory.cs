public static class GameControllerFactory
{
    public static GameController Create (GameView view, GameModel model)
    {
        StackSelectorController stackSelectorController = new(
            view.StackSelectorView,
            model.StackLoaderModel
        );
        GameUIController gameUIController = new(
            view.GameUIView,
            stackSelectorController
        );
        WorldObjectsController worldObjectsController = new(
            view.WorldObjectsView,
            model.StackLoaderModel
        );
        CameraOrbitController cameraOrbitController = new(
            view.CameraOrbitView,
            stackSelectorController,
            worldObjectsController
        );

        return new GameController(
            view,
            model,
            gameUIController,
            worldObjectsController,
            cameraOrbitController
        );
    }
}