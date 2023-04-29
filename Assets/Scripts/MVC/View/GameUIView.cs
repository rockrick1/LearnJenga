using UnityEngine;

public class GameUIView : MonoBehaviour
{
    [SerializeField] StackSelectorView stackSelectorView;
    [SerializeField] StackTesterView stackTesterView;
    
    public StackSelectorView StackSelectorView => stackSelectorView;
    public StackTesterView StackTesterView => stackTesterView;
}