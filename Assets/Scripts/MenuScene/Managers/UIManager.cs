using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MenuScene.Managers
{
    public class UIManager : MonoBehaviour
    {
        // 单例
        public static UIManager Instance;

        // 帮助面板
        public GameObject helpPanel;

        private void Awake()
        {
            Instance = this;
            helpPanel.SetActive(false);
        }

        /// <summary>
        /// 点击开始游戏按钮
        /// </summary>
        public void BtnPlayClicked()
        {
            SceneManager.LoadScene(1);
        }

        /// <summary>
        /// 操作教程按钮点击
        /// </summary>
        public void BtnHelpClicked()
        {
            helpPanel.SetActive(true);
        }

        /// <summary>
        /// 关闭教程按钮点击
        /// </summary>
        public void BtnCloseHelpClicked()
        {
            helpPanel.SetActive(false);
        }

        /// <summary>
        /// 退出游戏按钮点击
        /// </summary>
        public void BtnExitClicked()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}
