using System;
using Runtime.Game.Services.UserData.Data;

namespace Runtime.Game.Services.UserData
{
    public class UserBalanceService
    {
        private readonly SavedDataRetrieveService _savedDataRetrieveService;

        public event Action<int> OnBalanceChanged;
        
        public UserBalanceService(SavedDataRetrieveService savedDataRetrieveService)
        {
            _savedDataRetrieveService = savedDataRetrieveService;
        }

        public int GetUserBalance() => GetData().Value;
        public void AddBalance(int value)
        {
            GetData().Value += value;
            OnBalanceChanged?.Invoke(GetUserBalance());
        }

        private UserBalanceData GetData() => _savedDataRetrieveService.GetUserData().UserBalanceData;
    }
}