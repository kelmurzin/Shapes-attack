using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonGameActive : ButtonAction
{    
    [SerializeField] private GameManager gameManager;
    [SerializeField] private bool isActive;

    public override void ButtonClick() => gameManager.ChangeActivityGame(isActive);    
}
