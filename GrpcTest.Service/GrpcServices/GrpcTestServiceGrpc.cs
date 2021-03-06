// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: PATH/Test/GrpcTestService.proto
// </auto-generated>
#pragma warning disable 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace GrpcTest.Service.GrpcSvc {
  /// <summary>
  ///测试
  /// </summary>
  public static partial class TestSvc
  {
    static readonly string __ServiceName = "GrpcTest.Service.GrpcSvc.TestSvc";

    static readonly grpc::Marshaller<global::GrpcTest.Service.Models.RegisterRq> __Marshaller_RegisterRq = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::GrpcTest.Service.Models.RegisterRq.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Grpc.Service.Model.ExecuteResult.PbMsgRet> __Marshaller_PbMsgRet = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Grpc.Service.Model.ExecuteResult.PbMsgRet.Parser.ParseFrom);

    static readonly grpc::Method<global::GrpcTest.Service.Models.RegisterRq, global::Grpc.Service.Model.ExecuteResult.PbMsgRet> __Method_Register1 = new grpc::Method<global::GrpcTest.Service.Models.RegisterRq, global::Grpc.Service.Model.ExecuteResult.PbMsgRet>(
        grpc::MethodType.Unary,
        __ServiceName,
        "Register1",
        __Marshaller_RegisterRq,
        __Marshaller_PbMsgRet);

    static readonly grpc::Method<global::GrpcTest.Service.Models.RegisterRq, global::Grpc.Service.Model.ExecuteResult.PbMsgRet> __Method_Register2 = new grpc::Method<global::GrpcTest.Service.Models.RegisterRq, global::Grpc.Service.Model.ExecuteResult.PbMsgRet>(
        grpc::MethodType.ServerStreaming,
        __ServiceName,
        "Register2",
        __Marshaller_RegisterRq,
        __Marshaller_PbMsgRet);

    static readonly grpc::Method<global::GrpcTest.Service.Models.RegisterRq, global::Grpc.Service.Model.ExecuteResult.PbMsgRet> __Method_Register3 = new grpc::Method<global::GrpcTest.Service.Models.RegisterRq, global::Grpc.Service.Model.ExecuteResult.PbMsgRet>(
        grpc::MethodType.ClientStreaming,
        __ServiceName,
        "Register3",
        __Marshaller_RegisterRq,
        __Marshaller_PbMsgRet);

    static readonly grpc::Method<global::GrpcTest.Service.Models.RegisterRq, global::Grpc.Service.Model.ExecuteResult.PbMsgRet> __Method_Register4 = new grpc::Method<global::GrpcTest.Service.Models.RegisterRq, global::Grpc.Service.Model.ExecuteResult.PbMsgRet>(
        grpc::MethodType.DuplexStreaming,
        __ServiceName,
        "Register4",
        __Marshaller_RegisterRq,
        __Marshaller_PbMsgRet);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::GrpcTest.Service.GrpcSvc.GrpcTestServiceReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of TestSvc</summary>
    public abstract partial class TestSvcBase
    {
      /// <summary>
      ///注册
      ///一个 简单 RPC ， 客户端使用存根发送请求到服务器并等待响应返回，就像平常的函数调用一样
      /// </summary>
      /// <param name="request">The request received from the client.</param>
      /// <param name="context">The context of the server-side call handler being invoked.</param>
      /// <returns>The response to send back to the client (wrapped by a task).</returns>
      public virtual global::System.Threading.Tasks.Task<global::Grpc.Service.Model.ExecuteResult.PbMsgRet> Register1(global::GrpcTest.Service.Models.RegisterRq request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      /// <summary>
      ///注册
      ///一个 服务器端流式 RPC ， 客户端发送请求到服务器，拿到一个流去读取返回的消息序列。 客户端读取返回的流，
      ///直到里面没有任何消息。从例子中可以看出，通过在 响应 类型前插入 stream 关键字，可以指定一个服务器端的流方法
      /// </summary>
      /// <param name="request">The request received from the client.</param>
      /// <param name="responseStream">Used for sending responses back to the client.</param>
      /// <param name="context">The context of the server-side call handler being invoked.</param>
      /// <returns>A task indicating completion of the handler.</returns>
      public virtual global::System.Threading.Tasks.Task Register2(global::GrpcTest.Service.Models.RegisterRq request, grpc::IServerStreamWriter<global::Grpc.Service.Model.ExecuteResult.PbMsgRet> responseStream, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      /// <summary>
      ///注册
      ///一个 客户端流式 RPC ， 客户端写入一个消息序列并将其发送到服务器，同样也是使用流。一旦客户端完成写入消息，
      ///它等待服务器完成读取返回它的响应。通过在 请求 类型前指定 stream 关键字来指定一个客户端的流方法
      /// </summary>
      /// <param name="requestStream">Used for reading requests from the client.</param>
      /// <param name="context">The context of the server-side call handler being invoked.</param>
      /// <returns>The response to send back to the client (wrapped by a task).</returns>
      public virtual global::System.Threading.Tasks.Task<global::Grpc.Service.Model.ExecuteResult.PbMsgRet> Register3(grpc::IAsyncStreamReader<global::GrpcTest.Service.Models.RegisterRq> requestStream, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      /// <summary>
      ///注册
      ///一个 双向流式 RPC 是双方使用读写流去发送一个消息序列。两个流独立操作，因此客户端和服务器
      ///可以以任意喜欢的顺序读写：比如， 服务器可以在写入响应前等待接收所有的客户端消息，或者可以交替 的读取和写入消息，
      ///或者其他读写的组合。每个流中的消息顺序被预留。你可以通过在请求和响应前加 stream 关键字去制定方法的类型
      /// </summary>
      /// <param name="requestStream">Used for reading requests from the client.</param>
      /// <param name="responseStream">Used for sending responses back to the client.</param>
      /// <param name="context">The context of the server-side call handler being invoked.</param>
      /// <returns>A task indicating completion of the handler.</returns>
      public virtual global::System.Threading.Tasks.Task Register4(grpc::IAsyncStreamReader<global::GrpcTest.Service.Models.RegisterRq> requestStream, grpc::IServerStreamWriter<global::Grpc.Service.Model.ExecuteResult.PbMsgRet> responseStream, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Client for TestSvc</summary>
    public partial class TestSvcClient : grpc::ClientBase<TestSvcClient>
    {
      /// <summary>Creates a new client for TestSvc</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      public TestSvcClient(grpc::Channel channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for TestSvc that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      public TestSvcClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      protected TestSvcClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      protected TestSvcClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      /// <summary>
      ///注册
      ///一个 简单 RPC ， 客户端使用存根发送请求到服务器并等待响应返回，就像平常的函数调用一样
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The response received from the server.</returns>
      public virtual global::Grpc.Service.Model.ExecuteResult.PbMsgRet Register1(global::GrpcTest.Service.Models.RegisterRq request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return Register1(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      ///注册
      ///一个 简单 RPC ， 客户端使用存根发送请求到服务器并等待响应返回，就像平常的函数调用一样
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The response received from the server.</returns>
      public virtual global::Grpc.Service.Model.ExecuteResult.PbMsgRet Register1(global::GrpcTest.Service.Models.RegisterRq request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_Register1, null, options, request);
      }
      /// <summary>
      ///注册
      ///一个 简单 RPC ， 客户端使用存根发送请求到服务器并等待响应返回，就像平常的函数调用一样
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The call object.</returns>
      public virtual grpc::AsyncUnaryCall<global::Grpc.Service.Model.ExecuteResult.PbMsgRet> Register1Async(global::GrpcTest.Service.Models.RegisterRq request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return Register1Async(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      ///注册
      ///一个 简单 RPC ， 客户端使用存根发送请求到服务器并等待响应返回，就像平常的函数调用一样
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The call object.</returns>
      public virtual grpc::AsyncUnaryCall<global::Grpc.Service.Model.ExecuteResult.PbMsgRet> Register1Async(global::GrpcTest.Service.Models.RegisterRq request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_Register1, null, options, request);
      }
      /// <summary>
      ///注册
      ///一个 服务器端流式 RPC ， 客户端发送请求到服务器，拿到一个流去读取返回的消息序列。 客户端读取返回的流，
      ///直到里面没有任何消息。从例子中可以看出，通过在 响应 类型前插入 stream 关键字，可以指定一个服务器端的流方法
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The call object.</returns>
      public virtual grpc::AsyncServerStreamingCall<global::Grpc.Service.Model.ExecuteResult.PbMsgRet> Register2(global::GrpcTest.Service.Models.RegisterRq request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return Register2(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      ///注册
      ///一个 服务器端流式 RPC ， 客户端发送请求到服务器，拿到一个流去读取返回的消息序列。 客户端读取返回的流，
      ///直到里面没有任何消息。从例子中可以看出，通过在 响应 类型前插入 stream 关键字，可以指定一个服务器端的流方法
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The call object.</returns>
      public virtual grpc::AsyncServerStreamingCall<global::Grpc.Service.Model.ExecuteResult.PbMsgRet> Register2(global::GrpcTest.Service.Models.RegisterRq request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncServerStreamingCall(__Method_Register2, null, options, request);
      }
      /// <summary>
      ///注册
      ///一个 客户端流式 RPC ， 客户端写入一个消息序列并将其发送到服务器，同样也是使用流。一旦客户端完成写入消息，
      ///它等待服务器完成读取返回它的响应。通过在 请求 类型前指定 stream 关键字来指定一个客户端的流方法
      /// </summary>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The call object.</returns>
      public virtual grpc::AsyncClientStreamingCall<global::GrpcTest.Service.Models.RegisterRq, global::Grpc.Service.Model.ExecuteResult.PbMsgRet> Register3(grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return Register3(new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      ///注册
      ///一个 客户端流式 RPC ， 客户端写入一个消息序列并将其发送到服务器，同样也是使用流。一旦客户端完成写入消息，
      ///它等待服务器完成读取返回它的响应。通过在 请求 类型前指定 stream 关键字来指定一个客户端的流方法
      /// </summary>
      /// <param name="options">The options for the call.</param>
      /// <returns>The call object.</returns>
      public virtual grpc::AsyncClientStreamingCall<global::GrpcTest.Service.Models.RegisterRq, global::Grpc.Service.Model.ExecuteResult.PbMsgRet> Register3(grpc::CallOptions options)
      {
        return CallInvoker.AsyncClientStreamingCall(__Method_Register3, null, options);
      }
      /// <summary>
      ///注册
      ///一个 双向流式 RPC 是双方使用读写流去发送一个消息序列。两个流独立操作，因此客户端和服务器
      ///可以以任意喜欢的顺序读写：比如， 服务器可以在写入响应前等待接收所有的客户端消息，或者可以交替 的读取和写入消息，
      ///或者其他读写的组合。每个流中的消息顺序被预留。你可以通过在请求和响应前加 stream 关键字去制定方法的类型
      /// </summary>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The call object.</returns>
      public virtual grpc::AsyncDuplexStreamingCall<global::GrpcTest.Service.Models.RegisterRq, global::Grpc.Service.Model.ExecuteResult.PbMsgRet> Register4(grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return Register4(new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      ///注册
      ///一个 双向流式 RPC 是双方使用读写流去发送一个消息序列。两个流独立操作，因此客户端和服务器
      ///可以以任意喜欢的顺序读写：比如， 服务器可以在写入响应前等待接收所有的客户端消息，或者可以交替 的读取和写入消息，
      ///或者其他读写的组合。每个流中的消息顺序被预留。你可以通过在请求和响应前加 stream 关键字去制定方法的类型
      /// </summary>
      /// <param name="options">The options for the call.</param>
      /// <returns>The call object.</returns>
      public virtual grpc::AsyncDuplexStreamingCall<global::GrpcTest.Service.Models.RegisterRq, global::Grpc.Service.Model.ExecuteResult.PbMsgRet> Register4(grpc::CallOptions options)
      {
        return CallInvoker.AsyncDuplexStreamingCall(__Method_Register4, null, options);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      protected override TestSvcClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new TestSvcClient(configuration);
      }
    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(TestSvcBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_Register1, serviceImpl.Register1)
          .AddMethod(__Method_Register2, serviceImpl.Register2)
          .AddMethod(__Method_Register3, serviceImpl.Register3)
          .AddMethod(__Method_Register4, serviceImpl.Register4).Build();
    }

  }
}
#endregion
