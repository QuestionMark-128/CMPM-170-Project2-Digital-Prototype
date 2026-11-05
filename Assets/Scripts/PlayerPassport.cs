
using UnityEngine;
using TMPro;
using System.Collections;

public class PlayerPassport : MonoBehaviour
{
    public bool hasPassport = false;
    public TMP_Text passportMessage;

    public void CollectPassport()
    {
        hasPassport = true;
        Debug.Log("Passport collected!");

        StartCoroutine(ShowPassportMessage());
    }

    IEnumerator ShowPassportMessage()
    {
        passportMessage.text = "Passport Acquired!";
        passportMessage.gameObject.SetActive(true);

        yield return new WaitForSeconds(2f);

        passportMessage.gameObject.SetActive(false);
    }
}
