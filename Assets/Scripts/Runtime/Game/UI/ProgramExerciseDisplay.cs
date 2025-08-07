using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Runtime.Game.UI
{
    public class ProgramExerciseDisplay : MonoBehaviour
    {
        [SerializeField] private Color _inactiveColor;
    
        [SerializeField] private GameObject _completedCheckmark;
        [SerializeField] private TextMeshProUGUI _exercise1Text;
        [SerializeField] private TextMeshProUGUI _exercise2Text;
        [SerializeField] private Toggle _exercise1Toggle;
        [SerializeField] private Toggle _exercise2Toggle;
        [SerializeField] private GameObject _exercisesBg;
        [SerializeField] private GameObject _completedBg;
        [SerializeField] private TextMeshProUGUI _completedText;

        [SerializeField] private Image _dayImage;
        [SerializeField] private Image _exercisesImage;
    
        public event Action OnExercise1Cleared;
        public event Action OnExercise2Cleared;
    
        public void Initialize(ExerciseDisplayData exerciseDisplayData)
        {
            _completedText.text = exerciseDisplayData.CompleteMessage;
            SetText(exerciseDisplayData.ExerciseDayData);

            if (exerciseDisplayData.Cleared)
            {
                SetCompleted();
                return;
            }

            if (exerciseDisplayData.Locked)
            {
                SetLocked();
                return;
            }

            if (exerciseDisplayData.Exercise1Completed)
            {
                _exercise1Toggle.isOn = true;
                _exercise1Toggle.interactable = false;
            }
            else
            {
                _exercise1Toggle.isOn = false;
                _exercise1Toggle.onValueChanged.AddListener(_ => ClearExercise1());
            }
        
            if (exerciseDisplayData.Exercise2Completed)
            {
                _exercise2Toggle.isOn = true;
                _exercise2Toggle.interactable = false;
            }
            else
            {
                _exercise2Toggle.isOn = false;
                _exercise2Toggle.onValueChanged.AddListener(_ => ClearExercise2());
            }
        }

        private void SetText(ExerciseDayData exerciseDayData)
        {
            string text1 = "1. " + exerciseDayData.ExerciseOne.Name.ToUpper() + " - "
                           + exerciseDayData.ExerciseOne.Reps + " REPS" + " - " + exerciseDayData.ExerciseOne.Hint;
        
            _exercise1Text.text = text1;
        
            string text2 = "2. " + exerciseDayData.ExerciseTwo.Name.ToUpper() + " - "
                           + exerciseDayData.ExerciseTwo.Reps + " REPS" + " - " + exerciseDayData.ExerciseTwo.Hint;
        
            _exercise2Text.text = text2;
        }

        public void SetCompleted()
        {
            _completedCheckmark.SetActive(true);
        
            _exercise1Toggle.isOn = true;
            _exercise2Toggle.isOn = true;
        
            _exercise1Toggle.interactable = false;
            _exercise2Toggle.interactable = false;
        
            _exercisesBg.SetActive(false);
            _completedBg.SetActive(true);
        }

        public void SetLocked()
        {
            _exercise1Toggle.interactable = false;
            _exercise2Toggle.interactable = false;
        
            _dayImage.color = _inactiveColor;
            _exercisesImage.color = _inactiveColor;
        }

        public void ClearExercise1()
        {
            OnExercise1Cleared?.Invoke();
            _exercise1Toggle.interactable = false;

            if (_exercise2Toggle.isOn)
            {
                SetCompleted();
                _completedText.text = "COMPLETED!\nCOME BACK TOMORROW!";
            }
        }
    
        public void ClearExercise2()
        {
            OnExercise2Cleared?.Invoke();
            _exercise2Toggle.interactable = false;
        
            if (_exercise1Toggle.isOn)
            {
                SetCompleted();
                _completedText.text = "COMPLETED!\nCOME BACK TOMORROW!";
            }
        }
    }
}
