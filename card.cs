using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class card : MonoBehaviour
{
    public static bool DO_NOT = false;

    [SerializeField]
    private int _state;
    [SerializeField]
    private int _cardValue;
    [SerializeField]
    private bool _initialized = false;

    private Sprite cardBack;
    private Sprite cardFace;

    private GameObject _manager;

    private void Start()
    {
        _state = 1;
        _manager = GameObject.FindGameObjectWithTag("Manager");
    }

    public void setupGraphics()
    {
        cardBack = _manager.GetComponent<GameManager>().getCardBack();
        cardFace = _manager.GetComponent<GameManager>().getCardFace(_cardValue);

        flipCard();
    }

    public void flipCard()
    {
        if (_state == 0)
        {
            _state = 1;
        }
        else if (_state == 1)
        {
            _state = 0;
        }

        if (_state == 0 && !DO_NOT)
        {
            GetComponent<Image>().sprite = cardBack;
        }
        else if (_state == 1 && !DO_NOT)
        {
            GetComponent<Image>().sprite = cardFace;
        }
    }

    public int cardValue
    {
        get
        {
            return _cardValue;
        }
        set
        {
            _cardValue = value;
        }
    }

    public int state
    {
        get
        {
            return _state;
        }
        set
        {
            _state = value;
        }
    }

    public bool initialized
    {
        get
        {
            return _initialized;
        }
        set
        {
            _initialized = value;
        }
    }

    public void falseCheck()
    {
        StartCoroutine ( pause ());
    }

    IEnumerator pause()
    {
        yield return new WaitForSeconds(1);
        if (_state == 0)
        {
            GetComponent<Image>().sprite = cardBack;
        }
        else if (_state == 1)
        {
            GetComponent<Image>().sprite = cardFace;
        }
        DO_NOT = false;
    }
}
