public static class GameModelFactory
{
    public static GameModel Create ()
    {
        StackLoaderModel stackLoaderModel = new();
        return new GameModel(stackLoaderModel);
    }
}