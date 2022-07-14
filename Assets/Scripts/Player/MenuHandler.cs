using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuHandler : MonoBehaviour
{
    public Image menu;
    private int menuItems;
    private int menuIndex;

    void Start()
    {
        menu.gameObject.SetActive(false);
        menuItems = menu.transform.childCount;
    }

    public void openMenu()
    {
        menuIndex = 0;
        menu.gameObject.SetActive(true);
        menu.transform.GetChild(menuIndex).GetComponent<Text>().fontStyle = FontStyle.Bold;
    }

    public void closeMenu()
    {
        menu.gameObject.SetActive(false);
        menu.transform.GetChild(menuIndex).GetComponent<Text>().fontStyle = FontStyle.Normal;
    }

    public void scrollDown()
    {
        menu.transform.GetChild(menuIndex).GetComponent<Text>().fontStyle = FontStyle.Normal;
        menuIndex++;

        if (menuIndex >= menuItems)
            menuIndex = 0;

        menu.transform.GetChild(menuIndex).GetComponent<Text>().fontStyle = FontStyle.Bold;

    }

    public void scrollUp()
    {
        menu.transform.GetChild(menuIndex).GetComponent<Text>().fontStyle = FontStyle.Normal;
        menuIndex--;

        if (menuIndex < 0)
            menuIndex = 2;

        menu.transform.GetChild(menuIndex).GetComponent<Text>().fontStyle = FontStyle.Bold;
    }

    public void selectOption()
    {
        switch(menuIndex)
        {
            case 0:
                openInventory();
                break;
            case 1:
                openStatistics();
                break;
            case 2:
                closeMenu();
                break;
        }
    }

    private void openInventory()
    {

    }

    private void openStatistics()
    {

    }

}
