using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerAndDeSer.UseProtoBufNet
{
    //添加特性，表示可以被ProtoBuf工具序列化，需安装protobuf-net包
    [global::System.Serializable, global::ProtoBuf.ProtoContract(Name = @"Request")]
    public class ConnectUser
    {
        [ProtoBuf.ProtoMember(1)]
        public long Id { get; set; }

        [ProtoBuf.ProtoMember(2)]
        public string AuthToken { get; set; }
    }

    //添加特性，表示可以被ProtoBuf工具序列化，需安装protobuf-net包
    [global::System.Serializable, global::ProtoBuf.ProtoContract(Name = @"Request")]
    public class NetRequest
    {
        [ProtoBuf.ProtoMember(1)]
        public ConnectUser ConnUser { get; set; }

        [ProtoBuf.ProtoMember(2)]
        public string Action { get; set; }

        [ProtoBuf.ProtoMember(3)]
        public Dictionary<string, string> Params { get; set; }
    }

    //添加特性，表示可以被ProtoBuf工具序列化，需安装protobuf-net包
    [global::System.Serializable, global::ProtoBuf.ProtoContract(Name = @"Request")]
    public class PbTest2
    {
        [ProtoBuf.ProtoMember(1)]
        public double MyDouble { get; set; }

        [ProtoBuf.ProtoMember(2)]
        public float MyFloat { get; set; }

        [ProtoBuf.ProtoMember(3)]
        public int MyInt32 { get; set; }

        [ProtoBuf.ProtoMember(4)]
        public uint MyUint32 { get; set; }

        [ProtoBuf.ProtoMember(5)]
        public ulong MyUint64 { get; set; }

        [ProtoBuf.ProtoMember(6)]
        public bool MyBool { get; set; }

        [ProtoBuf.ProtoMember(7)]
        public string MyString { get; set; }

        [ProtoBuf.ProtoMember(8)]
        public byte[] MyBytes { get; set; }

        [ProtoBuf.ProtoMember(9)]
        public List<string> MyStringList { get; set; }
    }
}
