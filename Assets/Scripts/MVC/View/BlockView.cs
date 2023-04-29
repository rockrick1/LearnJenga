using System;
using TMPro;
using UnityEngine;

public class BlockView : MonoBehaviour
{
    public event Action<BlockData> OnClick;
    
    [SerializeField] TextMeshPro text1;
    [SerializeField] TextMeshPro text2;
    
    [SerializeField] Rigidbody rigidbody;
    [SerializeField] MeshRenderer mesh;
    [SerializeField] Transform block;
    
    [SerializeField] Material glass;
    [SerializeField] Material wood;
    [SerializeField] Material stone;
    
    [SerializeField] Material glassHighlighted;
    [SerializeField] Material woodHighlighted;
    [SerializeField] Material stoneHighlighted;

    public Mastery Mastery { get; private set; }
    public float Scale => block.localScale.y;

    BlockData data;

    void Start ()
    {
        SetPhysicsActive(false);
    }

    public void Setup (BlockData data)
    {
        this.data = data;
        SetMaterial(data.Mastery);
    }

    public void SetPhysicsActive (bool active)
    {
        rigidbody.isKinematic = !active;
    }

    void SetTexts (string text)
    {
        text1.text = text;
        text2.text = text;
    }

    void SetMaterial (Mastery blockMastery, bool highlighted = false)
    {
        Mastery = blockMastery;
        switch (blockMastery)
        {
            case Mastery.Glass:
                SetTexts("");
                mesh.material = highlighted ? glassHighlighted : glass;
                break;
            case Mastery.Wood:
                SetTexts("LEARNED");
                mesh.material = highlighted ? woodHighlighted : wood;
                break;
            case Mastery.Stone:
                SetTexts("MASTERED");
                mesh.material = highlighted ? stoneHighlighted : stone;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(blockMastery), blockMastery, null);
        }
    }

    public void Destroy ()
    {
        Destroy(gameObject);
    }

    void Update ()
    {
        SetMaterial(data.Mastery);
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.rigidbody == rigidbody)
            {
                SetMaterial(data.Mastery, true);
                if (Input.GetMouseButtonDown(1))
                {
                    OnClick?.Invoke(data);

                }
            }
        }
    }
}