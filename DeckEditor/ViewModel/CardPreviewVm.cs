﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using Wrapper;
using Wrapper.Constant;
using Wrapper.Model;
using Wrapper.Utils;

namespace DeckEditor.ViewModel
{
    public class CardPreviewVm : BaseModel
    {
        private string _cardPreviewCountValue;
        private Enums.PreviewOrderType _previewOrderType;

        public CardPreviewVm()
        {
            CardPreviewModels = new ObservableCollection<CardPreviewModel>();
            PreviewOrderDic = Dic.PreviewOrderDic;
        }

        public Dictionary<Enums.PreviewOrderType, string> PreviewOrderDic { get; set; }

        public string CardPreviewCountValue
        {
            get { return _cardPreviewCountValue; }
            set
            {
                _cardPreviewCountValue = value;
                OnPropertyChanged(nameof(CardPreviewCountValue));
            }
        }

        public ObservableCollection<CardPreviewModel> CardPreviewModels { get; set; }

        public Enums.PreviewOrderType PreviewOrderType
        {
            get { return _previewOrderType; }
            set
            {
                _previewOrderType = value;
                OnPropertyChanged(nameof(PreviewOrderType));
            }
        }

        private DeQueryModel MemoryQueryModel { get; set; }

        public void UpdateCardPreviewList(DeQueryModel queryModel)
        {
            MemoryQueryModel = queryModel; // 保存查询的实例
            var dataSet = new DataSet();
            var sql = DeSqlUtils.GetQuerySql(queryModel, PreviewOrderType);
            DataManager.FillDataToDataSet(dataSet, sql);
            var tempList = CardUtils.GetCardPreviewModels(dataSet);
            CardPreviewModels.Clear();
            tempList.ForEach(CardPreviewModels.Add);
            CardPreviewCountValue = "查询结果:" + CardPreviewModels.Count;
        }

        /// <summary>
        ///     卡牌预览排序事件
        /// </summary>
        public void Order()
        {
            if (null == MemoryQueryModel) return;
            UpdateCardPreviewList(MemoryQueryModel);
        }
    }
}