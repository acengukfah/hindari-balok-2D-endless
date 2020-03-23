using UnityEngine;
using UnityEngine.UI;

public class BlockSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject blockPrefab;
    public float timeBetweenSpawn = 1f;
    private float timeToSpawn = 2f;
    public static int waves = 0; 
    public static int highScore = 0;

    public Text scoreText;
    public Text highScoreText;

    // Start is called before the first frame update
    void Start()
    {
        waves = 0;
        highScore = PlayerPrefs.GetInt("highscore");
        highScoreText.text = highScore.ToString();
    }
    void Update()
    {
        if (Time.time >= timeToSpawn)
        {
            SpawnBlocks();
            timeToSpawn = Time.time + timeBetweenSpawn;
            waves++;
            scoreText.text = waves.ToString() ;
        }

        if (waves > highScore)
        {
            PlayerPrefs.SetInt("highscore", waves);
            highScoreText.text = waves.ToString();
        }
    }

    void SpawnBlocks()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);

        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (randomIndex != i)
            {
                Instantiate(blockPrefab, spawnPoints[i].position, Quaternion.identity);
            }
        }
    }
}
