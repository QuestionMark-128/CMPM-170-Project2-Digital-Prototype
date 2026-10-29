using UnityEngine;

public class CityDetector : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private UICounter scoreCounter;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Detected object: " + other.name);

        Cities city = other.GetComponent<Cities>();

        if (city != null)
        {
            city.Collect(scoreCounter);
        }
    }
}