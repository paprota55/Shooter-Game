using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///Class to pause game and show UI
public class PauseController : MonoBehaviour
{
    ///Variables to store information about UI enable
    private bool isInShop = false;
    private bool isInMenu = false;

    ///UI objects to show/hide UI
    public GameObject shopUI;
    public GameObject menuUI;

    ///player object to enabling disabling shooting
    private GameObject player;

    private void Start()
    {
        ShopPause();
    }

    ///Check if user press button B or ESC and run shop or menu
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (!isInShop)
            {
                if (!isInMenu)
                {
                    ShopPause();
                }
            }

            else
            {
                Resume();
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isInMenu)
            {
                if (!isInShop)
                {
                    MenuPause();
                }
            }

            else
            {
                Resume();
            }
        }
    }

    ///Hide menu and shop and resume game
    public void Resume()
    {
        isInMenu = false;
        isInShop = false;
        Time.timeScale = 1f;

        shopUI.SetActive(isInShop);
        menuUI.SetActive(isInMenu);
        EnableShooting();
    }

    ///Disable player shooting
    void DisableShooting()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if(player != null)
        {
            player.GetComponentInChildren<Shooting>().enabled = false;
        }
    }

    ///Enable player shooting
    void EnableShooting()
    {
        if (player != null)
        {
            player.GetComponentInChildren<Shooting>().enabled = true;
        }
    }

    ///Pause game and show Shop UI
    void ShopPause()
    {
        isInShop = true;
        Time.timeScale = 0f;
        DisableShooting();
        shopUI.SetActive(isInShop);
    }

    ///Pause game and show menu UI
    void MenuPause()
    {
        isInMenu = true;
        Time.timeScale = 0f;
        DisableShooting();
        menuUI.SetActive(isInMenu);
    }
}
