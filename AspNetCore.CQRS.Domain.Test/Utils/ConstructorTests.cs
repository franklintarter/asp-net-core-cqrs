using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCore.CQRS.Domain.Test.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using NUnit.Framework;

    namespace SocialFeed.Domain.Tests.TestUtils
    {
        public class ConstructorTests
        {

            private List<Case> _cases = new List<Case>();

            public ConstructorTests()
            {
            }

            public ConstructorTests Succeed(Action action, string failureMessage)
            {
                _cases.Add(new SuccessCase(action, failureMessage));
                return this;
            }

            public ConstructorTests SucceedsWhenAllInputsAreValid<T>(params object[] validInputs)
            {
                var ctor = GetConstructor<T>(validInputs);
                _cases.Add(new SuccessCase(() => ctor.Invoke(validInputs), "Should succeed when all inputs are valid"));
                return this;
            }

            public ConstructorTests Fail<T>(Action action, string failureMessage)
                where T : Exception
            {
                _cases.Add(new FailureCase<T>(action, failureMessage));
                return this;
            }

            //public CtorTests NoNullParamaetersAllowed<T>(Type[] inputTypes, object[] inputs)
            public ConstructorTests ThrowWhenAnyInputNull_OtherwiseSucceed<T>(params object[] validInputs)
            {
                var ctor = GetConstructor<T>(validInputs);
                validInputs.Each((x, i) =>
                {
                    AddNullInputCase(ctor, i, validInputs.ToList());
                });

                _cases.Add(new SuccessCase(() => ctor.Invoke(validInputs), "Should succeed when all inputs are valid."));
                return this;
            }

            private ConstructorInfo GetConstructor<T>(params object[] inputs)
            {
                var types = inputs.Select(x => x.GetType()).ToArray();
                return typeof(T).GetConstructor(types);
            }

            private void AddNullInputCase(ConstructorInfo ctor, int i, IList<object> parameters)
            {
                parameters[i] = null;
                _cases.Add(new TargetInvocationFailure<ArgumentException>(
                    () => ctor.Invoke(parameters.ToArray()),
                    "Constructor should throw exception with null input."
                ));
            }

            public void Run()
            {
                _cases.ForEach(x => x.Run());
            }
        }

        public static class Helper
        {
            public static void Each<T>(this IEnumerable<T> ie, Action<T, int> action)
            {
                var i = 0;
                foreach (var e in ie) action(e, i++);
            }
        }

        public class TargetInvocationFailure<E> : Case
            where E : Exception
        {
            public TargetInvocationFailure(Action action, string failureMessage) : base(action, failureMessage)
            {
            }

            public override void Run()
            {
                try
                {
                    _action();
                    Assert.Fail(_failureMessage);
                }
                catch (Exception e)
                {
                    if (!(e is TargetInvocationException) && !(e.InnerException is E))
                    {
                        Assert.Fail(_failureMessage);
                    }
                }
            }
        }

        public class FailureCase<T> : Case
            where T : Exception
        {
            public FailureCase(Action action, string failureMessage) : base(action, failureMessage)
            {
            }

            public override void Run()
            {
                Assert.Throws<T>(() => _action(), _failureMessage);
            }
        }

        public class SuccessCase : Case
        {
            public SuccessCase(Action action, string failureMessage) : base(action, failureMessage)
            {
            }

            public override void Run()
            {
                try
                {
                    _action();
                }
                catch (Exception e)
                {
                    Assert.Fail($"Expected success threw an exception {e}. {_failureMessage}");
                }
            }
        }

        public abstract class Case
        {
            protected Action _action;
            protected string _failureMessage;

            public Case(Action action, string failureMessage)
            {
                _action = action;
                _failureMessage = failureMessage;
            }

            public abstract void Run();
        }
    }

}
