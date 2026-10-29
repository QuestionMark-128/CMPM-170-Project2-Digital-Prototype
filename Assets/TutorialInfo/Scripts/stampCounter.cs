using UnityEngine;
using TMPro;

public class stampCounter : MonoBehaviour
{
    public TMP_Text stampText;

    int stamps = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateStampText();
    }

    public void AddStamp()
    {
        stamps++;
        UpdateStampText();
    }

    void UpdateStampText()
    {
        stampText.text = "Stamps: " +
            stamps.ToString();
    }
}
