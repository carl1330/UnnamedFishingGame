using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Player", menuName = "Player")]
public class PlayerStats : ScriptableObject
{
    public string playerName;
    public int playerLevel;
    public int playerStrength;
    public int playerStamina;
    public int playerLuck;

    public int playerMoney;

    public int fishCaught;

}
