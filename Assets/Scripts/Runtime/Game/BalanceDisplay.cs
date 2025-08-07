using Runtime.Game.Services.UserData;
using TMPro;
using UnityEngine;
using Zenject;

namespace Runtime.Game
{
    public class BalanceDisplay : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _balanceText;
    
        [Inject]
        private UserBalanceService _userBalanceService;

        private void Awake()
        {
            _balanceText.text = _userBalanceService.GetUserBalance().ToString();
            _userBalanceService.OnBalanceChanged += UpdateBalance;
        }

        private void OnDestroy()
        {
            _userBalanceService.OnBalanceChanged -= UpdateBalance;
        }

        private void UpdateBalance(int obj)
        {
            _balanceText.text = obj.ToString();
        }
    }
}
