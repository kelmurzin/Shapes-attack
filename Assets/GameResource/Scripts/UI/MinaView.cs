using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DigitalRuby.Pooling
{
    public class MinaView : MonoBehaviour
    {
        [SerializeField] private Text minaText;
        [SerializeField] private Mina mina;

        private void Start() => mina.onValueChange += UpdateTextMina;

        private void OnDestroy() => mina.onValueChange -= UpdateTextMina;

        private void UpdateTextMina(int value) => minaText.text = value.ToString();

    }

}
