using System;
using ApaGroup.Framework.Basis.Constants;
using ApaGroup.Framework.Basis.Cores.Helpers;

namespace ApaGroup.Framework.Basis.Helpers
{
    public sealed class SafeExecution : HelperBase<ApaGroupFrameworkBasisConstant>
    {
        #region Public Methods

        public static void DoSafe(Action inAction)
        {
            Assistant.SafeExecution.DoSafe(inAction);
        }

        public static void DoSafe<InputType>(Action<InputType> inAction, InputType inInput)
        {
            Assistant.SafeExecution.DoSafe(inAction, inInput);
        }

        public static void DoSafe<Input1Type, Input2Type>(Action<Input1Type, Input2Type> inAction, Input1Type inInput1, Input2Type inInput2)
        {
            Assistant.SafeExecution.DoSafe(inAction, inInput1, inInput2);
        }

        public static OutputType DoSafe<OutputType>(Func<OutputType> inFunction)
        {
            return Assistant.SafeExecution.DoSafe(inFunction);
        }

        public static OutputType DoSafe<InputType, OutputType>(Func<InputType, OutputType> inFunction, InputType inInput)
        {
            return Assistant.SafeExecution.DoSafe(inFunction, inInput);
        }

        public static OutputType DoSafe<Input1Type, Input2Type, OutputType>(Func<Input1Type, Input2Type, OutputType> inFunction, Input1Type inInput1, Input2Type inInput2)
        {
            return Assistant.SafeExecution.DoSafe(inFunction, inInput1, inInput2);
        }

        #endregion
    }
}
