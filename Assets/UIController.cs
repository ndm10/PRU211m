using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    Player player;
    Text distanceText;
    

    GameObject results;
    Text finalDistanceText;

    [SerializeField]
    Text highDistanceText;
    int distance;

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        distanceText = GameObject.Find("DistanceText").GetComponent<Text>();
        results = GameObject.Find("Results");
        finalDistanceText = GameObject.Find("FinalDistanceText").GetComponent<Text>();

        results.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateHighDistanceText();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Mathf.FloorToInt(player.distance);
        distanceText.text = distance + " m";

        if (player.isDead)
        {
            results.SetActive(true);
            finalDistanceText.text = distance + " m";
        }
        CheckHighDistance();
    }

    void CheckHighDistance()
    {
        if(distance > PlayerPrefs.GetInt("HighDistance", 0))
        {
            PlayerPrefs.SetInt("HighDistance", distance);
            UpdateHighDistanceText();
        }
    }

    private void UpdateHighDistanceText()
    {
        highDistanceText.text = $" {PlayerPrefs.GetInt("HighDistance", 0)} m";
    }


    public void Quit()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Retry()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
