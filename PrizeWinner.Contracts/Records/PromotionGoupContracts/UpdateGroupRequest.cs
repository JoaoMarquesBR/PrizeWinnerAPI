using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrizeWinner.Contracts.Records.PromotionGoupContracts
{
    public record UpdateGroupRequest(
        int groupId,
        string GroupName,
        //DateTime date,
        List<int>? itemsId);

}
