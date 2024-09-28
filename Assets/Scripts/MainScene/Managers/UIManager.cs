// ********************************************************************************
// @author: Starry Sky
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2024/09/28 07:09
// @version: 1.0
// @description:
// ********************************************************************************

using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MainScene.Managers
{
    public class UIManager : MonoBehaviour
    {
        // 单例
        public static UIManager Instance;
        
        // 暂停面板
        public GameObject panelPause;
        // 计数
        public TMP_Text textCount;
        // 胜利面板
        public GameObject panelWin;

        private void Awake()
        {
            Instance = this;
            textCount.text = "剩余图片等待揭开：25";
            panelPause.SetActive(false);
            panelWin.SetActive(false);
        }

        /// <summary>
        /// 控制暂停面板显示
        /// </summary>
        public void ShowPausePanel()
        {
            Time.timeScale = 0f;
            panelPause.SetActive(true);
        }

        /// <summary>
        /// 继续游戏按钮
        /// </summary>
        public void BtnContinueClicked()
        {
            Time.timeScale = 1f;
            panelPause.SetActive(false);
        }

        /// <summary>
        /// 回到标题界面按钮
        /// </summary>
        public void BtnBackToTitleClicked()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(0);
        }

        /// <summary>
        /// 退出游戏按钮
        /// </summary>
        public void BtnExitClicked()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }

        /// <summary>
        /// 再玩一次
        /// </summary>
        public void BtnPlayAgain()
        {
            SceneManager.LoadScene(1);
            Time.timeScale = 1f;
        }

        /// <summary>
        /// 设置计数
        /// </summary>
        public void SetCount()
        {
            textCount.text = "剩余图片等待揭开：" + GameManager.Instance.Count;
        }
        
        /// <summary>
        /// 胜利
        /// </summary>
        public void ShowWin()
        {
            panelWin.SetActive(true);
        }
    }
}
