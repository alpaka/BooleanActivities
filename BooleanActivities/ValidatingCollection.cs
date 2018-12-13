using System.Activities;
using System.Collections.ObjectModel;

namespace UiPathTeam.BooleanActivities
{
    internal class ValidatingCollection<T> : Collection<Variable>
    {
        public System.Func<object, object> OnAddValidationCallback { get; set; }
    }
}