using System;
using System.Collections.Generic;
using DG.Tweening;
using Runtime.Game.Services.UserData.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Runtime.Game.UI.Screen
{
    public class ExercisesScreen : UiScreen
    {
        [SerializeField] private Button _backButton;
        [SerializeField] private TextMeshProUGUI _difficultyText;
        [SerializeField] private List<ProgramExerciseDisplay> _programExerciseDisplay;
        [SerializeField] private CanvasGroup _rewardCanvas;
        
        private Sequence _rewardSequence;
        
        public event Action OnBackPressed;
        
        public event Action OnExercise1Pressed;
        public event Action OnExercise2Pressed;
        
        public void Initialize(List<ExerciseDisplayData> exerciseDisplayData)
        {
            SubscribeEvents();

            for (int i = 0; i < _programExerciseDisplay.Count; i++)
            {
                _programExerciseDisplay[i].Initialize(exerciseDisplayData[i]);
                _programExerciseDisplay[i].OnExercise1Cleared += () => OnExercise1Pressed?.Invoke();
                _programExerciseDisplay[i].OnExercise2Cleared += () => OnExercise2Pressed?.Invoke();
            }
        }
        
        public void SetDifficulty(DifficultyType type) => _difficultyText.text = type + " DIFFICULTY";

        public void DisplayReward()
        {
            _rewardSequence?.Kill();
            _rewardSequence = DOTween.Sequence();

            _rewardCanvas.alpha = 0;
            
            _rewardSequence.Append(_rewardCanvas.DOFade(1, 0.15f));
            _rewardSequence.AppendInterval(0.34f);
            _rewardSequence.Append(_rewardCanvas.DOFade(0, 0.15f));
        }
        
        private void SubscribeEvents()
        {
            _backButton.onClick.AddListener(() => OnBackPressed?.Invoke());
        }
    }
}