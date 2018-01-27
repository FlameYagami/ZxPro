﻿using System;
using Refit;

namespace CardCrawler.Api
{
    public interface IRequestService
    {
        [Get("/card")]
        IObservable<object> GetCardList(int fwcn, int fwil, int fwct, int fwft, string pn);
    }
}