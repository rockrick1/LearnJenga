using UnityEngine;

public class GameUIView : MonoBehaviour
{
    [SerializeField] StackSelectorView stackSelectorView;
    public StackSelectorView StackSelectorView => stackSelectorView;
}