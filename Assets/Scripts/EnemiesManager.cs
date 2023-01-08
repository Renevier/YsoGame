using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] float dist;
    [SerializeField] float timeBetweenSpawn;
    [SerializeField] GameObject enemy;

    float timeForSpawn;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timeForSpawn += Time.deltaTime;

        if (timeForSpawn >= timeBetweenSpawn)
        {
            if (player != null)
                SpawnEnemies();
        }
    }

    void SpawnEnemies()
    {
        Vector2 offset = Random.insideUnitCircle * dist;
        Vector3 pos = player.transform.position;
        Vector3 newPos = new Vector3(pos.x + offset.x, pos.y, pos.z + offset.y);

        if (Vector3.Distance(player.transform.position, newPos) >= 10f)
        {
            GameObject go = Instantiate(enemy, newPos, Quaternion.identity);
            go.GetComponent<Enemy>().player = player;
            timeForSpawn = 0;
        }
    }
}
