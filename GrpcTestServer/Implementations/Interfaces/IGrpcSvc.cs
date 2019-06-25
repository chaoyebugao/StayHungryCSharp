using System;
using System.Collections.Generic;
using System.Text;

namespace GrpcTestServer.Implementations.Interfaces
{
    public interface IGrpcSvc
    {
        long PrintRps(long totalRp, long max);
    }
}
