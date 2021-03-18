using UnityEngine;

public class Persistent : MonoBehaviour
{
    public static Persistent instance;

    void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);
        else
            instance = this;

        DontDestroyOnLoad(instance);
    }
}
