// ********************************************************************************
// @author: Starry Sky
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2024/09/27 23:09
// @version: 1.0
// @description:
// ********************************************************************************

using System;
using UnityEngine;

namespace MenuScene.Managers
{
    public class GameManager : MonoBehaviour
    {
        // 单例
        public static GameManager Instance;

        private void Awake()
        {
            Instance = this;
            Application.targetFrameRate = 144;
        }

        private void Update()
        {
            // 全屏切换
            if (Input.GetKeyDown(KeyCode.F11) || Input.GetKeyDown(KeyCode.F4))
            {
                Screen.fullScreen = !Screen.fullScreen;
            }
        }
    }
}
