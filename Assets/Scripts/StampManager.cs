using UnityEngine;
using TMPro;

public class StampManager : MonoBehaviour
{
    public int stamps = 0;
    public TextMeshProUGUI stampText;

    void Start()
    {
        UpdateUI();
    }

    public void TryAwardStamp(Location location)
    {
        if (!location.isCity)
        {
            return;
        }

        if (location.hasGivenStamp)
        {
            return;
        }

        location.hasGivenStamp = true;
        stamps++;
        UpdateUI();

        Debug.Log("You Got A Stamp! Total: " + stamps);
    }

    void UpdateUI()
    {
        stampText.text = "Stamps: " + stamps;
    }
}
