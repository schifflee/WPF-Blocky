﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScratchNet
{

    public class WaitStatement : Statement
    {
        public Expression Duration { get; set; }
        public string ReturnType
        {
            get { return "void"; }
        }
        public Completion Execute(ExecutionEnvironment enviroment)
        {
            return Completion.Void;
        }

        public Descriptor Descriptor
        {
            get
            {
                Descriptor desc = new Descriptor();
                desc.Add(new TextItemDescriptor(this, "Wait for "));
                desc.Add(new ExpressionDescriptor(this, "Duration", "number"));
                desc.Add(new TextItemDescriptor(this, " seconds"));
                return desc;
            }
        }
        public string Type
        {
            get
            {
                return "WaitExpression";
            }
        }


        public BlockDescriptor BlockDescriptor
        {
            get { return null; }
        }
        public bool IsClosing
        {
            get { return false; }
        }
        //execution
        DateTime startWaitTime;

        public ExecutionEnvironment StartCall(ExecutionEnvironment e)
        {
            return e;
        }

        public Completion EndCall(ExecutionEnvironment e)
        {
            return Completion.Void;
        }

        public bool PopStack(out object execution, out ExecutionCallback callback, ExecutionEnvironment e)
        {
           
            execution = Duration;
            callback = Callback;
            return false;
        }
        Nullable<DateTime> Callback(object value, object exception, ExecutionEnvironment e)
        {
            startWaitTime = DateTime.Now.AddSeconds(double.Parse(value+""));
            return startWaitTime;
        }
        public bool HandleException(object exception)
        {
            throw new NotImplementedException();
        }
    }
}
