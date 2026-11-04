
using UnityEngine;

public class PlayerPassport : MonoBehaviour
{
    public bool hasPassport = false;

    public void CollectPassport()
    {
        hasPassport = true;
        Debug.Log("Passport collected!");
    }
}
