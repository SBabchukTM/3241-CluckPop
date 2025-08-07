using System;
using Runtime.Game.Services;
using Runtime.Game.Services.UserData.Data;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Runtime.Game.UI
{
    public class MenuScreenEnabler : MonoBehaviour
    {
        [SerializeField] private Button _upperButton;
        [SerializeField] private Button _coreButton;
        [SerializeField] private Button _lowerButton;
    
        [SerializeField] private MenuProgramCanvas _upperCanvas;
        [SerializeField] private MenuProgramCanvas _coreCanvas;
        [SerializeField] private MenuProgramCanvas _lowerCanvas;
        private MenuProgramCanvas _activeCanvas;
    
        [Inject]
        private ProgramsService _programsService;

        public event Action<ProgramType> OnPageChanged;

        private void Awake()
        {
            _upperButton.onClick.AddListener(() =>
            {
                ChangePage(_upperCanvas);
                OnPageChanged?.Invoke(ProgramType.Upper);
            });
            _coreButton.onClick.AddListener(() =>
            {
                ChangePage(_coreCanvas);
                OnPageChanged?.Invoke(ProgramType.Core);
            });
            _lowerButton.onClick.AddListener(() =>
            {
                ChangePage(_lowerCanvas);
                OnPageChanged?.Invoke(ProgramType.Lower);
            });
        }

        public void ShowStartScreen(ProgramType type)
        {
            switch (type)
            {
                case ProgramType.Upper:
                    _upperCanvas.Show();
                    _activeCanvas = _upperCanvas;
                    break;
                case ProgramType.Core:
                    _coreCanvas.Show();
                    _activeCanvas = _coreCanvas;
                    break;
                case ProgramType.Lower:
                    _lowerCanvas.Show();
                    _activeCanvas = _lowerCanvas;
                    break;
            }
        }
    

        private void ChangePage(MenuProgramCanvas newCanvas)
        {
            if(newCanvas == _activeCanvas)
                return;

            _activeCanvas.Hide();
            newCanvas.Show();
        
            _activeCanvas = newCanvas;
        }
    }
}
