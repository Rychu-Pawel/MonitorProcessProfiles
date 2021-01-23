using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MonitorProcessProfiles.Extensions
{
    public static class PropertyChangedEventHandlerExtensions
    {
        public static bool ChangeAndNotify<T>(this PropertyChangedEventHandler handler, ref T field, T value, Expression<Func<T>> memberExpression)
        {
            //Check expressionn
            if (memberExpression == null)
            {
                throw new ArgumentNullException("memberExpression");
            }

            //Check expression body
            var body = memberExpression.Body as MemberExpression;

            if (body == null)
            {
                throw new ArgumentException("Lambda must return a property.");
            }

            //Check if value changed
            if (!EqualityComparer<T>.Default.Equals(field, value))
            {
                //Set value
                field = value;

                //Notify
                var vmExpression = body.Expression as ConstantExpression;

                if (vmExpression != null)
                {
                    LambdaExpression lambda = Expression.Lambda(vmExpression);
                    Delegate vmFunc = lambda.Compile();
                    object sender = vmFunc.DynamicInvoke();

                    if (handler != null)
                    {
                        handler(sender, new PropertyChangedEventArgs(body.Member.Name));

                        return true;
                    }
                }
                
            }

            return false;
        }
    }
}
