using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Linq;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public Location currentLocation;
    public float moveSpeed = 5f;
    private bool isMoving = false;
    public StampManager stampManager;
    public TextMeshProUGUI diceText;
    public TextMeshProUGUI movesText;
    private bool hasRolled = false;
    private int movesRemaining = 0;

    void Start()
    {
        UpdateHighlights();
        UpdateUI();
    }

    void Update()
    {
        if (isMoving || !hasRolled)
        {
            return;
        }

        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            HandleClick();
        }
    }

    public void RollDice()
    {
        if (hasRolled || isMoving)
        {
            return;
        }

        int diceRoll = Random.Range(1, 7);
        movesRemaining = diceRoll;
        hasRolled = true;

        if (diceText != null)
        {
            diceText.text= "Dice: " + diceRoll;
        }

        UpdateUI();
        UpdateHighlights();
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
        stampManager.TryAwardStamp(destination);
        isMoving = false;

        movesRemaining--;
        UpdateUI();

        if (movesRemaining <= 0)
        {
            EndTurn();
            yield break;
        }
        
        if (currentLocation.connectedLocations.Count == 0)
        {
            EndTurn();
            yield break;
        }

        UpdateHighlights();
    }

    void EndTurn()
    {
        hasRolled = false;
        movesRemaining = 0;

        ClearHighlights();
        UpdateUI();
    }

    void UpdateHighlights()
    {
        ClearHighlights();

        if (!hasRolled || movesRemaining <= 0)
        {
            return;
        }

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

    void UpdateUI()
    {
        if (movesText != null)
        {
            movesText.text = "Moves Remaining: " + movesRemaining;
        }
    }
}
