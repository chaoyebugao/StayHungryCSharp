using ConsoleApp2.Model.Databases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp2.Utility
{
    /// <summary>
    /// 仓库语句
    /// </summary>
    public class RepoUtil
    {
        /// <summary>
        /// 自动增长主键ID语句(MySQL)
        /// </summary>
        public string SqlAutoIncIdentity = "SELECT LAST_INSERT_ID()";
    }

    /// <summary>
    /// 仓库帮助类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class RepoUtil<T> : RepoUtil where T : BaseModel
    {
        /// <summary>
        /// 表名
        /// </summary>
        public static string TableName => typeof(T).Name;

        /// <summary>
        /// 字段集合
        /// </summary>
        public IEnumerable<string> Fields
        {
            get
            {
                return typeof(T).GetProperties().Select(m => m.Name);
            }
        }

        /// <summary>
        /// 排除主键的插入语句
        /// </summary>
        public string InsertSql => GetInsertSql(nameof(BaseModel.Id));

        /// <summary>
        /// 获取插入语句
        /// </summary>
        /// <param name="excludeFields">排除的字段</param>
        /// <returns></returns>
        public string GetInsertSql(params string[] excludeFields)
        {
            var fs = Fields.ToList();
            fs.RemoveAll(m => excludeFields.Contains(m, StringComparer.OrdinalIgnoreCase));

            return $@"INSERT INTO {TableName} ({string.Join(", ", fs)}) VALUES (@{string.Join(", @", fs)})";
        }

        /// <summary>
        /// 获取判断插入语句，排除主键Id
        /// </summary>
        /// <param name="conditions">判断条件</param>
        /// <returns></returns>
        public string GetConditionalInsertBeginSql(string conditions)
        {
            return GetConditionalInsertBeginSql(conditions, nameof(BaseModel.Id));
        }

        /// <summary>
        /// 获取判断插入语句
        /// </summary>
        /// <param name="conditions">判断条件</param>
        /// <param name="excludeFields"></param>
        /// <returns></returns>
        public string GetConditionalInsertBeginSql(string conditions, params string[] excludeFields)
        {
            var fs = Fields.ToList();
            fs.RemoveAll(m => excludeFields.Contains(m, StringComparer.OrdinalIgnoreCase));

            return $@"INSERT INTO {TableName} ({string.Join(", ", fs)}) SELECT @{string.Join(", @", fs)} FROM DUAL WHERE NOT EXISTS (
    SELECT 1 FROM {TableName} WHERE {nameof(BaseModel.IsDeleted)} = 0 AND {conditions}
)";
        }

    }
}
