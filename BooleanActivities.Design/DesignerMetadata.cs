using System;
using System.Activities.Presentation.Metadata;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UiPathTeam.BooleanActivities.Design
{
    public class DesignerMetadata : IRegisterMetadata
    {
        public void Register()
        {
            var builder = new AttributeTableBuilder();

            RegisterDefaultMetadata(builder, typeof(ActivityIf), typeof(ActivityIfDesigner));
            RegisterDefaultMetadata(builder, typeof(ActivityXOr), typeof(ActivityXOrDesigner));
            RegisterDefaultMetadata(builder, typeof(ActivityAnd), typeof(ActivityAndDesigner));
            RegisterDefaultMetadata(builder, typeof(ActivityOr), typeof(ActivityAndDesigner));
            RegisterDefaultMetadata(builder, typeof(ActivityNot), typeof(ActivityAndDesigner));
            RegisterDefaultMetadata(builder, typeof(ActivityWhile), typeof(ActivityWhileDesigner));
            RegisterDefaultMetadata(builder, typeof(ActivityDoWhile), typeof(ActivityDoWhileDesigner));



            RegisterGenericTypeMetadata(builder, typeof(VBExpression<>), typeof(VBExpressionDesigner));
            RegisterGenericTypeMetadata(builder, typeof(ActivityEquals<>), typeof(ActivityAndDesigner));
            

            // Activities without designer
            RegisterDefaultMetadata(builder, typeof(ActivityTrue));
            RegisterDefaultMetadata(builder, typeof(ActivityFalse));

            MetadataStore.AddAttributeTable(builder.CreateTable());
        }

        public static readonly CategoryAttribute Category = new CategoryAttribute("UiPathTeam.BooleanActivities");

        public static void RegisterDefaultMetadata(AttributeTableBuilder builder, Type activityType, Type designerType)
        {
            builder.AddCustomAttributes(activityType, new DesignerAttribute(designerType), DesignerMetadata.Category);
        }

        public static void RegisterDefaultMetadata(AttributeTableBuilder builder, Type activityType)
        {
            builder.AddCustomAttributes(activityType, DesignerMetadata.Category);
        }

        public static void RegisterGenericTypeMetadata(AttributeTableBuilder builder, Type activityType, Type designerType)
        {
            Type attrType = Type.GetType("System.Activities.Presentation.FeatureAttribute, System.Activities.Presentation, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35");
            Type argType = Type.GetType("System.Activities.Presentation.UpdatableGenericArgumentsFeature, System.Activities.Presentation, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35");
            var genericTypeArgument = Activator.CreateInstance(attrType, new object[] { argType }) as Attribute;

            builder.AddCustomAttributes(activityType, new DesignerAttribute(designerType), DesignerMetadata.Category, genericTypeArgument);
        }
    }
}
