﻿using Mono.Cecil;
using Mono.Cecil.Cil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leox.Injector
{
    public sealed class InjectorArgs
    {
        public MethodDefinition OriginMethod { get; set; }
        public MethodDefinition NewMethod { get; set; }
        public ModuleDefinition Module
        {
            get
            {
                if (OriginMethod != null) return OriginMethod.Module;
                return null;
            }
        }
        /// <summary>
        /// attribute
        /// </summary>
        public VariableDefinition VarMemberInfo { get; set; }
        /// <summary>
        /// MethodAspectArgs
        /// </summary>
        public VariableDefinition VarAspectArgs { get; set; }
        public Instruction HandlerEnd { get; set; }

        /// <summary>
        /// 用于存放attribute变量的结构，调用OnStart, OnEnd()方法使用，本来使用的是栈结构
        /// 但是由于OnEnd，及OnException中都有用到，所以只能改用其他结构
        /// </summary>
        //public Stack<VariableDefinition> VarStack = new Stack<VariableDefinition>();
        public List<VariableDefinition> Attributes = new List<VariableDefinition>();

        public VariableDefinition ReturnValue { get; set; }
        public InjectorArgs() { }
        public InjectorArgs(MethodDefinition method, VariableDefinition varMemberInfo, VariableDefinition varAspectArgs)
        {
            OriginMethod = method;
            VarMemberInfo = varMemberInfo;
            VarAspectArgs = varAspectArgs;
        }

    }
}
