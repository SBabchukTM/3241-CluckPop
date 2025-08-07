using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Runtime.Game
{
    public class ExerciseSelectButton : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _nameText;
        [SerializeField] private Button _button;
    
        private string _description;
    
        public event Action<string, string> OnClicked;

        private void Awake()
        {
            _button.onClick.AddListener(() => OnClicked?.Invoke(_nameText.text, _description));
        }

        public void SetData(ExerciseExplanation exercise)
        {
            _nameText.text = exercise.ExerciseName;
            _description = exercise.ExerciseDescription;
        }
    }
}
