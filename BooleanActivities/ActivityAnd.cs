using System;
using System.Activities;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UiPathTeam.BooleanActivities
{
    public sealed class ActivityAnd : NativeActivity<bool>
    {
        [Browsable(false)]
        public Collection<Activity<bool>> ChildActivities { get; set; }

        

        public ActivityAnd()
            : base()
        {
            ChildActivities = new Collection<Activity<bool>>();
            
        }

        protected override void CacheMetadata(NativeActivityMetadata metadata)
        { 
            base.CacheMetadata(metadata);

            Collection<Activity> children = new Collection<Activity>();
            foreach (Activity<bool> child in ChildActivities) {
                children.Add(child);
            }
            metadata.SetChildrenCollection(children);
        }

        protected override void Execute(NativeActivityContext context)
        {

            this.Result.Set(context, true);
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
                this.Result.Set(context, false);
            }
        }
    }
}
