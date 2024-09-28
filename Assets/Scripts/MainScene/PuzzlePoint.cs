// ********************************************************************************
// @author: Starry Sky
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2024/09/28 10:09
// @version: 1.0
// @description:
// ********************************************************************************

using System;
using System.Linq;
using MainScene.Managers;
using UnityEngine;

namespace MainScene
{
    public class PuzzlePoint : MonoBehaviour
    {
        /// <summary>
        /// 显示自身图片
        /// </summary>
        private void ShowSelf()
        {
            var point = Vector3Int.zero;
            point.x = int.Parse(gameObject.name) - 4;
            
            // 第一行
            if (GameManager.Instance.puzzlePointsC1.Contains(gameObject))
            {
                point.y = 1;
            }
            // 第二行
            else if (GameManager.Instance.puzzlePointsC2.Contains(gameObject))
            {
                point.y = 0;
            }
            // 第三行
            else if (GameManager.Instance.puzzlePointsC3.Contains(gameObject))
            {
                point.y = -1;
            }
            // 第四行
            else if (GameManager.Instance.puzzlePointsC4.Contains(gameObject))
            {
                point.y = -2;
            }
            // 第五行
            else if (GameManager.Instance.puzzlePointsC5.Contains(gameObject))
            {
                point.y = -3;
            }
            Debug.Log(point);

            GameManager.Instance.PuzzlePoint = point;
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                ShowSelf();
            }
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                ShowSelf();
            }
        }
    }
}
