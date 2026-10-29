using UnityEngine;

public class Cities : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private bool hasBeenCollected = false;

    public void Collect(UICounter scoreCounter)
    {
        if (hasBeenCollected)
            return;

        hasBeenCollected = true;

        if (scoreCounter != null)
        {
            scoreCounter.AddCount(1);
            Debug.Log("City collected!");
        }
        else
        {
            Debug.LogError("Score Counter is not assigned!");
        }
    }
}