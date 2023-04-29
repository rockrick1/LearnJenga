using UnityEngine;

public class GameUIView : MonoBehaviour
{
    [SerializeField] StackSelectorView stackSelectorView;
    [SerializeField] StackTesterView stackTesterView;
    [SerializeField] BlockDetailsView blockDetailsView;
    
    public StackSelectorView StackSelectorView => stackSelectorView;
    public StackTesterView StackTesterView => stackTesterView;
    public BlockDetailsView BlockDetailsView => blockDetailsView;
}