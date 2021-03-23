using UnityEngine;

public class Path : MonoBehaviour
{
    public GameObject cubePrefab;
    public Transform lastPosition;

    public float offset = 0.7071068f;

    public ObjectPool pool;

    private int cubeCount = 0;
    private int crystalChance = 0;

    public void StartBuilding()
    {
        InvokeRepeating(nameof(SpawnCube), 1f, 0.5f);
    }

    private void SpawnCube()
    {
        Vector3 spawnPosition;

        int chance = Random.Range(0, 100);

        if (chance < 50)
        {
            // right
            spawnPosition = new Vector3(lastPosition.position.x + offset, lastPosition.position.y, lastPosition.position.z + offset);
        }
        else
        {
            // left
            spawnPosition = new Vector3(lastPosition.position.x - offset, lastPosition.position.y, lastPosition.position.z + offset);
        }

        GameObject cube = pool.Spawn(spawnPosition, Quaternion.Euler(0, 45, 0));

        lastPosition = cube.transform;

        if (cubeCount == 0)
            crystalChance = Random.Range(3, 9); // a crystal will spawn every 3 to 9 cubes 

        if (cubeCount == crystalChance)
        {
            cube.transform.GetChild(0).gameObject.SetActive(true);
            cubeCount = 0;
        }
        else
            cubeCount++;
    }
}
