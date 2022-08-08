using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonGameActive : MonoBehaviour
{
    private Button button;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private bool isActive;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(ChangeActivityGame);
    }

    private void OnDestroy() => button.onClick.RemoveListener(ChangeActivityGame);
    
    private void ChangeActivityGame() => gameManager.ChangeActivityGame(isActive);
   
}
