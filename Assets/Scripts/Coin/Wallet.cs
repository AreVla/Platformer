using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    private float _money = 0;

    public float Money
    {
        set { _money = value; }
        get { return _money; }
    }
}
