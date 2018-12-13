using System;
using System.Activities;
using System.Activities.Presentation;
using System.Activities.Presentation.Metadata;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UiPathTeam.BooleanActivities.Design
{
    public partial class ActivityIfDesigner : ActivityDesigner
    {

        public ActivityIfDesigner()
        {
            InitializeComponent();
            ConditionPresenter.AllowedItemType = typeof(Activity<bool>);
        }
        
    }
}
