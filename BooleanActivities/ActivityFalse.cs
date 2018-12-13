using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UiPathTeam.BooleanActivities
{
    public sealed class ActivityFalse: CodeActivity<bool>
    {
        protected override bool Execute(CodeActivityContext context)
        {
            return false;
        }
    }
}
