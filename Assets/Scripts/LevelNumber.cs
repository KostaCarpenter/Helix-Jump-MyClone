
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class LevelNumber : MonoBehaviour
    {

        public TMP_Text textMeshPro;
        public Game Game;


        private void Start()
        {
            textMeshPro.text = "Level " + (Game.LevelIndex + 1).ToString();
        }

    }
}