using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    private bool isInShop = false;
    private bool isInMenu = false;

    public GameObject shopUI;
    public GameObject menuUI;
    private GameObject player;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {

            if (isInShop)
            {
                Resume();
            }

            else
            {
                ShopPause();
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isInMenu)
            {
                Resume();
            }

            else
            {
                MenuPause();
            }
        }
    }

    void Resume()
    {
        isInMenu = false;
        isInShop = false;
        Time.timeScale = 1f;

        shopUI.SetActive(isInShop);
        menuUI.SetActive(isInMenu);
        EnableShooting();
    }

    void DisableShooting()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if(player != null)
        {
            player.GetComponentInChildren<Shooting>().enabled = false;
        }
    }

    void EnableShooting()
    {
        if (player != null)
        {
            player.GetComponentInChildren<Shooting>().enabled = true;
        }
    }

    void ShopPause()
    {
        isInShop = true;
        Time.timeScale = 0f;
        DisableShooting();
        shopUI.SetActive(isInShop);
    }

    void MenuPause()
    {
        isInMenu = true;
        Time.timeScale = 0f;
        DisableShooting();
        menuUI.SetActive(isInMenu);
    }
}
