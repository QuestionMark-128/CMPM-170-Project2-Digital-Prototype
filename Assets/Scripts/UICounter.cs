using UnityEngine;
using TMPro;

public class UICounter : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [Header("UI Refrence")]
    [SerializeField] private TMP_Text counterText;

    [Header("Settings")]
    [SerializeField] private string prefix = "Score: ";

    private int currentCount = 0;
    void Start()
    {
        UpdateUI();
    }

    public void AddCount(int amount)
    {
        currentCount += amount;
        UpdateUI();
    }

    public void ResetCount()
    {
        currentCount = 0;
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (counterText != null)
        {
            counterText.text = prefix + currentCount.ToString();
        }
    }
}
