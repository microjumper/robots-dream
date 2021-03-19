using UnityEngine;

public class Crystal : MonoBehaviour
{
    public GameObject particle;

    private void OnDisable()
    {
        particle.SetActive(true);
    }
}
