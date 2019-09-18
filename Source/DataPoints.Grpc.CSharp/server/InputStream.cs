// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: dolittle/timeseries/datapoints/server/input_stream.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Dolittle.TimeSeries.Runtime.DataPoints.Grpc.Server {

  /// <summary>Holder for reflection information generated from dolittle/timeseries/datapoints/server/input_stream.proto</summary>
  public static partial class InputStreamReflection {

    #region Descriptor
    /// <summary>File descriptor for dolittle/timeseries/datapoints/server/input_stream.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static InputStreamReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "Cjhkb2xpdHRsZS90aW1lc2VyaWVzL2RhdGFwb2ludHMvc2VydmVyL2lucHV0",
            "X3N0cmVhbS5wcm90bxIlZG9saXR0bGUudGltZXNlcmllcy5kYXRhcG9pbnRz",
            "LnNlcnZlchoRc3lzdGVtL2d1aWQucHJvdG8aLmRvbGl0dGxlL3RpbWVzZXJp",
            "ZXMvZGF0YXR5cGVzL2RhdGFfcG9pbnQucHJvdG8iJwoJVGltZVNlcmllEhoK",
            "AmlkGAEgASgLMg4uZG9saXR0bGUuZ3VpZDJ3CgtJbnB1dFN0cmVhbRJoCgRP",
            "cGVuEiguZG9saXR0bGUudGltZXNlcmllcy5kYXRhdHlwZXMuRGF0YVBvaW50",
            "GjAuZG9saXR0bGUudGltZXNlcmllcy5kYXRhcG9pbnRzLnNlcnZlci5UaW1l",
            "U2VyaWUiACgBMAFCNaoCMkRvbGl0dGxlLlRpbWVTZXJpZXMuUnVudGltZS5E",
            "YXRhUG9pbnRzLkdycGMuU2VydmVyYgZwcm90bzM="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::System.Protobuf.GuidReflection.Descriptor, global::Dolittle.TimeSeries.DataTypes.Protobuf.DataPointReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Dolittle.TimeSeries.Runtime.DataPoints.Grpc.Server.TimeSerie), global::Dolittle.TimeSeries.Runtime.DataPoints.Grpc.Server.TimeSerie.Parser, new[]{ "Id" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class TimeSerie : pb::IMessage<TimeSerie> {
    private static readonly pb::MessageParser<TimeSerie> _parser = new pb::MessageParser<TimeSerie>(() => new TimeSerie());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<TimeSerie> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Dolittle.TimeSeries.Runtime.DataPoints.Grpc.Server.InputStreamReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public TimeSerie() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public TimeSerie(TimeSerie other) : this() {
      id_ = other.id_ != null ? other.id_.Clone() : null;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public TimeSerie Clone() {
      return new TimeSerie(this);
    }

    /// <summary>Field number for the "id" field.</summary>
    public const int IdFieldNumber = 1;
    private global::System.Protobuf.guid id_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::System.Protobuf.guid Id {
      get { return id_; }
      set {
        id_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as TimeSerie);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(TimeSerie other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (!object.Equals(Id, other.Id)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (id_ != null) hash ^= Id.GetHashCode();
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
      if (id_ != null) {
        output.WriteRawTag(10);
        output.WriteMessage(Id);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (id_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Id);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(TimeSerie other) {
      if (other == null) {
        return;
      }
      if (other.id_ != null) {
        if (id_ == null) {
          Id = new global::System.Protobuf.guid();
        }
        Id.MergeFrom(other.Id);
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
            if (id_ == null) {
              Id = new global::System.Protobuf.guid();
            }
            input.ReadMessage(Id);
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code