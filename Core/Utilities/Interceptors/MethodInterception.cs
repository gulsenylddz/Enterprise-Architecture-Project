﻿using Castle.DynamicProxy;

namespace Core.Utilities.Interceptors
{
    public partial class Class1
    {
        public abstract class MethodInterception : MethodInterceptionBaseAttribute
        {

            // InVocation --> Business Metodu.
            protected virtual void OnBefore(IInvocation invocation) { }
            protected virtual void OnAfter(IInvocation invocation) { }
            protected virtual void OnException(IInvocation invocation, System.Exception e) { }
            protected virtual void OnSuccess(IInvocation invocation) { }
            public override void Intercept(IInvocation invocation)
            {
                var isSuccess = true;
                OnBefore(invocation);
                try
                {
                    invocation.Proceed();
                }
                catch (Exception e)
                {
                    isSuccess = false;
                    OnException(invocation, e);
                    throw;
                }
                finally
                {
                    if (isSuccess)
                    {
                        OnSuccess(invocation);
                    }
                }
                OnAfter(invocation);
            }
        }
    }
}
