using System.Collections;
using UnityEngine;

public class Particle : MonoBehaviour
{
    void OnEnable()
    {
        StartCoroutine(AutoDisable());
    }

    private IEnumerator AutoDisable()
    {
        yield return new WaitForSeconds(.75f);

        gameObject.SetActive(false);
    }
}
