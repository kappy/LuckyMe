﻿using System;
using System.Collections.Generic;
using LuckyMe.Core.ViewModels;
using MediatR;

namespace LuckyMe.Core.Business.UserStats
{
    public class GetUserStatistiscsOverview : IAsyncRequest<IList<PerCategoryViewModel<EarningsPerGameViewModel>>>
    {
        public Guid UserId { get; set; }
    }
}
