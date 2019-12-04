using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Sprite[] cardFace;
    public Sprite cardBack;
    public GameObject[] Cards;
    public Text matchText;

    private bool _init = false;
    private int _matches = 4;

    // Update is called once per frame
    void Update()
    {
        if (!_init)
        {
            initializeCards();
        }
        if (Input.GetMouseButtonUp(0))
        {
            checkCards();
        }
    }

    void initializeCards()
    {
        for (int id = 0; id < 2; id++)
        {
            for (int i = 1; i < 5; i++)
            {
                bool test = false;
                int choice = 0;
                while (!test)
                {
                    choice = Random.Range(0, Cards.Length);
                    test = !(Cards[choice].GetComponent<card>().initialized);
                }
                Cards[choice].GetComponent<card>().cardValue = i;
                Cards[choice].GetComponent<card>().initialized = true;
            }
        }
        foreach (GameObject c in Cards)
            c.GetComponent<card>().setupGraphics();
        if (!_init)
            _init = true;
    }

    public Sprite getCardBack()
    {
        return cardBack;
    }

    public Sprite getCardFace(int i)
    {
        return cardFace[i - 1];
    }

    void checkCards()
    {
        List<int> c = new List<int>();

        for (int i = 0; i < Cards.Length; i++)
        {
            if (Cards[i].GetComponent<card>().state == 1)
            {
                c.Add(i);
            }
        }

        if (c.Count == 2)
        {
            cardComparison(c);
        }
    }

    void cardComparison(List<int> c)
    {
        card.DO_NOT = true;

        int x = 0;

        if (Cards[c[0]].GetComponent<card> ().cardValue == Cards[c[1]].GetComponent<card>().cardValue)
        {
            x = 2;
            _matches--;
            matchText.text = "Número de combinações restantes: " + _matches;
            if (_matches == 0)
            {
                SceneManager.LoadScene("Menu");
            }
        }
        for (int i = 0; i < c.Count; i++)
        {
            Cards[c[i]].GetComponent<card>().state = x;
            Cards[c[i]].GetComponent<card>().falseCheck();
        }
    }
}
