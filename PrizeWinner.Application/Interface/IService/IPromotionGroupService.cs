﻿using PrizeWinner.Contracts.Records;
using PrizeWinner.Contracts.Records.PromotionGoupContracts;
using PrizeWinner.Contracts.Responses;
using PrizeWinner.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrizeWinner.Application.Interface.IRepository
{
    public interface IPromotionGroupService
    {
        Task Add(PromotionGroupContract promotionGroup);

        Task Update(UpdateGroupRequest updateRequest);

        Task<List<GroupResponse>> GetAll();

    }
}
