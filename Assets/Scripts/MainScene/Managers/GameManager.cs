// ********************************************************************************
// @author: Starry Sky
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2024/09/28 00:09
// @version: 1.0
// @description:
// ********************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace MainScene.Managers
{
    public class GameManager : MonoBehaviour
    {
        // 单例
        public static GameManager Instance;

        // 瓦片
        public Tilemap tilemapPuzzle;
        public TileBase[] tilebasePuzzles;

        // 图点
        public GameObject[] puzzlePointsC1;
        public GameObject[] puzzlePointsC2;
        public GameObject[] puzzlePointsC3;
        public GameObject[] puzzlePointsC4;
        public GameObject[] puzzlePointsC5;

        public Vector3Int PuzzlePoint { get; set; }

        public int Count { get; set; }
        
        // 时间限制
        public float timeLimit;

        public float Timer { get; set; }
        // 已填充
        private List<int> _puzzleFilled = new List<int>();

        private void Awake()
        {
            Instance = this;
            Application.targetFrameRate = 144;
            Count = 25;
            Timer = 0f;
        }

        private void Update()
        {
            HandleInput();
            HandleTime();
        }
        
        /// <summary>
        /// 显示瓦片地图
        /// </summary>
        private void ShowTile()
        {
            var index = PuzzlePoint.x + 4 + (1 - PuzzlePoint.y) * 5 - 1;
            if (_puzzleFilled.Contains(index))
            {
                return;
            }
            _puzzleFilled.Add(index);
            tilemapPuzzle.SetTile(PuzzlePoint, tilebasePuzzles[index]);
            Count--;
            UIManager.Instance.SetCount();
            if (Count == 0)
            {
                UIManager.Instance.ShowWin();
            }
        }

        /// <summary>
        /// 处理用户按键
        /// </summary>
        private void HandleInput()
        {
            // 全屏切换
            if (Input.GetKeyDown(KeyCode.F11) || Input.GetKeyDown(KeyCode.F4))
            {
                Screen.fullScreen = !Screen.fullScreen;
            }
            // 暂停游戏
            else if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
            {
                UIManager.Instance.ShowPausePanel();
            }
            else if (Input.GetKeyDown(KeyCode.F))
            {
                ShowTile();
            }
        }

        /// <summary>
        /// 处理时间限制
        /// </summary>
        private void HandleTime()
        {
            Timer += Time.deltaTime;
            //Debug.Log(Timer);
            if (Timer > timeLimit)
            {
                UIManager.Instance.ShowWin(false);
            }
        }
    }
}
