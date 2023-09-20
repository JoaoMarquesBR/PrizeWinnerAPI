using PrizeWinner.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrizeWinner.Contracts.Responses
{
    public class GroupResponse
    {
        public int PromotionGroupId { get; set; }

        public string? GroupName { get; set; }

        public DateTime? CreatedDate { get; set; }

        public List<Item> itemList { get; set; }
 
    }
}
