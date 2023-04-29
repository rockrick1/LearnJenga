public class GameModel
{
    public StackLoaderModel StackLoaderModel { get; }
    // public ISongModel SongModel { get; }
    // public IScoreModel ScoreModel { get; }
    // public IGameInputManager InputManager { get; }
    // public IAudioManager AudioManager { get; }

    public GameModel (StackLoaderModel stackLoaderModel)
    {
        StackLoaderModel = stackLoaderModel;
        // ScoreModel = scoreModel;
        // InputManager = inputManager;
        // AudioManager = audioManager;
    }

    public void Initialize ()
    {
        StackLoaderModel.Initialize();
    }

    public void Dispose ()
    {
    }
}