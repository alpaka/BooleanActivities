using System;
using System.Activities;
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
    public partial class ActivityAndDesigner
    {
        public ActivityAndDesigner()
            : base()
        {
            InitializeComponent();
            wfItemPresenter.AllowedItemType = typeof(Activity<bool>);

        }
    }
}
