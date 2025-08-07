using System;
using System.Collections.Generic;
using Runtime.Game.Services;
using Runtime.Game.Services.UserData.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Runtime.Game.UI.Screen
{
    public class CollectionScreen : UiScreen
    {
        [SerializeField] private Button _backButton;

        [SerializeField, Space] private Button _exerciseTypeButton;
        [SerializeField] private Button _chickenTypeButton;
        [SerializeField] private CollectionPage _typeSelectPage;
        
        [SerializeField, Space] private Button _upperButton;
        [SerializeField] private Button _coreButton;
        [SerializeField] private Button _lowerButton;
        [SerializeField] private CollectionPage _exercisesPage;

        [SerializeField, Space] private RectTransform _exercisesContent;
        [SerializeField] private CollectionPage _exerciseTypePage;
        
        [SerializeField, Space] private TextMeshProUGUI _exercisesDatabaseHeader;
        [SerializeField] private TextMeshProUGUI _exerciseDescText;
        [SerializeField] private TextMeshProUGUI _exerciseNameText;
        [SerializeField] private CollectionPage _exerciseDescPage;

        [SerializeField, Space] private Button _eggCollectionButton;
        [SerializeField] private Button _chickenCollectionButton;
        [SerializeField] private Button _henCollectionButton;
        [SerializeField] private CollectionPage _chickenTypePage;

        [SerializeField, Space] private RectTransform _collectionContent;
        [SerializeField] private CollectionPage _chickenCollectionPage;

        private List<CollectionPage> _pagesHistory = new ();

        [SerializeField] private TextMeshProUGUI _chickCollectionText;
        [SerializeField] private List<ExerciseSelectButton> _exerciseSelectButtons;
        [SerializeField] private List<ChickenColectionDisplay> _chickens;
        
        public event Action OnBackPressed;
        
        [Inject]
        private ProgramsService _programsService;
        
        [Inject]
        private ChickenCollectionProvider _chickenCollectionProvider;
        
        public void Initialize()
        {
            _pagesHistory.Add(_typeSelectPage);
            SubscribeEvents();
        }
        
        private void SubscribeEvents()
        {
            _backButton.onClick.AddListener(Return);
            
            _exerciseTypeButton.onClick.AddListener(() => OpenNewPage(_exerciseTypePage));
            
            _upperButton.onClick.AddListener(() => OpenExerciseDatabasePage(ProgramType.Upper));
            _coreButton.onClick.AddListener(() => OpenExerciseDatabasePage(ProgramType.Core));
            _lowerButton.onClick.AddListener(() => OpenExerciseDatabasePage(ProgramType.Lower));
            
            _chickenTypeButton.onClick.AddListener(() => OpenNewPage(_chickenTypePage));
            
            _eggCollectionButton.onClick.AddListener(() => OpenChickenCollectionPage(ChickenType.Egg));
            _chickenCollectionButton.onClick.AddListener(() => OpenChickenCollectionPage(ChickenType.Chicken));
            _henCollectionButton.onClick.AddListener(() => OpenChickenCollectionPage(ChickenType.SuperHen));

            for (int i = 0; i < _exerciseSelectButtons.Count; i++)
                _exerciseSelectButtons[i].OnClicked += OpenDescriptionPage;
        }

        private void OpenDescriptionPage(string name, string description)
        {
            _exerciseDescText.text = description;
            _exerciseNameText.text = name;
            
            OpenNewPage(_exerciseDescPage);
        }

        private void OpenExerciseDatabasePage(ProgramType type)
        {
            _exercisesDatabaseHeader.text = type.ToString().ToUpper();
            var database = _programsService.GetExercises(type);
            for (int i = 0; i < database.Count; i++) 
                _exerciseSelectButtons[i].SetData(database[i]);
            
            OpenNewPage(_exercisesPage);
        }

        private void OpenChickenCollectionPage(ChickenType chickenType)
        {
            switch (chickenType)
            {
                case ChickenType.SuperHen:
                    _chickCollectionText.text = "HENS";
                    break;
                case ChickenType.Egg:
                    _chickCollectionText.text = "EGGS";
                    break;
                case ChickenType.Chicken:
                    _chickCollectionText.text = "CHICKENS";
                    break;
            }
            _chickenCollectionProvider.SetUnlockData(_chickens, chickenType);
            OpenNewPage(_chickenCollectionPage);
        }
        
        private void OpenNewPage(CollectionPage newPage)
        {
            _pagesHistory[^1].Hide();
            _pagesHistory.Add(newPage);
            _pagesHistory[^1].Show();
        }
        
        private void Return()
        {
            if (_pagesHistory.Count == 1)
            {
                OnBackPressed?.Invoke();
                return;
            }
            
            _pagesHistory[^1].Hide();
            _pagesHistory.RemoveAt(_pagesHistory.Count - 1);
            _pagesHistory[^1].Show();
        }
    }
}