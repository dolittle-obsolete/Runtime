// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: dolittle/timeseries/datapoints/server/data_point_processors.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Dolittle.TimeSeries.Runtime.DataPoints.Grpc.Server {

  /// <summary>Holder for reflection information generated from dolittle/timeseries/datapoints/server/data_point_processors.proto</summary>
  public static partial class DataPointProcessorsReflection {

    #region Descriptor
    /// <summary>File descriptor for dolittle/timeseries/datapoints/server/data_point_processors.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static DataPointProcessorsReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "CkFkb2xpdHRsZS90aW1lc2VyaWVzL2RhdGFwb2ludHMvc2VydmVyL2RhdGFf",
            "cG9pbnRfcHJvY2Vzc29ycy5wcm90bxIlZG9saXR0bGUudGltZXNlcmllcy5k",
            "YXRhcG9pbnRzLnNlcnZlchpAZG9saXR0bGUvdGltZXNlcmllcy9kYXRhcG9p",
            "bnRzL3NlcnZlci9kYXRhX3BvaW50X3Byb2Nlc3Nvci5wcm90byIQCg5SZWdp",
            "c3RlclJlc3VsdDKVAQoTRGF0YVBvaW50UHJvY2Vzc29ycxJ+CghSZWdpc3Rl",
            "chI5LmRvbGl0dGxlLnRpbWVzZXJpZXMuZGF0YXBvaW50cy5zZXJ2ZXIuRGF0",
            "YVBvaW50UHJvY2Vzc29yGjUuZG9saXR0bGUudGltZXNlcmllcy5kYXRhcG9p",
            "bnRzLnNlcnZlci5SZWdpc3RlclJlc3VsdCIAQjWqAjJEb2xpdHRsZS5UaW1l",
            "U2VyaWVzLlJ1bnRpbWUuRGF0YVBvaW50cy5HcnBjLlNlcnZlcmIGcHJvdG8z"));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::Dolittle.TimeSeries.Runtime.DataPoints.Grpc.Server.DataPointProcessorReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Dolittle.TimeSeries.Runtime.DataPoints.Grpc.Server.RegisterResult), global::Dolittle.TimeSeries.Runtime.DataPoints.Grpc.Server.RegisterResult.Parser, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class RegisterResult : pb::IMessage<RegisterResult> {
    private static readonly pb::MessageParser<RegisterResult> _parser = new pb::MessageParser<RegisterResult>(() => new RegisterResult());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<RegisterResult> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Dolittle.TimeSeries.Runtime.DataPoints.Grpc.Server.DataPointProcessorsReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public RegisterResult() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public RegisterResult(RegisterResult other) : this() {
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public RegisterResult Clone() {
      return new RegisterResult(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as RegisterResult);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(RegisterResult other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
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
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(RegisterResult other) {
      if (other == null) {
        return;
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
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
