using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject[] PlatformPrefabs;
    public GameObject FirstPlatformPrefab;
    public int MinPlatforms;
    public int MaxPlatforms;
    public float DistanceBetweenPlarforms;
    public Transform FinishPlatform;

    private void Awake()
    {
        int platformsCount = Random.Range(MinPlatforms, MaxPlatforms + 1);


        for (int i = 0; i< platformsCount; i++)
        {
            int prefabIndex = Random.Range(0, PlatformPrefabs.Length);
            GameObject platformPrefab = i == 0 ? FirstPlatformPrefab : PlatformPrefabs[prefabIndex];
            GameObject platform = Instantiate(platformPrefab, transform);
            platform.transform.localPosition = CalculatePlatformPosition(i);
            if (i > 0)
                platform.transform.localRotation = Quaternion.Euler(0, Random.Range(0, 360f), 0);
        }

        FinishPlatform.localPosition = CalculatePlatformPosition(platformsCount);


      

    }
    private Vector3 CalculatePlatformPosition(int platformIndex)
    {
            return new Vector3(0, -DistanceBetweenPlarforms * platformIndex, 0);
    }
}
