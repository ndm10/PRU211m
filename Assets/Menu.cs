using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Vector2 startPosition;

    public void StartGame()
    {
        // Đặt lại vị trí khởi đầu của nhân vật

        Player player = FindObjectOfType<Player>();
        player.transform.position = startPosition;

        // Chuyển sang màn Sample
        SceneManager.LoadScene("SampleScene");
    }
}
