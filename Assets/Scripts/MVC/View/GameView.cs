using UnityEngine;

public class GameView : MonoBehaviour
{
    [SerializeField] GameUIView gameUIView;
    [SerializeField] CameraOrbitView cameraOrbitView;
    [SerializeField] WorldObjectsView worldObjectsView;

    public GameUIView GameUIView => gameUIView;
    public CameraOrbitView CameraOrbitView => cameraOrbitView;
    public WorldObjectsView WorldObjectsView => worldObjectsView;
    public StackSelectorView StackSelectorView => gameUIView.StackSelectorView;
    public StackTesterView StackTesterView => gameUIView.StackTesterView;
}