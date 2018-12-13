using System;
using System.Activities;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UiPathTeam.BooleanActivities
{
    public class VBExpression<T> : CodeActivity<T>
    {
        [RequiredArgument]
        [DefaultValue(null)]
        public InArgument<T> Expression
        {
            get;
            set;
        }

        protected override T Execute(CodeActivityContext context)
        {
            return Expression.Get(context);
        }
        
    }
    
}
