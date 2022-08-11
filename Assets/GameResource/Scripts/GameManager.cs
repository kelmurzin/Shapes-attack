using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public event Action<bool> onBoolChange = delegate { };

    public void ChangeActivityGame(bool isActive) => onBoolChange(isActive);
  
}
