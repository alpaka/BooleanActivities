using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace UiPathTeam.BooleanActivities
{

    public sealed class ActivityNot : NativeActivity<bool>
    {
        [Browsable(false)]
        public Collection<Activity<bool>> ChildActivities { get; set; }



        public ActivityNot()
            : base()
        {
            ChildActivities = new Collection<Activity<bool>>();

        }

        protected override void CacheMetadata(NativeActivityMetadata metadata)
        {
            base.CacheMetadata(metadata);

            Collection<Activity> children = new Collection<Activity>();
            foreach (Activity<bool> child in ChildActivities)
            {
                children.Add(child);
            }
            metadata.SetChildrenCollection(children);
        }

        protected override void Execute(NativeActivityContext context)
        {

            this.Result.Set(context, false);
            CompletionCallback<bool> onChildComplete = new CompletionCallback<bool>(OnChildComplete);
            foreach (var act in ChildActivities)
            {
                context.ScheduleActivity(act, onChildComplete);
            }
        }

        private void OnChildComplete(NativeActivityContext context, ActivityInstance completedInstance, bool result)
        {
            if (!result)
            {
                context.CancelChildren();
                this.Result.Set(context, true);
            }
        }
    }


}
