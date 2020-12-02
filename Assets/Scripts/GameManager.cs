using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public static GameManager instance;
    public GameObject player;
    public GameObject addEnergyPrefab;
    public GameObject minusEnergyPrefab;
    public int numberOfSpawn;
    public float levelTime;
    public Text timerText;
    public Text energyText;
    int spawn4 = 4;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
		{
            instance = this;
		}
        for (int i = 0; i < numberOfSpawn; i++)
        {
            if (Random.Range(0, 2) < 1)
            {
                Vector3 randomPos = new Vector3(Random.Range(-15, 15), 0, Random.Range(-15, 15));
                Instantiate(addEnergyPrefab, randomPos, Quaternion.identity);
            }
            else
            {
                Vector3 randomPos = new Vector3(Random.Range(-15, 15), 0, Random.Range(-15, 15));
                Instantiate(minusEnergyPrefab, randomPos, Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (levelTime > 0)
		{
            levelTime -= Time.deltaTime;
            print("levelTime: " + FormatTime(levelTime));
		}
        else
		{
            levelTime = 0;
            print("Time's up!");
            timerText.text = "Time's up!";
		}
        timerText.text = "Timer : " + FormatTime(levelTime);
    }
	public string FormatTime(float time)
	{
        int minutes = (int)time / 60;
        int seconds = (int)time - 60 * minutes;
        int milliseconds = (int)(1000 * (time - minutes * 60 - seconds));
        return string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
	}
    public void Instantiate4More()
	{
        for (int i = 0; i < spawn4; i++)
        {
            if (Random.Range(0, 2) < 1)
            {
                Vector3 randomPos = new Vector3(Random.Range(-15, 15), 0, Random.Range(-15, 15));
                Instantiate(addEnergyPrefab, randomPos, Quaternion.identity);
            }
            else
            {
                Vector3 randomPos = new Vector3(Random.Range(-15, 15), 0, Random.Range(-15, 15));
                Instantiate(minusEnergyPrefab, randomPos, Quaternion.identity);
            }
        }
    }
}
