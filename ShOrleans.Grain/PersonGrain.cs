using Orleans;
using Orleans.Providers;
using ShOrleans.IGrain;
using ShOrleans.IGrain.States;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShOrleans.Grain
{
    [StorageProvider(ProviderName = "DevStore")]
    public class PersonGrain : Grain<PersonState>, IPerson
    {
        /// <summary>
        /// 买东西付款啦
        /// </summary>
        /// <returns></returns>
        public Task<decimal> PaySthAsync()
        {
            var id = this.GetPrimaryKey();

            Console.WriteLine($"收到:{id}扣款请求，余额:{State.TotalMoney}");
            State.TotalMoney = State.TotalMoney - 10M;
            base.WriteStateAsync();
            Console.WriteLine($"{id}已付款,{State.TotalMoney}");

            return Task.FromResult(State.TotalMoney);
        }
    }
}
