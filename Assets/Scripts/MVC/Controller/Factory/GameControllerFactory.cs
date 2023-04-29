public static class GameControllerFactory
{
    public static GameController Create (GameView view, GameModel model)
    {
        StackSelectorController stackSelectorController = new(
            view.StackSelectorView,
            model.StackLoaderModel
        );
        StackTesterController stackTesterController = new(
            view.StackTesterView,
            stackSelectorController
        );
        GameUIController gameUIController = new(
            view.GameUIView,
            stackSelectorController,
            stackTesterController
        );
        WorldObjectsController worldObjectsController = new(
            view.WorldObjectsView,
            model.StackLoaderModel,
            stackTesterController
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