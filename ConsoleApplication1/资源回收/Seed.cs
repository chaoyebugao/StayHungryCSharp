using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.资源回收
{
    public class Seed : IDisposable
    {
        /// <summary>
        /// 是否已释放
        /// </summary>
        private bool disposed = false;

        private IDbConnection dbConnection;
        private string sql;
        private object parameters;

        /// <summary>
        /// 数据库连接，非托管资源
        /// </summary>
        public IDbConnection DbConnection => dbConnection;

        public string Sql => sql;

        private object Parameters => parameters;

        public Seed(string connectionString, string sql, object parameters)
        {
            this.dbConnection = new SqlConnection(connectionString);
            this.sql = sql;
            this.parameters = parameters;
        }

        public Seed(IDbConnection dbConnection, string sql, object parameters)
        {
            this.dbConnection = dbConnection;
            this.sql = sql;
            this.parameters = parameters;
        }

        /// <summary>
        /// 由垃圾回收器调用，释放非托管资源
        /// 如果没有引用非托管资源就不需要显示声明析构函数，会造成性能问题，系统会自动生成默认析构函数
        /// </summary>
        ~Seed()
        {
            //GC调用，终结
            //释放非托管资源
            //此处只需要释放非托管代码即可，因为GC调用时该对象资源可能还不需要释放
            Dispose(false);
        }

        /// <summary>
        /// 实现接口方法
        /// 由类的使用者，在外部显式调用，释放类资源
        /// </summary>
        public void Dispose()
        {
            // 释放托管和非托管资源
            Dispose(true);

            //将对象从垃圾回收器链表中移除，
            //从而在垃圾回收器工作时，只释放托管资源，而不执行此对象的析构函数
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// 参数为true表示释放所有资源，只能由使用者调用
        /// 参数为false表示释放非托管资源，只能由垃圾回收器自动调用
        /// 如果子类有自己的非托管资源，可以重载这个函数，添加自己的非托管资源的释放
        /// 但是要记住，重载此函数必须保证调用基类的版本，以保证基类的资源正常释放
        /// </summary>
        /// <param name="disposing">是否释放所有资源，否则只释放非托管资源</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                //如果资源未释放 这个判断主要用了防止对象被多次释放
                return;
            }

            if (disposing)
            {
                // 释放托管资源
                sql = null;
                parameters = null;
            }

            //释放非托管资源/大对象
            DbConnection.Dispose();

            // 标识此对象已释放
            disposed = true;
        }
    }
}
