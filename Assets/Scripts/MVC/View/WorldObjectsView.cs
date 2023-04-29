using UnityEngine;

public class WorldObjectsView : MonoBehaviour
{
    const int STACKS_DISTANCE = 15;
    
    [SerializeField] StackView stackPrefab;
    [SerializeField] Transform stacksParent;

    float stackPosition = 0;
    
    public StackView CreateStack (string key)
    {
        StackView instance = Instantiate(stackPrefab, stacksParent);
        Vector3 pos = instance.transform.position;
        pos.x += stackPosition;
        instance.transform.position = pos;
        stackPosition += STACKS_DISTANCE;
        return instance;
    }
}