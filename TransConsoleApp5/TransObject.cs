using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Lfg.Pms.Code
{
    public static class TransObj<TIn, TOut> where TOut:new()
    {
        private static readonly Func<TIn, TOut> cache = GetFunc();
        /// <summary>
        /// 将Domain类型转换为Dto数据类型,只转换具有的属性。
        /// </summary>
        /// <returns></returns>
        private static Func<TIn, TOut> GetFunc()
        {
            //参数表达式
            ParameterExpression parameterExpression = Expression.Parameter(typeof(TIn), "p");
            List<MemberBinding> memberBindingList = new List<MemberBinding>();
            var tInPropertier = typeof(TIn).GetProperties();
            foreach (var item in typeof(TOut).GetProperties())
            {
                if (!item.CanWrite || !tInPropertier.Any(p=>p.Name == item.Name))
                    continue;
                MemberExpression property = Expression.Property(parameterExpression, tInPropertier.First(p=>p.Name==item.Name));
                MemberBinding memberBinding = Expression.Bind(item, property);
                memberBindingList.Add(memberBinding);
            }

            MemberInitExpression memberInitExpression = Expression.MemberInit(Expression.New(typeof(TOut)), memberBindingList.ToArray());
            Expression<Func<TIn, TOut>> lambda = Expression.Lambda<Func<TIn, TOut>>(memberInitExpression, new ParameterExpression[] { parameterExpression });

            return lambda.Compile();
        }

        public static TOut Trans(TIn tIn)
        {
            return cache(tIn);
        }
    }

}       
