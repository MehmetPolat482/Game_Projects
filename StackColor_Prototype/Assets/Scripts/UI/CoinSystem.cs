using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinSystem : MonoBehaviour
{
    [Header("Coin Score")]

    public static CoinSystem instance;
    [SerializeField] private Text _coinTxt;
    public static int coinScorer;


    private void OnEnable()
    {
        if (instance == null)
            instance = this;
    }
    // Start is called before the first frame update
    public void ScoreUpdate(int valueIn)
    {
        coinScorer += valueIn;
        _coinTxt.text =coinScorer.ToString();

    }

}
