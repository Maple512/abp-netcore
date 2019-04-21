namespace AbpLearning.Common.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using Microsoft.EntityFrameworkCore.Query;
    using Microsoft.EntityFrameworkCore.Query.Internal;
    using Microsoft.EntityFrameworkCore.Storage;

    /// <summary>
    /// 集合扩展
    /// </summary>
    public static class CollectionExtensions
    {
        private static readonly TypeInfo QueryCompilerTypeInfo = typeof(QueryCompiler).GetTypeInfo();

        private static readonly FieldInfo QueryCompilerField = typeof(EntityQueryProvider).GetTypeInfo().DeclaredFields.First(x => x.Name == "_queryCompiler");

        private static readonly FieldInfo QueryModelGeneratorField = QueryCompilerTypeInfo.DeclaredFields.First(x => x.Name == "_queryModelGenerator");

        private static readonly FieldInfo DataBaseField = QueryCompilerTypeInfo.DeclaredFields.Single(x => x.Name == "_database");

        private static readonly PropertyInfo DatabaseDependenciesField = typeof(Database).GetTypeInfo().DeclaredProperties.Single(x => x.Name == "Dependencies");

        

        #region IEnumerable

        /// <summary>
        /// 将集合展开并分别转换成字符串，再以指定的分隔符衔接，拼成一个字符串返回。默认分隔符为逗号
        /// </summary>
        /// <param name="collection">要处理的集合</param>
        /// <param name="separator">分隔符，默认为逗号</param>
        /// <returns>拼接后的字符串</returns>
        public static string ExpandAndToString<T>(this IEnumerable<T> collection, string separator = ",")
        {
            return collection.ExpandAndToString(t => t.ToString(), separator);
        }

        /// <summary>
        /// 循环集合的每一项，调用委托生成字符串，返回合并后的字符串。默认分隔符为逗号
        /// </summary>
        /// <param name="collection">待处理的集合</param>
        /// <param name="itemFormatFunc">单个集合项的转换委托</param>
        /// <param name="separetor">分隔符，默认为逗号</param>
        /// <typeparam name="T">泛型类型</typeparam>
        /// <returns></returns>
        public static string ExpandAndToString<T>(this IEnumerable<T> collection, Func<T, string> itemFormatFunc,
            string separetor = ",")
        {
            collection = collection as IList<T> ?? collection.ToList();
            itemFormatFunc.CheckNotNull(nameof(itemFormatFunc));
            if (!collection.Any())
            {
                return null;
            }
            var sb = new StringBuilder();
            var i = 0;
            var count = collection.Count();
            foreach (var t in collection)
            {
                if (i == count - 1)
                {
                    sb.Append(itemFormatFunc(t));
                }
                else
                {
                    sb.Append(itemFormatFunc(t) + separetor);
                }
                i++;
            }
            return sb.ToString();
        }

        /// <summary>
        ///     集合是否为空
        /// </summary>
        /// <param name="collection"> 要处理的集合 </param>
        /// <typeparam name="T"> 动态类型 </typeparam>
        /// <returns> 为空返回True，不为空返回False </returns>
        public static bool IsEmpty<T>(this IEnumerable<T> collection)
        {
            collection = collection as IList<T> ?? collection.ToList();
            return !collection.Any();
        }

        /// <summary>
        ///     根据第三方条件是否为真来决定是否执行指定条件的查询
        /// </summary>
        /// <param name="source"> 要查询的源 </param>
        /// <param name="predicate"> 查询条件 </param>
        /// <param name="condition"> 第三方条件 </param>
        /// <typeparam name="T"> 动态类型 </typeparam>
        /// <returns> 查询的结果 </returns>
        public static IEnumerable<T> WhereIf<T>(this IEnumerable<T> source, Func<T, bool> predicate, bool condition)
        {
            predicate.CheckNotNull(nameof(predicate));
            source = source as IList<T> ?? source.ToList();

            return condition ? source.Where(predicate) : source;
        }

        /// <summary>
        ///     根据指定条件返回集合中不重复的元素
        /// </summary>
        /// <typeparam name="T">动态类型</typeparam>
        /// <typeparam name="TKey">动态筛选条件类型</typeparam>
        /// <param name="source">要操作的源</param>
        /// <param name="keySelector">重复数据筛选条件</param>
        /// <returns>不重复元素的集合</returns>
        public static IEnumerable<T> DistinctBy<T, TKey>(this IEnumerable<T> source, Func<T, TKey> keySelector)
        {
            keySelector.CheckNotNull(nameof(keySelector));
            source = source as IList<T> ?? source.ToList();

            return source.GroupBy(keySelector).Select(group => group.First());
        }

        #endregion IEnumerable的扩展

        #region List
        /// <summary>
        /// 从指定集合TSource递归出无限级TResult集合、常用于树形数据
        /// </summary>
        /// <typeparam name="TResult">返回的集合类型</typeparam>
        /// <typeparam name="TSource">原始类型</typeparam>
        /// <param name="sources">原始集合数据</param>
        /// <param name="roots">原始根节点数据</param>
        /// <param name="mapper">类型映射mapper</param>
        /// <param name="getchilden">子集合表达式</param>
        /// <param name="chidenway">集合的处理方式</param>
        /// <returns>TResult集合</returns>
        public static ICollection<TResult> RenderTree<TSource, TResult>(this List<TSource> sources,
            List<TSource> roots, Func<TSource, int, TResult> mapper, Func<TSource, List<TSource>
                , List<TSource>> getchilden, Action<TResult, TResult> chidenway) where TResult : new()
        {
            var Items = new List<TResult>();
            var parentnode = default(TResult);
            var level = 0;
            Render(roots, render => categories =>
            {
                foreach (var cat in categories)
                {
                    var item = mapper(cat, level);
                    var childens = getchilden(cat, sources);
                    if (roots.Contains(cat))
                    {
                        parentnode = default;
                        level = 0;
                        Items.Add(item);
                        parentnode = item;
                    }
                    else
                    {
                        chidenway(parentnode, item);
                        if (childens.Count > 0)
                        {
                            level++;
                            parentnode = item;
                        }
                    }
                    render(childens);
                }
            });
            return Items;
        }

        public static ICollection<TResult> RenderTree<TSource, TResult>(this List<TSource> sources,
            List<TSource> roots, Func<TSource, int, TResult> mapper, Func<TSource, List<TSource>
                , List<TSource>> getchilden, Action<TResult, TResult, List<TResult>> chidenway) where TResult : new()
        {
            var Items = new List<TResult>();
            var parentnode = default(TResult);
            var level = 0;
            Render(roots, render => categories =>
            {
                foreach (var cat in categories)
                {
                    var item = mapper(cat, level);
                    var childens = getchilden(cat, sources);
                    if (roots.Contains(cat))
                    {
                        parentnode = default;
                        level = 0;
                        Items.Add(item);
                        parentnode = item;
                    }
                    else
                    {
                        chidenway(parentnode, item, Items);
                        if (childens.Count > 0)
                        {
                            level++;
                            parentnode = item;
                        }
                    }
                    render(childens);
                }
            });
            return Items;
        }

        #endregion

        #region IQueryable

        /// <summary>
        /// IQueryable To Sql String
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="query"></param>
        /// <returns></returns>
        public static string ToSql<TEntity>(this IQueryable<TEntity> query) where TEntity : class
        {
            var queryCompiler = (QueryCompiler)QueryCompilerField.GetValue(query.Provider);
            var modelGenerator = (QueryModelGenerator)QueryModelGeneratorField.GetValue(queryCompiler);
            var queryModel = modelGenerator.ParseQuery(query.Expression);
            var database = (IDatabase)DataBaseField.GetValue(queryCompiler);
            var databaseDependencies = (DatabaseDependencies)DatabaseDependenciesField.GetValue(database);
            var queryCompilationContext = databaseDependencies.QueryCompilationContextFactory.Create(false);
            var modelVisitor = (RelationalQueryModelVisitor)queryCompilationContext.CreateQueryModelVisitor();
            modelVisitor.CreateQueryExecutor<TEntity>(queryModel);
            var sql = modelVisitor.Queries.First().ToString();

            return sql;
        }

        #endregion

        private static Action<T> Fix<T>(Func<Action<T>, Action<T>> f)
        {
            return x => f(Fix(f))(x);
        }

        private static void Render<T>(T model, Func<Action<T>, Action<T>> f)
        {
            Fix(f)(model);
        }
    }
}
