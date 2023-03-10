// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/GrpcAuthServices.proto
// </auto-generated>
#pragma warning disable 0414, 1591, 8981
#region Designer generated code

using grpc = global::Grpc.Core;

namespace GrpcAuthServices.Protos {
  public static partial class AuthServices
  {
    static readonly string __ServiceName = "GrpcAuthServices.AuthServices";

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static void __Helper_SerializeMessage(global::Google.Protobuf.IMessage message, grpc::SerializationContext context)
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (message is global::Google.Protobuf.IBufferMessage)
      {
        context.SetPayloadLength(message.CalculateSize());
        global::Google.Protobuf.MessageExtensions.WriteTo(message, context.GetBufferWriter());
        context.Complete();
        return;
      }
      #endif
      context.Complete(global::Google.Protobuf.MessageExtensions.ToByteArray(message));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static class __Helper_MessageCache<T>
    {
      public static readonly bool IsBufferMessage = global::System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(global::Google.Protobuf.IBufferMessage)).IsAssignableFrom(typeof(T));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static T __Helper_DeserializeMessage<T>(grpc::DeserializationContext context, global::Google.Protobuf.MessageParser<T> parser) where T : global::Google.Protobuf.IMessage<T>
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (__Helper_MessageCache<T>.IsBufferMessage)
      {
        return parser.ParseFrom(context.PayloadAsReadOnlySequence());
      }
      #endif
      return parser.ParseFrom(context.PayloadAsNewBuffer());
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::GrpcAuthServices.Protos.AuthenticationInput> __Marshaller_GrpcAuthServices_AuthenticationInput = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::GrpcAuthServices.Protos.AuthenticationInput.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::GrpcAuthServices.Protos.Jwt> __Marshaller_GrpcAuthServices_Jwt = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::GrpcAuthServices.Protos.Jwt.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::GrpcAuthServices.Protos.RegisterInput> __Marshaller_GrpcAuthServices_RegisterInput = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::GrpcAuthServices.Protos.RegisterInput.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::GrpcAuthServices.Protos.RegisterOutput> __Marshaller_GrpcAuthServices_RegisterOutput = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::GrpcAuthServices.Protos.RegisterOutput.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::GrpcAuthServices.Protos.DeleteOwnInput> __Marshaller_GrpcAuthServices_DeleteOwnInput = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::GrpcAuthServices.Protos.DeleteOwnInput.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::GrpcAuthServices.Protos.DeleteOwnOutput> __Marshaller_GrpcAuthServices_DeleteOwnOutput = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::GrpcAuthServices.Protos.DeleteOwnOutput.Parser));

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::GrpcAuthServices.Protos.AuthenticationInput, global::GrpcAuthServices.Protos.Jwt> __Method_Authenticate = new grpc::Method<global::GrpcAuthServices.Protos.AuthenticationInput, global::GrpcAuthServices.Protos.Jwt>(
        grpc::MethodType.Unary,
        __ServiceName,
        "Authenticate",
        __Marshaller_GrpcAuthServices_AuthenticationInput,
        __Marshaller_GrpcAuthServices_Jwt);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::GrpcAuthServices.Protos.RegisterInput, global::GrpcAuthServices.Protos.RegisterOutput> __Method_Register = new grpc::Method<global::GrpcAuthServices.Protos.RegisterInput, global::GrpcAuthServices.Protos.RegisterOutput>(
        grpc::MethodType.Unary,
        __ServiceName,
        "Register",
        __Marshaller_GrpcAuthServices_RegisterInput,
        __Marshaller_GrpcAuthServices_RegisterOutput);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::GrpcAuthServices.Protos.DeleteOwnInput, global::GrpcAuthServices.Protos.DeleteOwnOutput> __Method_DeleteOwn = new grpc::Method<global::GrpcAuthServices.Protos.DeleteOwnInput, global::GrpcAuthServices.Protos.DeleteOwnOutput>(
        grpc::MethodType.Unary,
        __ServiceName,
        "DeleteOwn",
        __Marshaller_GrpcAuthServices_DeleteOwnInput,
        __Marshaller_GrpcAuthServices_DeleteOwnOutput);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::GrpcAuthServices.Protos.GrpcAuthServicesReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of AuthServices</summary>
    [grpc::BindServiceMethod(typeof(AuthServices), "BindService")]
    public abstract partial class AuthServicesBase
    {
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::GrpcAuthServices.Protos.Jwt> Authenticate(global::GrpcAuthServices.Protos.AuthenticationInput request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::GrpcAuthServices.Protos.RegisterOutput> Register(global::GrpcAuthServices.Protos.RegisterInput request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::GrpcAuthServices.Protos.DeleteOwnOutput> DeleteOwn(global::GrpcAuthServices.Protos.DeleteOwnInput request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static grpc::ServerServiceDefinition BindService(AuthServicesBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_Authenticate, serviceImpl.Authenticate)
          .AddMethod(__Method_Register, serviceImpl.Register)
          .AddMethod(__Method_DeleteOwn, serviceImpl.DeleteOwn).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static void BindService(grpc::ServiceBinderBase serviceBinder, AuthServicesBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_Authenticate, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::GrpcAuthServices.Protos.AuthenticationInput, global::GrpcAuthServices.Protos.Jwt>(serviceImpl.Authenticate));
      serviceBinder.AddMethod(__Method_Register, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::GrpcAuthServices.Protos.RegisterInput, global::GrpcAuthServices.Protos.RegisterOutput>(serviceImpl.Register));
      serviceBinder.AddMethod(__Method_DeleteOwn, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::GrpcAuthServices.Protos.DeleteOwnInput, global::GrpcAuthServices.Protos.DeleteOwnOutput>(serviceImpl.DeleteOwn));
    }

  }
}
#endregion
