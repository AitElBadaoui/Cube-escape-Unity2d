using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab;
    public GameObject spikePlatformPrefab;
    public GameObject[] movingPlatforms;
    public GameObject breakablePlatform;

    public float platform_Spawn_Timer = 2f;
    private float current_Platform_Spawn_Timer;

    private int platform_Spawn_Count;
    public float min_X = -2f, max_X = 2f; //Set the intervall to show platform inside screen


    // Start is called before the first frame update
    void Start()
    {
        current_Platform_Spawn_Timer = platform_Spawn_Timer;
    }

    // Update is called once per frame
    void Update()
    {
        SpawnPlatforms();
    }

    void SpawnPlatforms()
    {
        current_Platform_Spawn_Timer += Time.deltaTime;

        if (current_Platform_Spawn_Timer >= platform_Spawn_Timer)
        {
            platform_Spawn_Count++;
            Vector3 temp = transform.position;
            temp.x = Random.Range(min_X, max_X);
            GameObject newplatform = null;

            if (platform_Spawn_Count < 2f)
            {
                newplatform = Instantiate(platformPrefab, temp, Quaternion.identity);
            }
            else if (platform_Spawn_Count == 2)
            {
                if (Random.Range(0, 2) > 0)
                {
                    newplatform = Instantiate(platformPrefab, temp, Quaternion.identity);
                }
                else
                {
                    newplatform = Instantiate(movingPlatforms[Random.Range(0, movingPlatforms.Length)], temp, Quaternion.identity);
                }
            }
            else if (platform_Spawn_Count == 3)
            {
                if (Random.Range(0, 2) > 0)
                {
                    newplatform = Instantiate(platformPrefab, temp, Quaternion.identity);
                }
                else
                {
                    newplatform = Instantiate(spikePlatformPrefab, temp, Quaternion.identity);
                }
            }
            else if (platform_Spawn_Count == 4)
            {
                if (Random.Range(0, 2) > 0)
                {
                    newplatform = Instantiate(platformPrefab, temp, Quaternion.identity);
                }
                else
                {
                    newplatform = Instantiate(breakablePlatform, temp, Quaternion.identity);
                }
                platform_Spawn_Count = 0;
            }
            newplatform.transform.parent = transform;
            current_Platform_Spawn_Timer = 0f;
        }
    }
}
