using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class information_menu : MonoBehaviour
{
    public GameObject start_screen;
    public GameObject end_screen;

    private Player player;

    void Start() {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    void Update() {
        if(end_screen.activeSelf)
            player.can_move = false;
        else
            player.can_move = true;
    }

    public void return_game() {
        if(start_screen.activeSelf)
            start_screen.SetActive(false);
        else if(end_screen.activeSelf)
            end_screen.SetActive(false);
    }

    public void quit_game() {
        Application.Quit();
    }
}
