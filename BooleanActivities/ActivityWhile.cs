using System;
using System.Activities;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace UiPathTeam.BooleanActivities
{


    public class ActivityWhile : NativeActivity
    {

        CompletionCallback onBodyComplete;
        CompletionCallback<bool> onConditionComplete;

        Collection<Variable> variables;

        [RequiredArgument]
        [DefaultValue(null)]
        [DependsOn("Variables")]
        [Browsable(false)]
        public Activity<bool> Condition
        {
            get;
            set;
        }

        [DefaultValue(null)]
        [DependsOn("Condition")]
        [Browsable(false)]
        public Activity Body
        {
            get;
            set;
        }
        
        protected bool IsDoWhile
        {
            get;
            set;
        }

        public ActivityWhile()
            : this(false)
        {
        }

        public ActivityWhile(bool isDoWhile)
            : base()
        {
            IsDoWhile = isDoWhile;
            AllowedItemType = typeof(bool);
        }

        public Type AllowedItemType { get; set; }

        public Collection<Variable> Variables
        {
            get
            {
                if (this.variables == null)
                {
                    this.variables = new Collection<Variable>{};
                }
                return this.variables;
            }
        }

        protected override void CacheMetadata(NativeActivityMetadata metadata)
        {
            metadata.SetVariablesCollection(this.Variables);

            metadata.AddChild(this.Body);
            metadata.AddChild(this.Condition);
        }

        protected override void Execute(NativeActivityContext context)
        {
            if (IsDoWhile)
            {
                ScheduleBody(context);
            } else
            {
                ScheduleCondition(context);
            }
        }

        void ScheduleCondition(NativeActivityContext context)
        {
            if (this.onConditionComplete == null)
            {
                this.onConditionComplete = new CompletionCallback<bool>(OnConditionComplete);
            }

            context.ScheduleActivity(this.Condition, this.onConditionComplete);
        }

        void ScheduleBody(NativeActivityContext context)
        {
            if (this.onBodyComplete == null)
            {
                this.onBodyComplete = new CompletionCallback(OnBodyComplete);
            }
            context.ScheduleActivity(this.Body, this.onBodyComplete);
        }

        void OnConditionComplete(NativeActivityContext context, ActivityInstance completedInstance, bool result)
        {
            if (result)
            {
                if (this.Body != null)
                {
                    ScheduleBody(context);
                }
                else
                {
                    ScheduleCondition(context);
                }
            }
        }

        void OnBodyComplete(NativeActivityContext context, ActivityInstance completedInstance)
        {
            ScheduleCondition(context);
        }
    }
}
