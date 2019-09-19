// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: dolittle/timeseries/connectors/server/pull_connectors.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Dolittle.TimeSeries.Runtime.Connectors.Grpc.Server {

  /// <summary>Holder for reflection information generated from dolittle/timeseries/connectors/server/pull_connectors.proto</summary>
  public static partial class PullConnectorsReflection {

    #region Descriptor
    /// <summary>File descriptor for dolittle/timeseries/connectors/server/pull_connectors.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static PullConnectorsReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "Cjtkb2xpdHRsZS90aW1lc2VyaWVzL2Nvbm5lY3RvcnMvc2VydmVyL3B1bGxf",
            "Y29ubmVjdG9ycy5wcm90bxIlZG9saXR0bGUudGltZXNlcmllcy5jb25uZWN0",
            "b3JzLnNlcnZlchoRc3lzdGVtL2d1aWQucHJvdG8aG2dvb2dsZS9wcm90b2J1",
            "Zi9FbXB0eS5wcm90bxo6ZG9saXR0bGUvdGltZXNlcmllcy9jb25uZWN0b3Jz",
            "L3NlcnZlci9wdWxsX2Nvbm5lY3Rvci5wcm90bxozZG9saXR0bGUvdGltZXNl",
            "cmllcy9kYXRhcG9pbnRzL3RhZ19kYXRhX3BvaW50LnByb3RvIm8KDFdyaXRl",
            "TWVzc2FnZRIjCgtjb25uZWN0b3JJZBgBIAEoCzIOLmRvbGl0dGxlLmd1aWQS",
            "OgoERGF0YRgCIAMoCzIsLmRvbGl0dGxlLnRpbWVzZXJpZXMuZGF0YXBvaW50",
            "cy5UYWdEYXRhUG9pbnQiGwoLUHVsbFJlcXVlc3QSDAoEdGFncxgBIAMoCTLh",
            "AQoOUHVsbENvbm5lY3RvcnMSdwoHQ29ubmVjdBI0LmRvbGl0dGxlLnRpbWVz",
            "ZXJpZXMuY29ubmVjdG9ycy5zZXJ2ZXIuUHVsbENvbm5lY3RvchoyLmRvbGl0",
            "dGxlLnRpbWVzZXJpZXMuY29ubmVjdG9ycy5zZXJ2ZXIuUHVsbFJlcXVlc3Qi",
            "ADABElYKBVdyaXRlEjMuZG9saXR0bGUudGltZXNlcmllcy5jb25uZWN0b3Jz",
            "LnNlcnZlci5Xcml0ZU1lc3NhZ2UaFi5nb29nbGUucHJvdG9idWYuRW1wdHki",
            "AEI1qgIyRG9saXR0bGUuVGltZVNlcmllcy5SdW50aW1lLkNvbm5lY3RvcnMu",
            "R3JwYy5TZXJ2ZXJiBnByb3RvMw=="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::System.Protobuf.GuidReflection.Descriptor, global::Google.Protobuf.WellKnownTypes.EmptyReflection.Descriptor, global::Dolittle.TimeSeries.Runtime.Connectors.Grpc.Server.PullConnectorReflection.Descriptor, global::Dolittle.TimeSeries.Runtime.DataPoints.Grpc.TagDataPointReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Dolittle.TimeSeries.Runtime.Connectors.Grpc.Server.WriteMessage), global::Dolittle.TimeSeries.Runtime.Connectors.Grpc.Server.WriteMessage.Parser, new[]{ "ConnectorId", "Data" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Dolittle.TimeSeries.Runtime.Connectors.Grpc.Server.PullRequest), global::Dolittle.TimeSeries.Runtime.Connectors.Grpc.Server.PullRequest.Parser, new[]{ "Tags" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class WriteMessage : pb::IMessage<WriteMessage> {
    private static readonly pb::MessageParser<WriteMessage> _parser = new pb::MessageParser<WriteMessage>(() => new WriteMessage());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<WriteMessage> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Dolittle.TimeSeries.Runtime.Connectors.Grpc.Server.PullConnectorsReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public WriteMessage() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public WriteMessage(WriteMessage other) : this() {
      connectorId_ = other.connectorId_ != null ? other.connectorId_.Clone() : null;
      data_ = other.data_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public WriteMessage Clone() {
      return new WriteMessage(this);
    }

    /// <summary>Field number for the "connectorId" field.</summary>
    public const int ConnectorIdFieldNumber = 1;
    private global::System.Protobuf.guid connectorId_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::System.Protobuf.guid ConnectorId {
      get { return connectorId_; }
      set {
        connectorId_ = value;
      }
    }

    /// <summary>Field number for the "Data" field.</summary>
    public const int DataFieldNumber = 2;
    private static readonly pb::FieldCodec<global::Dolittle.TimeSeries.Runtime.DataPoints.Grpc.TagDataPoint> _repeated_data_codec
        = pb::FieldCodec.ForMessage(18, global::Dolittle.TimeSeries.Runtime.DataPoints.Grpc.TagDataPoint.Parser);
    private readonly pbc::RepeatedField<global::Dolittle.TimeSeries.Runtime.DataPoints.Grpc.TagDataPoint> data_ = new pbc::RepeatedField<global::Dolittle.TimeSeries.Runtime.DataPoints.Grpc.TagDataPoint>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<global::Dolittle.TimeSeries.Runtime.DataPoints.Grpc.TagDataPoint> Data {
      get { return data_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as WriteMessage);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(WriteMessage other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (!object.Equals(ConnectorId, other.ConnectorId)) return false;
      if(!data_.Equals(other.data_)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (connectorId_ != null) hash ^= ConnectorId.GetHashCode();
      hash ^= data_.GetHashCode();
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
      if (connectorId_ != null) {
        output.WriteRawTag(10);
        output.WriteMessage(ConnectorId);
      }
      data_.WriteTo(output, _repeated_data_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (connectorId_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(ConnectorId);
      }
      size += data_.CalculateSize(_repeated_data_codec);
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(WriteMessage other) {
      if (other == null) {
        return;
      }
      if (other.connectorId_ != null) {
        if (connectorId_ == null) {
          ConnectorId = new global::System.Protobuf.guid();
        }
        ConnectorId.MergeFrom(other.ConnectorId);
      }
      data_.Add(other.data_);
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
            if (connectorId_ == null) {
              ConnectorId = new global::System.Protobuf.guid();
            }
            input.ReadMessage(ConnectorId);
            break;
          }
          case 18: {
            data_.AddEntriesFrom(input, _repeated_data_codec);
            break;
          }
        }
      }
    }

  }

  public sealed partial class PullRequest : pb::IMessage<PullRequest> {
    private static readonly pb::MessageParser<PullRequest> _parser = new pb::MessageParser<PullRequest>(() => new PullRequest());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<PullRequest> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Dolittle.TimeSeries.Runtime.Connectors.Grpc.Server.PullConnectorsReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public PullRequest() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public PullRequest(PullRequest other) : this() {
      tags_ = other.tags_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public PullRequest Clone() {
      return new PullRequest(this);
    }

    /// <summary>Field number for the "tags" field.</summary>
    public const int TagsFieldNumber = 1;
    private static readonly pb::FieldCodec<string> _repeated_tags_codec
        = pb::FieldCodec.ForString(10);
    private readonly pbc::RepeatedField<string> tags_ = new pbc::RepeatedField<string>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<string> Tags {
      get { return tags_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as PullRequest);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(PullRequest other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if(!tags_.Equals(other.tags_)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      hash ^= tags_.GetHashCode();
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
      tags_.WriteTo(output, _repeated_tags_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      size += tags_.CalculateSize(_repeated_tags_codec);
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(PullRequest other) {
      if (other == null) {
        return;
      }
      tags_.Add(other.tags_);
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
            tags_.AddEntriesFrom(input, _repeated_tags_codec);
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
