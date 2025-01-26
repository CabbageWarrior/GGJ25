using System.Collections;
using System.Collections.Generic;
using TMPro;

using UnityEngine.UI;

using UnityEngine;

public class EnterNameScore : MonoBehaviour
{
    string playerName;
    public TMP_InputField inputField;
    public void ConfirmName()
    {
        if (inputField != null)
            playerName = inputField.text;
    }

    public string GetPlayerName()
    {

        return playerName;  
    }
}
