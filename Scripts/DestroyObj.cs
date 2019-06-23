using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObj : MonoBehaviour
{

    public void ActivateMe()
    {
        gameObject.SetActive(true);
    }

    public void DeactivateMe()
    {
        StartCoroutine(RemoveAfterSeconds(2));
    }

    IEnumerator RemoveAfterSeconds(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        gameObject.SetActive(false);
    }
}