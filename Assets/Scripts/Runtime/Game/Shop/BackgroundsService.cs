using Runtime.Game.Services.UserData;

namespace Runtime.Game.Shop
{
    public class BackgroundsService
    {
        private readonly SavedDataRetrieveService _savedDataRetrieveService;
        
        public BackgroundsService(SavedDataRetrieveService savedDataRetrieveService)
        {
            _savedDataRetrieveService = savedDataRetrieveService;
        }

        public int GetSelectedId() => _savedDataRetrieveService.GetUserData().BackgroundsData.SelectedId;
        public void AddPurchasedId(int id) => _savedDataRetrieveService.GetUserData().BackgroundsData.PurchasedIds.Add(id);
        public bool IsPurchased(int id) => _savedDataRetrieveService.GetUserData().BackgroundsData.PurchasedIds.Contains(id);
        public void SetSelectedId(int id) => _savedDataRetrieveService.GetUserData().BackgroundsData.SelectedId = id;
    }
}