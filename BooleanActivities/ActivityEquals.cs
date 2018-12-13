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
    public class ActivityEquals<T> : NativeActivity<bool>
    {
        [Browsable(false)]
        public Collection<Activity<T>> ChildActivities { get; set; }
        

        private Variable<T> firstResult;
        private Variable<bool> isSet;
        


        public ActivityEquals()
            : base()
        {
            firstResult = new Variable<T>();
            isSet = new Variable<bool>();
            ChildActivities = new Collection<Activity<T>>();
        }

        protected override void CacheMetadata(NativeActivityMetadata metadata)
        {
            base.CacheMetadata(metadata);

            Collection<Activity> children = new Collection<Activity>();
            foreach (var child in ChildActivities)
            {
                children.Add(child);
            }
            metadata.SetChildrenCollection(children);
            metadata.AddImplementationVariable(this.firstResult);
            metadata.AddImplementationVariable(this.isSet);
        }

        protected override void Execute(NativeActivityContext context)
        {
            CompletionCallback<T> onChildComplete = new CompletionCallback<T>(OnCompleted);
            foreach (var child in ChildActivities)
            {
                context.ScheduleActivity<T>(child, onChildComplete);
            }
        }

        private void OnCompleted(NativeActivityContext context, ActivityInstance instance, T newResult)
        {
            bool set = isSet.Get(context);
            if (set)
            {
                T res = firstResult.Get(context);
                bool equal;
                if (res != null && newResult != null)
                {
                    equal = newResult.Equals(res);
                } else
                {
                    equal = false;
                }
                Result.Set(context, equal);

                if (!equal)
                {
                    context.CancelChildren();
                }
            } else
            {
                firstResult.Set(context, newResult);
                isSet.Set(context, true);
            }
        }
    }
    
}
