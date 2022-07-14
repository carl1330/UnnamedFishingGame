using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StatHandler : MonoBehaviour
{
    public PlayerStats stats;
    public Text playerName;
    public Text playerLevel;
    public Text playerStrength;
    public Text playerStamina;
    public Text playerLuck;
    public Text playerFish;
    public Text playerMoney;

    private void Start()
    {
        playerName.text = stats.playerName;
        playerLevel.text = "LVL " + stats.playerLevel.ToString();
        playerStrength.text = "Strength: " + stats.playerStrength.ToString();
        playerStamina.text = "Stamina: " + stats.playerStamina.ToString();
        playerLuck.text = "Luck: " + stats.playerLuck.ToString();
        playerFish.text = "Fish: " + stats.fishCaught.ToString();
        playerMoney.text = "Money: " + stats.playerMoney.ToString();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StartCoroutine(LoadYourAsyncScene());
        }
    }

    IEnumerator LoadYourAsyncScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("NewMap");

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
