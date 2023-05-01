using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BlockDetailsView : MonoBehaviour
{
    const float OPEN_DURATION = .25f;
    
    [SerializeField] Button closeButton;
    [SerializeField] TextMeshProUGUI grade;
    [SerializeField] TextMeshProUGUI domain;
    [SerializeField] TextMeshProUGUI cluster;
    [SerializeField] TextMeshProUGUI standardId;
    [SerializeField] TextMeshProUGUI description;

    void Start ()
    {
        Close();
        closeButton.onClick.AddListener(Close);
    }

    public void Setup (
        string grade,
        string domain,
        string cluster,
        string standardId,
        string description
    )
    {
        this.grade.text = grade;
        this.domain.text = domain;
        this.cluster.text = cluster;
        this.standardId.text = standardId;
        this.description.text = description;
    }

    public void Open ()
    {
        gameObject.SetActive(true);
        transform.localScale = Vector3.zero;
        transform.DOScale(Vector3.one, OPEN_DURATION).SetEase(Ease.OutCubic);
    }

    public void Close ()
    {
        transform.localScale = Vector3.one;
        transform.DOScale(Vector3.zero, OPEN_DURATION).SetEase(Ease.OutCubic);
    }
}