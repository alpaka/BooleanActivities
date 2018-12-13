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
    // Interaction logic for ActivityXOrDesignerxaml.xaml
    public partial class ActivityXOrDesigner
    {
        public ActivityXOrDesigner()
        {
            InitializeComponent();
            FirstPresenter.AllowedItemType = typeof(Activity<bool>);
            SecondPresenter.AllowedItemType = typeof(Activity<bool>);
        }
        
    }
}
