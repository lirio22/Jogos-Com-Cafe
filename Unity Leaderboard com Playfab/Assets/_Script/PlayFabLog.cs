using UnityEngine;
using TMPro;

public class PlayFabLog : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI logText;

    private void Start()
    {
        logText.text = "";
    }

    public void InsertLogText(string _newText)
    {
        logText.text += string.Format("\n{0}", _newText);
    }
}