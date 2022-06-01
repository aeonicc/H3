using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace M
{
    public class PasswordPanel : MonoBehaviour
    {
        [Header("UI Elements")]
        public TMP_InputField passwordInput;
        public Button enterButton;

        private void OnEnable()
        {
            passwordInput.text = string.Empty;
            enterButton.interactable = false;
        }

        public void HandleState()
        {
            enterButton.interactable = passwordInput.text != string.Empty;
        }
    }   
}
