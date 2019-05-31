using ConsoleApp2.Utility;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ConsoleApp2.Data.DistributedRepositories._2PC
{
    /// <summary>
    /// 更详细Dispose使用见<see cref="ConsoleApplication1.资源回收.Seed"/>
    /// </summary>
    public sealed class 自实现简单2PC : IDisposable
    {
        //是否已释放
        private bool disposed = false;

        //数据库集非托管资源
        private readonly HashSet<(IDbConnection Conn, IDbTransaction Trans)> dbTxSet;

        public 自实现简单2PC()
        {
            dbTxSet = new HashSet<(IDbConnection, IDbTransaction)>();
        }

        /// <summary>
        /// 由垃圾回收器调用，释放非托管资源
        /// </summary>
        ~自实现简单2PC()
        {
            //GC调用，终结
            //释放非托管资源
            Dispose(false);
        }

        /// <summary>
        /// 确认
        /// </summary>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <returns></returns>
        public IDbConnection Confirm(string connectionString)
        {
            var dbConnection = new MySqlConnection(connectionString);
            dbConnection.Open();
            var dbTransection = dbConnection.BeginTransaction();

            dbTxSet.Add((dbConnection, dbTransection));

            return dbConnection;
        }

        /// <summary>
        /// 提交所有
        /// </summary>
        public void CommitAll()
        {
            foreach(var (Conn, Trans) in dbTxSet)
            {
                Trans.Commit();
            }
        }

        public void Dispose()
        {
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
        public void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                //释放托管资源
            }

            //释放非托管资源
            foreach (var item in dbTxSet)
            {
                item.Trans.Dispose();
                item.Conn.Dispose();
            }

            disposed = true;

        }

        public void Register()
        {
            using (var util = new 自实现简单2PC())
            {
                var payCnn = util.Confirm(ConnectionStrings.DT_Payment);
                var orderCnn = util.Confirm(ConnectionStrings.DT_Order);

                var payUserRepoUtil = new RepoUtil<Model.Databases.DT_Payment.User>();
                var orderUserRepoUtil = new RepoUtil<Model.Databases.DT_Order.User>();

                payCnn.Execute(payUserRepoUtil.InsertSql, new Model.Databases.DT_Payment.User()
                {
                    CreateAt = DateTime.Now,
                    Name = "自实现简单2PC",
                    Password = "Payment",
                    UpdateAt = DateTime.Now,
                });
                orderCnn.Execute(orderUserRepoUtil.InsertSql, new Model.Databases.DT_Order.User()
                {
                    CreateAt = DateTime.Now,
                    Name = "自实现简单2PC",
                    Password = "Order",
                    UpdateAt = DateTime.Now,
                });

                //var r1 = 0;
                //var r2 = 3 / r1;

                util.CommitAll();
            }
        }
    }

    
}
