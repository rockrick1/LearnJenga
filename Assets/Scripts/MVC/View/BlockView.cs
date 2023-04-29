using System;
using UnityEngine;

public class BlockView : MonoBehaviour
{
    [SerializeField] MeshRenderer mesh;
    [SerializeField] Material glass;
    [SerializeField] Material wood;
    [SerializeField] Material stone;
    
    public void SetMaterial (Mastery blockMastery)
    {
        switch (blockMastery)
        {
            case Mastery.Glass:
                mesh.material = glass;
                break;
            case Mastery.Wood:
                mesh.material = wood;
                break;
            case Mastery.Stone:
                mesh.material = stone;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(blockMastery), blockMastery, null);
        }
    }
}