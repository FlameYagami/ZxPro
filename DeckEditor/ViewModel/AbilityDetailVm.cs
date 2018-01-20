﻿using System.Collections.ObjectModel;
using Common;
using Wrapper.Model;
using BaseModel = Wrapper.Model.BaseModel;

namespace DeckEditor.ViewModel
{
    public class AbilityDetailVm : BaseModel
    {
        public AbilityDetailVm(ObservableCollection<AbilityModel> abilityDetailModels)
        {
            AbilityDetailModels = abilityDetailModels;
        }

        public ObservableCollection<AbilityModel> AbilityDetailModels { get; set; }

        public void Update()
        {
            OnPropertyChanged(nameof(AbilityDetailModels));
        }
    }
}