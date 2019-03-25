using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyUI : MonoBehaviour {

    public Text moneyText;
	// BUNU OPTİMİZASYON İÇİN DEĞİŞTİR INVOKE FALAN DENE

	void Update () {
        moneyText.text = "$" + PlayerStats.Money.ToString();
	}
}
