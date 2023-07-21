using System;
using System.Collections.Generic;
using System.Text;

namespace DIME.Model
{
    public class GroupedAccount : List<Account>
    {
        public string GroupKey { get; private set; }

        public GroupedAccount(string groupKey, List<Account> accounts) : base(accounts)
        {
            GroupKey = groupKey;
        }
    }

}
