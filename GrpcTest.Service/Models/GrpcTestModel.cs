// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: PATH/Test/GrpcTestModel.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace GrpcTest.Service.Models {

  /// <summary>Holder for reflection information generated from PATH/Test/GrpcTestModel.proto</summary>
  public static partial class GrpcTestModelReflection {

    #region Descriptor
    /// <summary>File descriptor for PATH/Test/GrpcTestModel.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static GrpcTestModelReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "Ch1QQVRIL1Rlc3QvR3JwY1Rlc3RNb2RlbC5wcm90bxIXR3JwY1Rlc3QuU2Vy",
            "dmljZS5Nb2RlbHMiawoKUmVnaXN0ZXJScRIMCgROYW1lGAEgASgJEg0KBUVt",
            "YWlsGAIgASgJEg0KBVBob25lGAMgASgJEgsKA0FnZRgEIAEoBRIOCgZHZW5k",
            "ZXIYBSABKAgSFAoMQW5udWFsSW5jb21lGAYgASgBYgZwcm90bzM="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::GrpcTest.Service.Models.RegisterRq), global::GrpcTest.Service.Models.RegisterRq.Parser, new[]{ "Name", "Email", "Phone", "Age", "Gender", "AnnualIncome" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  /// <summary>
  ///请求 注册
  /// </summary>
  public sealed partial class RegisterRq : pb::IMessage<RegisterRq> {
    private static readonly pb::MessageParser<RegisterRq> _parser = new pb::MessageParser<RegisterRq>(() => new RegisterRq());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<RegisterRq> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::GrpcTest.Service.Models.GrpcTestModelReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public RegisterRq() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public RegisterRq(RegisterRq other) : this() {
      name_ = other.name_;
      email_ = other.email_;
      phone_ = other.phone_;
      age_ = other.age_;
      gender_ = other.gender_;
      annualIncome_ = other.annualIncome_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public RegisterRq Clone() {
      return new RegisterRq(this);
    }

    /// <summary>Field number for the "Name" field.</summary>
    public const int NameFieldNumber = 1;
    private string name_ = "";
    /// <summary>
    ///姓名
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Name {
      get { return name_; }
      set {
        name_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "Email" field.</summary>
    public const int EmailFieldNumber = 2;
    private string email_ = "";
    /// <summary>
    ///邮箱
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Email {
      get { return email_; }
      set {
        email_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "Phone" field.</summary>
    public const int PhoneFieldNumber = 3;
    private string phone_ = "";
    /// <summary>
    ///手机号码
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Phone {
      get { return phone_; }
      set {
        phone_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "Age" field.</summary>
    public const int AgeFieldNumber = 4;
    private int age_;
    /// <summary>
    ///年龄
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int Age {
      get { return age_; }
      set {
        age_ = value;
      }
    }

    /// <summary>Field number for the "Gender" field.</summary>
    public const int GenderFieldNumber = 5;
    private bool gender_;
    /// <summary>
    ///性别
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Gender {
      get { return gender_; }
      set {
        gender_ = value;
      }
    }

    /// <summary>Field number for the "AnnualIncome" field.</summary>
    public const int AnnualIncomeFieldNumber = 6;
    private double annualIncome_;
    /// <summary>
    ///年收入
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public double AnnualIncome {
      get { return annualIncome_; }
      set {
        annualIncome_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as RegisterRq);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(RegisterRq other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Name != other.Name) return false;
      if (Email != other.Email) return false;
      if (Phone != other.Phone) return false;
      if (Age != other.Age) return false;
      if (Gender != other.Gender) return false;
      if (!pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(AnnualIncome, other.AnnualIncome)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Name.Length != 0) hash ^= Name.GetHashCode();
      if (Email.Length != 0) hash ^= Email.GetHashCode();
      if (Phone.Length != 0) hash ^= Phone.GetHashCode();
      if (Age != 0) hash ^= Age.GetHashCode();
      if (Gender != false) hash ^= Gender.GetHashCode();
      if (AnnualIncome != 0D) hash ^= pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(AnnualIncome);
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
      if (Name.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Name);
      }
      if (Email.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(Email);
      }
      if (Phone.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(Phone);
      }
      if (Age != 0) {
        output.WriteRawTag(32);
        output.WriteInt32(Age);
      }
      if (Gender != false) {
        output.WriteRawTag(40);
        output.WriteBool(Gender);
      }
      if (AnnualIncome != 0D) {
        output.WriteRawTag(49);
        output.WriteDouble(AnnualIncome);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Name.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Name);
      }
      if (Email.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Email);
      }
      if (Phone.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Phone);
      }
      if (Age != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Age);
      }
      if (Gender != false) {
        size += 1 + 1;
      }
      if (AnnualIncome != 0D) {
        size += 1 + 8;
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(RegisterRq other) {
      if (other == null) {
        return;
      }
      if (other.Name.Length != 0) {
        Name = other.Name;
      }
      if (other.Email.Length != 0) {
        Email = other.Email;
      }
      if (other.Phone.Length != 0) {
        Phone = other.Phone;
      }
      if (other.Age != 0) {
        Age = other.Age;
      }
      if (other.Gender != false) {
        Gender = other.Gender;
      }
      if (other.AnnualIncome != 0D) {
        AnnualIncome = other.AnnualIncome;
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
          case 10: {
            Name = input.ReadString();
            break;
          }
          case 18: {
            Email = input.ReadString();
            break;
          }
          case 26: {
            Phone = input.ReadString();
            break;
          }
          case 32: {
            Age = input.ReadInt32();
            break;
          }
          case 40: {
            Gender = input.ReadBool();
            break;
          }
          case 49: {
            AnnualIncome = input.ReadDouble();
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
