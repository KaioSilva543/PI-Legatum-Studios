using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoedaManager : MonoBehaviour
{
    private int coins;
    public static MoedaManager instance;
    [SerializeField] private TMP_Text coinsDisplay;

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
    }

    private void OnGUI()
    {
        coinsDisplay.text = coins.ToString();
    }

    public void ChangeCoins(int amount)
    {
        coins += amount;
    }
}
