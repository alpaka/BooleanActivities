using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace UiPathTeam.BooleanActivities
{

    public sealed class ActivityXOr : NativeActivity<bool>
    {
        [Browsable(false)]
        [RequiredArgument]
        public Activity<bool> FirstChild { get; set; }

        [Browsable(false)]
        [RequiredArgument]
        public Activity<bool> SecondChild { get; set; }

        
        protected override void CacheMetadata(NativeActivityMetadata metadata)
        {
            base.CacheMetadata(metadata);
            Collection<Activity> children = new Collection<Activity>();
            children.Add(FirstChild);
            children.Add(SecondChild);
            metadata.SetChildrenCollection(children);
        }

        protected override void Execute(NativeActivityContext context)
        {
            CompletionCallback<bool> onChildComplete = new CompletionCallback<bool>(OnChildComplete);
            context.ScheduleActivity(FirstChild, onChildComplete);
            context.ScheduleActivity(SecondChild, onChildComplete);
            Result.Set(context, false);
        }

        private void OnChildComplete(NativeActivityContext context, ActivityInstance completedInstance, bool result)
        {
            if (result)
            {
                Result.Set(context, !Result.Get(context));
            }
        }
    }
}
