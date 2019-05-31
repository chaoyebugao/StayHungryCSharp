using ConsoleApp2.Utility;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2.Data.DistributedRepositories.RAW
{
    /// <summary>
    /// 裸实现
    /// </summary>
    public class UserRepository
    {
        public void Register()
        {
            using (var payCnn = new MySqlConnection(ConnectionStrings.DT_Payment))
            {
                using (var orderCnn = new MySqlConnection(ConnectionStrings.DT_Order))
                {
                    payCnn.Open();
                    using (var payTrans = payCnn.BeginTransaction())
                    {
                        orderCnn.Open();
                        using (var orderTrans = orderCnn.BeginTransaction())
                        {
                            var payUserRepoUtil = new RepoUtil<Model.Databases.DT_Payment.User>();
                            var orderUserRepoUtil = new RepoUtil<Model.Databases.DT_Order.User>();

                            payCnn.Execute(payUserRepoUtil.InsertSql, new Model.Databases.DT_Payment.User()
                            {
                                CreateAt = DateTime.Now,
                                Name = "RAW",
                                Password = "Payment",
                                UpdateAt = DateTime.Now,
                            });
                            orderCnn.Execute(orderUserRepoUtil.InsertSql, new Model.Databases.DT_Order.User()
                            {
                                CreateAt = DateTime.Now,
                                Name = "RAW",
                                Password = "Order",
                                UpdateAt = DateTime.Now,
                            });

                            payTrans.Commit();
                            orderTrans.Commit();
                        }
                    }
                }
            }
        }
    }
}
