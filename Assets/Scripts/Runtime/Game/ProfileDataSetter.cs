using Runtime.Game.Achievements;
using Runtime.Game.Services.UserData;
using TMPro;
using UnityEngine;
using Zenject;

namespace Runtime.Game
{
    public class ProfileDataSetter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _achievements;
        [SerializeField] private TextMeshProUGUI _upperDays;
        [SerializeField] private TextMeshProUGUI _coreDays;
        [SerializeField] private TextMeshProUGUI _lowerDays;
    
        [Inject]
        private SavedDataRetrieveService _savedDataRetrieveService;

        private void Awake()
        {
            _achievements.text = GetCompletedAchievementsCount(_savedDataRetrieveService.GetUserData().UserAchievementsData).ToString();
            _upperDays.text = _savedDataRetrieveService.GetUserData().UserProgramsData.UpperProgramData.DaysTrained.ToString();
            _coreDays.text = _savedDataRetrieveService.GetUserData().UserProgramsData.CoreProgramData.DaysTrained.ToString();
            _lowerDays.text = _savedDataRetrieveService.GetUserData().UserProgramsData.LowerProgramData.DaysTrained.ToString();
        }

        public int GetCompletedAchievementsCount(UserAchievementsData userAchievements)
        {
            int count = 0;
            var fields = typeof(UserAchievementsData).GetFields();

            foreach (var field in fields)
            {
                if (field.GetValue(userAchievements) is AchievementData achievement)
                {
                    if (achievement.Progress >= achievement.Target)
                        count++;
                }
            }

            return count;
        }
    }
}
