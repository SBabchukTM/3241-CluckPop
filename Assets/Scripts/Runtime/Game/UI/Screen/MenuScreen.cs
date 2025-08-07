using System;
using Runtime.Game.Services.UserData.Data;
using UnityEngine;
using UnityEngine.UI;

namespace Runtime.Game.UI.Screen
{
    public class MenuScreen : UiScreen
    {
        [SerializeField] private Button _profileButton;
        [SerializeField] private Button _settingsButton;
        [SerializeField] private Image _chickenStatusImage;
        [SerializeField] private Button _collectionButton;
        [SerializeField] private Button _achievementsButton;
        [SerializeField] private Button _shopButton;
        [SerializeField] private MenuProgramCanvas _upperCanvas;
        [SerializeField] private MenuProgramCanvas _coreCanvas;
        [SerializeField] private MenuProgramCanvas _lowerCanvas;
        [SerializeField] private MenuScreenEnabler _menuScreenEnabler;
        
        public event Action OnProfilePressed;
        public event Action OnSettingsPressed;
        public event Action OnCollectionPressed;
        public event Action OnAchievementsPressed;
        public event Action OnShopPressed;
        
        public event Action<ProgramType> OnProgramPressed;
        public event Action<ProgramType> OnExercisesPressed;
        public event Action<ProgramType> OnPageChanged;
        
        public void Initialize()
        {
            _profileButton.onClick.AddListener(() => OnProfilePressed?.Invoke());
            _settingsButton.onClick.AddListener(() => OnSettingsPressed?.Invoke());
            _collectionButton.onClick.AddListener(() => OnCollectionPressed?.Invoke());
            _achievementsButton.onClick.AddListener(() => OnAchievementsPressed?.Invoke());
            _shopButton.onClick.AddListener(() => OnShopPressed?.Invoke());

            _upperCanvas.OnProgramPressed += () => OnProgramPressed?.Invoke(ProgramType.Upper);
            _coreCanvas.OnProgramPressed += () => OnProgramPressed?.Invoke(ProgramType.Core);
            _lowerCanvas.OnProgramPressed += () => OnProgramPressed?.Invoke(ProgramType.Lower);
            
            _upperCanvas.OnExercisesPressed += () => OnExercisesPressed?.Invoke(ProgramType.Upper);
            _coreCanvas.OnExercisesPressed += () => OnExercisesPressed?.Invoke(ProgramType.Core);
            _lowerCanvas.OnExercisesPressed += () => OnExercisesPressed?.Invoke(ProgramType.Lower);
            
            _menuScreenEnabler.OnPageChanged += pageType => OnPageChanged?.Invoke(pageType);
        }

        public void SetStartingCanvas(ProgramType type) => _menuScreenEnabler.ShowStartScreen(type);
    }
}