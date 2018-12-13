using UiPathTeam.BooleanActivities;
using UiPathTeam.BooleanActivities.Design;
using System;
using System.Activities.Core.Presentation;
using System.Activities.Presentation;
using System.Activities.Presentation.Toolbox;
using System.Activities.Statements;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RehostedTestApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private WorkflowDesigner wd;

        public MainWindow()
        {
            InitializeComponent();

            RegisterMetadata();
            AddDesigner();
            AddToolbox();
            AddPropertyInspector();
        }

        private void AddDesigner()
        {
            wd = new WorkflowDesigner();
            Grid.SetColumn(wd.View, 1);
            wd.Load(new Sequence());
            grid1.Children.Add(wd.View);
        }

        private void RegisterMetadata()
        {
            System.Activities.Core.Presentation.DesignerMetadata dm = new System.Activities.Core.Presentation.DesignerMetadata();
            dm.Register();
            UiPathTeam.BooleanActivities.Design.DesignerMetadata myDM = new UiPathTeam.BooleanActivities.Design.DesignerMetadata();
            myDM.Register();
        }

        private ToolboxControl GetToolboxControl()
        {
            ToolboxControl ctrl = new ToolboxControl();

            ToolboxCategory category = new ToolboxCategory("category1");

            ToolboxItemWrapper tool1 = new ToolboxItemWrapper("System.Activities.Statements.Assign", typeof(Assign).Assembly.FullName, null, "Assign");

            ToolboxItemWrapper tool2 = new ToolboxItemWrapper("System.Activities.Statements.Sequence", typeof(Sequence).Assembly.FullName, null, "Sequence");
            ToolboxItemWrapper tool3 = new ToolboxItemWrapper("UiPathTeam.BooleanActivities.ActivityIf", typeof(ActivityIf).Assembly.FullName, null, "ActivityIf");
            ToolboxItemWrapper tool4 = new ToolboxItemWrapper("UiPathTeam.BooleanActivities.ActivityTrue", typeof(ActivityTrue).Assembly.FullName, null, "ActivityTrue");
            ToolboxItemWrapper tool6 = new ToolboxItemWrapper("UiPathTeam.BooleanActivities.ActivityFalse", typeof(ActivityFalse).Assembly.FullName, null, "ActivityFalse");
            ToolboxItemWrapper tool7 = new ToolboxItemWrapper("UiPathTeam.BooleanActivities.ActivityAnd", typeof(ActivityAnd).Assembly.FullName, null, "ActivityAnd");
            ToolboxItemWrapper tool8 = new ToolboxItemWrapper("UiPathTeam.BooleanActivities.VBExpression`1", typeof(VBExpression<>).Assembly.FullName, null, "VBExpression");


            ToolboxItemWrapper tool9 = new ToolboxItemWrapper("UiPathTeam.BooleanActivities.ActivityEquals`1", typeof(ActivityEquals<>).Assembly.FullName, null, "ActivityEquals");


            ToolboxItemWrapper tool10 = new ToolboxItemWrapper("UiPathTeam.BooleanActivities.ActivityWhile", typeof(ActivityWhile).Assembly.FullName, null, "ActivityWhile");

            category.Add(tool1);
            category.Add(tool2);
            category.Add(tool3);
            category.Add(tool4);
            category.Add(tool6);
            category.Add(tool7);
            category.Add(tool8);
            category.Add(tool9);
            category.Add(tool10);

            ToolboxItemWrapper tool5 = new ToolboxItemWrapper(typeof(WriteLine));
            category.Add(tool5);

            ctrl.Categories.Add(category);

            return ctrl;
        }

        private void AddToolbox()
        {
            ToolboxControl tc = GetToolboxControl();
            Grid.SetColumn(tc, 0);
            grid1.Children.Add(tc);
        }

        private void AddPropertyInspector()
        {
            Grid.SetColumn(wd.PropertyInspectorView, 2);
            grid1.Children.Add(wd.PropertyInspectorView);
        }
    }
}
