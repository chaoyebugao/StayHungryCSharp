using ShOrleans.IGrain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShOrleans.Grain
{
    public class HelloGrain : Orleans.Grain, IHello
    {
        public Task<string> SayHello(string greeting)
        {
            return Task.FromResult($"You said:{greeting}, I say: I'm fine, and you?");
        }
    }
}
