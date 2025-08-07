using System;
using DG.Tweening;
using Runtime.Game.Services;
using Runtime.Game.Services.UI;
using Runtime.Game.Services.UserData;
using Runtime.Game.Services.UserData.Data;
using Runtime.Game.UI.Popup;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Runtime.Game.UI
{
    public class MenuProgramCanvas : MonoBehaviour
    {
        private const float AnimTime = 0.33f;
        [SerializeField] private ProgramType _programType;
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private CanvasGroup _lockCanvas;
        [SerializeField] private Button _unlockButton;
        [SerializeField] private Button _newProgramButton;
        [SerializeField] private Button _exercisesButtonButton;
        [SerializeField] private TextMeshProUGUI _programText;
        [SerializeField] private TextMeshProUGUI _programName;
        [SerializeField] private Image _chickenImage;
        [SerializeField] private TextMeshProUGUI _priceText;
        [SerializeField] private GameObject _priceGo;
        [SerializeField] private GameObject _freeGo;
    
        private Sequence _sequence;
    
        [Inject]
        private ProgramsService _programsService;
    
        [Inject]
        private IGameUiService _gameUiService;
    
        [Inject]
        private UserBalanceService _userBalanceService;

        public event Action OnProgramPressed;
        public event Action OnExercisesPressed;

        private void Awake()
        {
            _programName.text = _programType.ToString();
        
            _newProgramButton.onClick.AddListener(() => OnProgramPressed?.Invoke());
            _exercisesButtonButton.onClick.AddListener(() => OnExercisesPressed?.Invoke());
        
            _unlockButton.onClick.AddListener( async () =>
            {
                var popup = await _gameUiService.ShowPopup(ConstPopups.PurchaseProgramPopup) as PurchaseProgramPopup;
                int price = _programsService.GetProgramPrice();
                popup.SetData(price, _programType.ToString());
                popup.OnPurchased += () =>
                {
                    if (_userBalanceService.GetUserBalance() < price)
                    {
                        popup.ShowError();
                        return; 
                    }

                    popup.DestroyPopup();
                    _userBalanceService.AddBalance(-price);
                    _newProgramButton.gameObject.SetActive(true);
                    _programsService.UnlockProgram(_programType);

                    _lockCanvas.alpha = 0;
                    _lockCanvas.interactable = false;
                    _lockCanvas.blocksRaycasts = false;
                };
            });
        }

        public void Show()
        {
            _sequence?.Kill();
            _sequence = DOTween.Sequence();

            _canvasGroup.interactable = true;
            _canvasGroup.blocksRaycasts = true;
        
            bool locked = _programsService.IsLockedProgram(_programType);
            float lockAlpha = locked ? 1f : 0f;
            _lockCanvas.interactable = locked;
            _lockCanvas.blocksRaycasts = locked;

            _sequence.Append(_lockCanvas.DOFade(lockAlpha, AnimTime));
            _sequence.Join(_canvasGroup.DOFade(1, AnimTime));

            if (locked)
            {
                _unlockButton.gameObject.SetActive(true);
                int price = _programsService.GetProgramPrice();
            
                if(price == 0)
                    _freeGo.SetActive(true);
                else
                {
                    _priceText.text = price.ToString();
                    _freeGo.SetActive(false);
                    _priceGo.SetActive(true);
                }
            }

            TryShowUnlockedData(locked);
        }

        public void Hide()
        {
            _sequence?.Kill();
            _sequence = DOTween.Sequence();
        
            _canvasGroup.interactable = false;
            _canvasGroup.blocksRaycasts = false;
        
            _lockCanvas.interactable = false;
            _lockCanvas.blocksRaycasts = false;

            _sequence.Append(_lockCanvas.DOFade(0, AnimTime));
            _sequence.Join(_canvasGroup.DOFade(0, AnimTime));
        }

        private void TryShowUnlockedData(bool locked)
        {
            int programDays = _programsService.GetDaysTrained(_programType);
        
            bool active = _programsService.IsProgramActive(_programType);

            if (!active)
            {
                _programText.gameObject.SetActive(false);
                _newProgramButton.gameObject.SetActive(!locked);
                _exercisesButtonButton.gameObject.SetActive(false);
                _chickenImage.gameObject.SetActive(false);
                return;
            }
        
            _programText.gameObject.SetActive(true);
            _newProgramButton.gameObject.SetActive(false);
            _chickenImage.gameObject.SetActive(true);
            _exercisesButtonButton.gameObject.SetActive(true);
            _programText.text = $"Day {programDays + 1}\n{_programType.ToString()}";
            _chickenImage.sprite = _programsService.GetChickenSprite(_programType);
        }
    }
}
