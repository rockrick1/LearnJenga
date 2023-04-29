using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StackSelectButtonView : MonoBehaviour
{
    [SerializeField] Button button;
    [SerializeField] TextMeshProUGUI buttonText;
    
    public Button Button => button;
    
    public void SetText (string text) => buttonText.text = text;
}