using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.Activities.Statements;
using System.ComponentModel;
using System.Windows.Markup;
using System.Activities.Expressions;

namespace UiPathTeam.BooleanActivities
{

    public sealed class ActivityIf : NativeActivity<bool>
    {
        [RequiredArgument]
        [DefaultValue(null)]
        [Browsable(false)]
        public Activity<bool> Condition {
            get; set;
        }
        
        [DefaultValue(null)]
        [DependsOn("Condition")]
        [Browsable(false)]
        public Activity Then { get; set; }

        [DefaultValue(null)]
        [DependsOn("Condition")]
        [Browsable(false)]
        public Activity Else { get; set; }
        
        public Type AllowedItemType { get; set; }

        public ActivityIf()
            : base()
        {
            AllowedItemType = typeof(bool);
        }

        protected override void Execute(NativeActivityContext context)
        {
            context.ScheduleActivity<bool>(Condition, new CompletionCallback<bool>(OnCompleted));
        }

        private void OnCompleted(NativeActivityContext context, ActivityInstance instance, bool result)
        {
           
            Result.Set(context, result);
            if (result)
            {
                if (Then != null)
                {
                    context.ScheduleActivity(Then);
                }
            }
            else if (Else != null)
            {
                context.ScheduleActivity(Else);
            }
        }
    }
}
