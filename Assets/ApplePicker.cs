using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro; // Fixed my issue of RoundText not attatching



public class ApplePicker : MonoBehaviour
{
    [Header("Inscribed")]
    public GameObject basketPrefab;
    public int numBaskets = 4;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    public List<GameObject> basketList;
    public TMP_Text roundText;     // Drag RoundText here in Inspector
    public int round = 1;      // Start at round 1
    public int maxRounds = 4;  // Goes up to round 4
    public GameObject restartButton;   // Drag the RestartButton here in Inspector


    void Start()
    {
        basketList = new List<GameObject>();
        for (int i = 0; i < numBaskets; ++i)
        {
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
        }

        UpdateRoundText();
        if (restartButton != null)
            restartButton.SetActive(false); // Hidden at start
    }

    public void AppleMissed()
    {
        // Destroy all of the falling Apples
        GameObject[] appleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject tempGO in appleArray)
        {
            Destroy(tempGO);
        }

        // Destroy one of the Baskets
        // Get the index of the last Basket in basektList
        int basketIndex = basketList.Count - 1;
        //Get a referece to that Basekt GameObject;
        GameObject basketGO = basketList[basketIndex];
        //Remove the Basket from the list and destory the GameObject
        basketList.RemoveAt(basketIndex);
        Destroy(basketGO);

        NextRound();

        // If there are no Baskets left, restart the game
        if (basketList.Count == 0)
        {
            GameOver();
        }

    }

    public void UpdateRoundText()
    {
        if (round <= maxRounds)
            roundText.text = "Round " + round;
        else
            roundText.text = "Game Over";
    }

    public void NextRound()
    {
        round++;
        UpdateRoundText();
    }

    public void GameOver()
    {
        round = maxRounds + 1;
        UpdateRoundText();
        Time.timeScale = 0f;

        if (restartButton != null)
            restartButton.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("_Scene_0");
    }

}
