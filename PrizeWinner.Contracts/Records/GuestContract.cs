using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrizeWinner.Contracts.Records
{
    public record GuestContract(string userEmail,string firstName,int promotionGroupID);
}
