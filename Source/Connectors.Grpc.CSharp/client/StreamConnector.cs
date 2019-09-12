// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: dolittle/timeseries/connectors/client/stream_connector.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Dolittle.TimeSeries.Runtime.Connectors.Grpc.Client {

  /// <summary>Holder for reflection information generated from dolittle/timeseries/connectors/client/stream_connector.proto</summary>
  public static partial class StreamConnectorReflection {

    #region Descriptor
    /// <summary>File descriptor for dolittle/timeseries/connectors/client/stream_connector.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static StreamConnectorReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "Cjxkb2xpdHRsZS90aW1lc2VyaWVzL2Nvbm5lY3RvcnMvY2xpZW50L3N0cmVh",
            "bV9jb25uZWN0b3IucHJvdG8SJWRvbGl0dGxlLnRpbWVzZXJpZXMuY29ubmVj",
            "dG9ycy5jbGllbnQaEXN5c3RlbS9ndWlkLnByb3RvGjJkb2xpdHRsZS90aW1l",
            "c2VyaWVzL2RhdGF0eXBlcy90YWdfZGF0YV9wb2ludC5wcm90byJCCg1TdHJl",
            "YW1SZXF1ZXN0EiMKC2Nvbm5lY3RvcklkGAEgASgLMg4uZG9saXR0bGUuZ3Vp",
            "ZBIMCgR0YWdzGAIgAygJMoMBCg9TdHJlYW1Db25uZWN0b3IScAoHQ29ubmVj",
            "dBI0LmRvbGl0dGxlLnRpbWVzZXJpZXMuY29ubmVjdG9ycy5jbGllbnQuU3Ry",
            "ZWFtUmVxdWVzdBorLmRvbGl0dGxlLnRpbWVzZXJpZXMuZGF0YXR5cGVzLlRh",
            "Z0RhdGFQb2ludCIAMAFCNaoCMkRvbGl0dGxlLlRpbWVTZXJpZXMuUnVudGlt",
            "ZS5Db25uZWN0b3JzLkdycGMuQ2xpZW50YgZwcm90bzM="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::System.Protobuf.GuidReflection.Descriptor, global::Dolittle.TimeSeries.DataTypes.TagDataPointReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Dolittle.TimeSeries.Runtime.Connectors.Grpc.Client.StreamRequest), global::Dolittle.TimeSeries.Runtime.Connectors.Grpc.Client.StreamRequest.Parser, new[]{ "ConnectorId", "Tags" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class StreamRequest : pb::IMessage<StreamRequest> {
    private static readonly pb::MessageParser<StreamRequest> _parser = new pb::MessageParser<StreamRequest>(() => new StreamRequest());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<StreamRequest> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Dolittle.TimeSeries.Runtime.Connectors.Grpc.Client.StreamConnectorReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public StreamRequest() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public StreamRequest(StreamRequest other) : this() {
      connectorId_ = other.connectorId_ != null ? other.connectorId_.Clone() : null;
      tags_ = other.tags_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public StreamRequest Clone() {
      return new StreamRequest(this);
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

    /// <summary>Field number for the "tags" field.</summary>
    public const int TagsFieldNumber = 2;
    private static readonly pb::FieldCodec<string> _repeated_tags_codec
        = pb::FieldCodec.ForString(18);
    private readonly pbc::RepeatedField<string> tags_ = new pbc::RepeatedField<string>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<string> Tags {
      get { return tags_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as StreamRequest);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(StreamRequest other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (!object.Equals(ConnectorId, other.ConnectorId)) return false;
      if(!tags_.Equals(other.tags_)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (connectorId_ != null) hash ^= ConnectorId.GetHashCode();
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
      if (connectorId_ != null) {
        output.WriteRawTag(10);
        output.WriteMessage(ConnectorId);
      }
      tags_.WriteTo(output, _repeated_tags_codec);
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
      size += tags_.CalculateSize(_repeated_tags_codec);
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(StreamRequest other) {
      if (other == null) {
        return;
      }
      if (other.connectorId_ != null) {
        if (connectorId_ == null) {
          ConnectorId = new global::System.Protobuf.guid();
        }
        ConnectorId.MergeFrom(other.ConnectorId);
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
            if (connectorId_ == null) {
              ConnectorId = new global::System.Protobuf.guid();
            }
            input.ReadMessage(ConnectorId);
            break;
          }
          case 18: {
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
