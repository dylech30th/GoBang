using System;
using System.Reflection;

namespace GoBang
{
    public class LeftStep : Attribute
    {
        public int StepX { get; }
        public int StepY { get; }

        public LeftStep(int x, int y)
        {
            StepX = x;
            StepY = y;
        }
    }

    public class RightStep : Attribute
    {
        public int StepX { get; }
        public int StepY { get; }

        public RightStep(int x, int y)
        {
            StepX = x;
            StepY = y;
        }
    }

    public class Validator : IAttributeValidator
    {
        public TResult Validate<T, TCallerType, TResult>(string method, Func<T, TResult> mapper) where T : Attribute
        {
            var methodInfo = typeof(TCallerType).GetMethod(method, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance | BindingFlags.CreateInstance)?.GetCustomAttribute<T>();
            return methodInfo != null ? mapper(methodInfo) : default(TResult);
        }
    }

    public interface IAttributeValidator
    {
        TResult Validate<T, TCallerType, TResult>(string method, Func<T, TResult> mapper) where T : Attribute;
    }
}