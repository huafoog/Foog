﻿namespace System.Collections.Generic
{
    /// <summary>
    /// 集合扩展方法
    /// </summary>
    public static class CollectionExtensions
    {
        /// <summary>
        /// 如果条件成立，添加项
        /// </summary>
        public static void AddIf<T>(this ICollection<T> collection, T value, bool flag)
        {
            if (flag)
            {
                collection.Add(value);
            }
        }

        /// <summary>
        /// 如果条件成立，添加项
        /// </summary>
        public static void AddIf<T>(this ICollection<T> collection, T value, Func<bool> func)
        {
            if (func())
            {
                collection.Add(value);
            }
        }

        /// <summary>
        /// 如果不存在，添加项
        /// </summary>
        public static void AddIfNotExist<T>(this ICollection<T> collection, T value, Func<T, bool> existFunc = null)
        {
            bool exists = existFunc == null ? collection.Contains(value) : existFunc(value);
            if (!exists)
            {
                collection.Add(value);
            }
        }

        /// <summary>
        /// 如果不为空，添加项
        /// </summary>
        public static void AddIfNotNull<T>(this ICollection<T> collection, T value) where T : class
        {
            if (value != null)
            {
                collection.Add(value);
            }
        }

        /// <summary>
        /// 获取对象，不存在对使用委托添加对象
        /// </summary>
        public static T GetOrAdd<T>(this ICollection<T> collection, Func<T, bool> selector, Func<T> factory)
        {
            T item = collection.FirstOrDefault(selector);
            if (item == null)
            {
                item = factory();
                collection.Add(item);
            }

            return item;
        }

        /// <summary>
        /// 判断集合是否为null或空集合
        /// </summary>
        public static bool IsNullOrEmpty<T>(this ICollection<T> collection)
        {
            return collection == null || collection.Count == 0;
        }

        /// <summary>
        /// 根据指定数量进行分块
        /// </summary>
        /// <typeparam name="T">模型</typeparam>
        /// <param name="list">列表</param>
        /// <param name="blockSize">分块数量</param>
        /// <returns></returns>
        public static List<List<T>> GetBlockList<T>(List<T> list, int blockSize = 10)
        {
            List<List<T>> result = new List<List<T>>();
            var count = Math.Ceiling(Convert.ToDecimal(list.Count) / blockSize);
            for (int i = 0; i < count; i++)
            {
                List<T> small = list.Skip(i * blockSize).Take(blockSize).ToList();
                result.Add(small);
            }
            return result;
        }
    }
}