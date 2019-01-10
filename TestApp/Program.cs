using System;
using System.Activities;
using System.Activities.Expressions;
using System.Activities.Statements;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UiPathTeam.BooleanActivities;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Variable<int> testVar = new Variable<int>("TestVar", 1);
            ActivityWhile awh = new ActivityWhile()
            {
                Variables =
                {
                    testVar
                },
            Condition = new VBExpression<bool>
                {
                    Expression = new InArgument<bool>((env) => testVar.Get(env) <= 10)
                },
                Body = new Sequence
                {
                    Activities =
                    {
                        new Assign
                        {
                            To = new OutArgument<int>( testVar),
                            Value = new InArgument<int>((env) => testVar.Get(env) + 1)
                        },
                        new WriteLine
                        {
                            Text = new InArgument<string>((env) => testVar.Get(env).ToString())
                        }
                    }
                }
            };*/


            /*var output = WorkflowInvoker.Invoke(vbe);
            Console.WriteLine(output);*/
            Console.WriteLine("Test");
            Console.ReadLine();
        }
    }
}
