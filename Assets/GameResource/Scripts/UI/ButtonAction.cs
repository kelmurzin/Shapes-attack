using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public abstract class ButtonAction : MonoBehaviour
{
    private Button button;

    public abstract void ButtonClick();

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(ButtonClick);
    }

    private void OnDestroy() => button.onClick.RemoveListener(ButtonClick);
}
