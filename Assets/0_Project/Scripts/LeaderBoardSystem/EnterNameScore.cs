using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

public class EnterNameScore : MonoBehaviour
{
    string playerName;
    public TMP_InputField inputField;
    public void ConfirmName()
    {
        if (inputField != null)
            playerName = inputField.text;
        else
            Debug.Log("PORCO DIO");
    }

    public string GetPlayerName()
    {
        Debug.Log($"GetPlayerName: {playerName}");

        return playerName;  
    }
}
