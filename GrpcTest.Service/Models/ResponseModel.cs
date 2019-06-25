// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: PATH/Test/ResponseModel.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Grpc.Service.Model.ExecuteResult {

  /// <summary>Holder for reflection information generated from PATH/Test/ResponseModel.proto</summary>
  public static partial class ResponseModelReflection {

    #region Descriptor
    /// <summary>File descriptor for PATH/Test/ResponseModel.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static ResponseModelReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "Ch1QQVRIL1Rlc3QvUmVzcG9uc2VNb2RlbC5wcm90bxIgR3JwYy5TZXJ2aWNl",
            "Lk1vZGVsLkV4ZWN1dGVSZXN1bHQaGWdvb2dsZS9wcm90b2J1Zi9hbnkucHJv",
            "dG8aGVRlc3QvU3lzRW51bWVyYXRpb24ucHJvdG8iVgoIUGJNc2dSZXQSOgoH",
            "RXJyQ29kZRgBIAEoDjIpLkdycGNUZXN0LlNlcnZpY2VzLkVudW1lcmF0aW9u",
            "LkVycm9yQ29kZXMSDgoGRXJyTXNnGAIgASgJInsKCVBiRGF0YVJldBI6CgdF",
            "cnJDb2RlGAEgASgOMikuR3JwY1Rlc3QuU2VydmljZXMuRW51bWVyYXRpb24u",
            "RXJyb3JDb2RlcxIOCgZFcnJNc2cYAiABKAkSIgoERGF0YRgDIAEoCzIULmdv",
            "b2dsZS5wcm90b2J1Zi5BbnkiiwEKClBiUGFnZWRSZXQSOgoHRXJyQ29kZRgB",
            "IAEoDjIpLkdycGNUZXN0LlNlcnZpY2VzLkVudW1lcmF0aW9uLkVycm9yQ29k",
            "ZXMSDgoGRXJyTXNnGAIgASgJEiIKBExpc3QYAyADKAsyFC5nb29nbGUucHJv",
            "dG9idWYuQW55Eg0KBVRvdGFsGAQgASgFInsKCVBiTGlzdFJldBI6CgdFcnJD",
            "b2RlGAEgASgOMikuR3JwY1Rlc3QuU2VydmljZXMuRW51bWVyYXRpb24uRXJy",
            "b3JDb2RlcxIOCgZFcnJNc2cYAiABKAkSIgoETGlzdBgDIAMoCzIULmdvb2ds",
            "ZS5wcm90b2J1Zi5BbnliBnByb3RvMw=="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::Google.Protobuf.WellKnownTypes.AnyReflection.Descriptor, global::GrpcTest.Services.Enumeration.SysEnumerationReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Grpc.Service.Model.ExecuteResult.PbMsgRet), global::Grpc.Service.Model.ExecuteResult.PbMsgRet.Parser, new[]{ "ErrCode", "ErrMsg" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Grpc.Service.Model.ExecuteResult.PbDataRet), global::Grpc.Service.Model.ExecuteResult.PbDataRet.Parser, new[]{ "ErrCode", "ErrMsg", "Data" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Grpc.Service.Model.ExecuteResult.PbPagedRet), global::Grpc.Service.Model.ExecuteResult.PbPagedRet.Parser, new[]{ "ErrCode", "ErrMsg", "List", "Total" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Grpc.Service.Model.ExecuteResult.PbListRet), global::Grpc.Service.Model.ExecuteResult.PbListRet.Parser, new[]{ "ErrCode", "ErrMsg", "List" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  /// <summary>
  ///带信息执行结果
  /// </summary>
  public sealed partial class PbMsgRet : pb::IMessage<PbMsgRet> {
    private static readonly pb::MessageParser<PbMsgRet> _parser = new pb::MessageParser<PbMsgRet>(() => new PbMsgRet());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<PbMsgRet> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Grpc.Service.Model.ExecuteResult.ResponseModelReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public PbMsgRet() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public PbMsgRet(PbMsgRet other) : this() {
      errCode_ = other.errCode_;
      errMsg_ = other.errMsg_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public PbMsgRet Clone() {
      return new PbMsgRet(this);
    }

    /// <summary>Field number for the "ErrCode" field.</summary>
    public const int ErrCodeFieldNumber = 1;
    private global::GrpcTest.Services.Enumeration.ErrorCodes errCode_ = 0;
    /// <summary>
    ///错误编号，0为执行成功
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::GrpcTest.Services.Enumeration.ErrorCodes ErrCode {
      get { return errCode_; }
      set {
        errCode_ = value;
      }
    }

    /// <summary>Field number for the "ErrMsg" field.</summary>
    public const int ErrMsgFieldNumber = 2;
    private string errMsg_ = "";
    /// <summary>
    ///错误信息
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string ErrMsg {
      get { return errMsg_; }
      set {
        errMsg_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as PbMsgRet);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(PbMsgRet other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (ErrCode != other.ErrCode) return false;
      if (ErrMsg != other.ErrMsg) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (ErrCode != 0) hash ^= ErrCode.GetHashCode();
      if (ErrMsg.Length != 0) hash ^= ErrMsg.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (ErrCode != 0) {
        output.WriteRawTag(8);
        output.WriteEnum((int) ErrCode);
      }
      if (ErrMsg.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(ErrMsg);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (ErrCode != 0) {
        size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) ErrCode);
      }
      if (ErrMsg.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(ErrMsg);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(PbMsgRet other) {
      if (other == null) {
        return;
      }
      if (other.ErrCode != 0) {
        ErrCode = other.ErrCode;
      }
      if (other.ErrMsg.Length != 0) {
        ErrMsg = other.ErrMsg;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 8: {
            errCode_ = (global::GrpcTest.Services.Enumeration.ErrorCodes) input.ReadEnum();
            break;
          }
          case 18: {
            ErrMsg = input.ReadString();
            break;
          }
        }
      }
    }

  }

  /// <summary>
  ///带数据执行结果
  /// </summary>
  public sealed partial class PbDataRet : pb::IMessage<PbDataRet> {
    private static readonly pb::MessageParser<PbDataRet> _parser = new pb::MessageParser<PbDataRet>(() => new PbDataRet());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<PbDataRet> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Grpc.Service.Model.ExecuteResult.ResponseModelReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public PbDataRet() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public PbDataRet(PbDataRet other) : this() {
      errCode_ = other.errCode_;
      errMsg_ = other.errMsg_;
      Data = other.data_ != null ? other.Data.Clone() : null;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public PbDataRet Clone() {
      return new PbDataRet(this);
    }

    /// <summary>Field number for the "ErrCode" field.</summary>
    public const int ErrCodeFieldNumber = 1;
    private global::GrpcTest.Services.Enumeration.ErrorCodes errCode_ = 0;
    /// <summary>
    ///错误编号，0为执行成功
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::GrpcTest.Services.Enumeration.ErrorCodes ErrCode {
      get { return errCode_; }
      set {
        errCode_ = value;
      }
    }

    /// <summary>Field number for the "ErrMsg" field.</summary>
    public const int ErrMsgFieldNumber = 2;
    private string errMsg_ = "";
    /// <summary>
    ///错误信息
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string ErrMsg {
      get { return errMsg_; }
      set {
        errMsg_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "Data" field.</summary>
    public const int DataFieldNumber = 3;
    private global::Google.Protobuf.WellKnownTypes.Any data_;
    /// <summary>
    ///数据对象
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Google.Protobuf.WellKnownTypes.Any Data {
      get { return data_; }
      set {
        data_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as PbDataRet);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(PbDataRet other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (ErrCode != other.ErrCode) return false;
      if (ErrMsg != other.ErrMsg) return false;
      if (!object.Equals(Data, other.Data)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (ErrCode != 0) hash ^= ErrCode.GetHashCode();
      if (ErrMsg.Length != 0) hash ^= ErrMsg.GetHashCode();
      if (data_ != null) hash ^= Data.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (ErrCode != 0) {
        output.WriteRawTag(8);
        output.WriteEnum((int) ErrCode);
      }
      if (ErrMsg.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(ErrMsg);
      }
      if (data_ != null) {
        output.WriteRawTag(26);
        output.WriteMessage(Data);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (ErrCode != 0) {
        size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) ErrCode);
      }
      if (ErrMsg.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(ErrMsg);
      }
      if (data_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Data);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(PbDataRet other) {
      if (other == null) {
        return;
      }
      if (other.ErrCode != 0) {
        ErrCode = other.ErrCode;
      }
      if (other.ErrMsg.Length != 0) {
        ErrMsg = other.ErrMsg;
      }
      if (other.data_ != null) {
        if (data_ == null) {
          data_ = new global::Google.Protobuf.WellKnownTypes.Any();
        }
        Data.MergeFrom(other.Data);
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 8: {
            errCode_ = (global::GrpcTest.Services.Enumeration.ErrorCodes) input.ReadEnum();
            break;
          }
          case 18: {
            ErrMsg = input.ReadString();
            break;
          }
          case 26: {
            if (data_ == null) {
              data_ = new global::Google.Protobuf.WellKnownTypes.Any();
            }
            input.ReadMessage(data_);
            break;
          }
        }
      }
    }

  }

  /// <summary>
  ///分页结果
  /// </summary>
  public sealed partial class PbPagedRet : pb::IMessage<PbPagedRet> {
    private static readonly pb::MessageParser<PbPagedRet> _parser = new pb::MessageParser<PbPagedRet>(() => new PbPagedRet());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<PbPagedRet> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Grpc.Service.Model.ExecuteResult.ResponseModelReflection.Descriptor.MessageTypes[2]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public PbPagedRet() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public PbPagedRet(PbPagedRet other) : this() {
      errCode_ = other.errCode_;
      errMsg_ = other.errMsg_;
      list_ = other.list_.Clone();
      total_ = other.total_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public PbPagedRet Clone() {
      return new PbPagedRet(this);
    }

    /// <summary>Field number for the "ErrCode" field.</summary>
    public const int ErrCodeFieldNumber = 1;
    private global::GrpcTest.Services.Enumeration.ErrorCodes errCode_ = 0;
    /// <summary>
    ///错误编号，0为执行成功
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::GrpcTest.Services.Enumeration.ErrorCodes ErrCode {
      get { return errCode_; }
      set {
        errCode_ = value;
      }
    }

    /// <summary>Field number for the "ErrMsg" field.</summary>
    public const int ErrMsgFieldNumber = 2;
    private string errMsg_ = "";
    /// <summary>
    ///错误信息
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string ErrMsg {
      get { return errMsg_; }
      set {
        errMsg_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "List" field.</summary>
    public const int ListFieldNumber = 3;
    private static readonly pb::FieldCodec<global::Google.Protobuf.WellKnownTypes.Any> _repeated_list_codec
        = pb::FieldCodec.ForMessage(26, global::Google.Protobuf.WellKnownTypes.Any.Parser);
    private readonly pbc::RepeatedField<global::Google.Protobuf.WellKnownTypes.Any> list_ = new pbc::RepeatedField<global::Google.Protobuf.WellKnownTypes.Any>();
    /// <summary>
    ///分页数据
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<global::Google.Protobuf.WellKnownTypes.Any> List {
      get { return list_; }
    }

    /// <summary>Field number for the "Total" field.</summary>
    public const int TotalFieldNumber = 4;
    private int total_;
    /// <summary>
    ///总项目数
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int Total {
      get { return total_; }
      set {
        total_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as PbPagedRet);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(PbPagedRet other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (ErrCode != other.ErrCode) return false;
      if (ErrMsg != other.ErrMsg) return false;
      if(!list_.Equals(other.list_)) return false;
      if (Total != other.Total) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (ErrCode != 0) hash ^= ErrCode.GetHashCode();
      if (ErrMsg.Length != 0) hash ^= ErrMsg.GetHashCode();
      hash ^= list_.GetHashCode();
      if (Total != 0) hash ^= Total.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (ErrCode != 0) {
        output.WriteRawTag(8);
        output.WriteEnum((int) ErrCode);
      }
      if (ErrMsg.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(ErrMsg);
      }
      list_.WriteTo(output, _repeated_list_codec);
      if (Total != 0) {
        output.WriteRawTag(32);
        output.WriteInt32(Total);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (ErrCode != 0) {
        size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) ErrCode);
      }
      if (ErrMsg.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(ErrMsg);
      }
      size += list_.CalculateSize(_repeated_list_codec);
      if (Total != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Total);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(PbPagedRet other) {
      if (other == null) {
        return;
      }
      if (other.ErrCode != 0) {
        ErrCode = other.ErrCode;
      }
      if (other.ErrMsg.Length != 0) {
        ErrMsg = other.ErrMsg;
      }
      list_.Add(other.list_);
      if (other.Total != 0) {
        Total = other.Total;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 8: {
            errCode_ = (global::GrpcTest.Services.Enumeration.ErrorCodes) input.ReadEnum();
            break;
          }
          case 18: {
            ErrMsg = input.ReadString();
            break;
          }
          case 26: {
            list_.AddEntriesFrom(input, _repeated_list_codec);
            break;
          }
          case 32: {
            Total = input.ReadInt32();
            break;
          }
        }
      }
    }

  }

  /// <summary>
  ///带数据列表执行结果
  /// </summary>
  public sealed partial class PbListRet : pb::IMessage<PbListRet> {
    private static readonly pb::MessageParser<PbListRet> _parser = new pb::MessageParser<PbListRet>(() => new PbListRet());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<PbListRet> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Grpc.Service.Model.ExecuteResult.ResponseModelReflection.Descriptor.MessageTypes[3]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public PbListRet() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public PbListRet(PbListRet other) : this() {
      errCode_ = other.errCode_;
      errMsg_ = other.errMsg_;
      list_ = other.list_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public PbListRet Clone() {
      return new PbListRet(this);
    }

    /// <summary>Field number for the "ErrCode" field.</summary>
    public const int ErrCodeFieldNumber = 1;
    private global::GrpcTest.Services.Enumeration.ErrorCodes errCode_ = 0;
    /// <summary>
    ///错误编号，0为执行成功
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::GrpcTest.Services.Enumeration.ErrorCodes ErrCode {
      get { return errCode_; }
      set {
        errCode_ = value;
      }
    }

    /// <summary>Field number for the "ErrMsg" field.</summary>
    public const int ErrMsgFieldNumber = 2;
    private string errMsg_ = "";
    /// <summary>
    ///错误信息
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string ErrMsg {
      get { return errMsg_; }
      set {
        errMsg_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "List" field.</summary>
    public const int ListFieldNumber = 3;
    private static readonly pb::FieldCodec<global::Google.Protobuf.WellKnownTypes.Any> _repeated_list_codec
        = pb::FieldCodec.ForMessage(26, global::Google.Protobuf.WellKnownTypes.Any.Parser);
    private readonly pbc::RepeatedField<global::Google.Protobuf.WellKnownTypes.Any> list_ = new pbc::RepeatedField<global::Google.Protobuf.WellKnownTypes.Any>();
    /// <summary>
    ///数据列表
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<global::Google.Protobuf.WellKnownTypes.Any> List {
      get { return list_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as PbListRet);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(PbListRet other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (ErrCode != other.ErrCode) return false;
      if (ErrMsg != other.ErrMsg) return false;
      if(!list_.Equals(other.list_)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (ErrCode != 0) hash ^= ErrCode.GetHashCode();
      if (ErrMsg.Length != 0) hash ^= ErrMsg.GetHashCode();
      hash ^= list_.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (ErrCode != 0) {
        output.WriteRawTag(8);
        output.WriteEnum((int) ErrCode);
      }
      if (ErrMsg.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(ErrMsg);
      }
      list_.WriteTo(output, _repeated_list_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (ErrCode != 0) {
        size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) ErrCode);
      }
      if (ErrMsg.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(ErrMsg);
      }
      size += list_.CalculateSize(_repeated_list_codec);
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(PbListRet other) {
      if (other == null) {
        return;
      }
      if (other.ErrCode != 0) {
        ErrCode = other.ErrCode;
      }
      if (other.ErrMsg.Length != 0) {
        ErrMsg = other.ErrMsg;
      }
      list_.Add(other.list_);
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 8: {
            errCode_ = (global::GrpcTest.Services.Enumeration.ErrorCodes) input.ReadEnum();
            break;
          }
          case 18: {
            ErrMsg = input.ReadString();
            break;
          }
          case 26: {
            list_.AddEntriesFrom(input, _repeated_list_codec);
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
