using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Linq;

public class PlayerMovement : MonoBehaviour
{
    public Location currentLocation;
    public float moveSpeed = 5f;
    private bool isMoving = false;

    void Start()
    {
        UpdateHighlights();
    }

    void Update()
    {
        if (isMoving)
        {
            return;
        }

        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            HandleClick();
        }
    }

    void HandleClick()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

        if (hit.collider == null)
        {
            return;
        }

        Location clickedLocation = hit.collider.GetComponent<Location>();

        if (clickedLocation == null)
        {
            return;
        }

        if (currentLocation.connectedLocations.Contains(clickedLocation))
        {
            StartCoroutine(MoveToLocation(clickedLocation));
        }
    }

    IEnumerator MoveToLocation(Location destination)
    {
        isMoving = true;
        ClearHighlights();
        Vector3 targetPosition = destination.transform.position;

        while (Vector3.Distance(transform.position, targetPosition) > 0.05f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }

        transform.position = targetPosition;
        currentLocation = destination;
        isMoving = false;
        UpdateHighlights();
    }

    void UpdateHighlights()
    {
        ClearHighlights();

        foreach (Location location in currentLocation.connectedLocations)
        {
            LocationHighlight highlight = location.GetComponent<LocationHighlight>();

            if (highlight != null)
            {
                highlight.SetHighlight(true);
            }
        }
    }

    void ClearHighlights()
    {
        LocationHighlight[] highlights = FindObjectsByType<LocationHighlight>();

        foreach (LocationHighlight highlight in highlights)
        {
            highlight.SetHighlight(false);
        }
    }
}
