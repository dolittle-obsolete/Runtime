// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: dolittle/timeseries/datapoints/client/data_point_processor.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Dolittle.TimeSeries.Runtime.DataPoints.Grpc.Client {

  /// <summary>Holder for reflection information generated from dolittle/timeseries/datapoints/client/data_point_processor.proto</summary>
  public static partial class DataPointProcessorReflection {

    #region Descriptor
    /// <summary>File descriptor for dolittle/timeseries/datapoints/client/data_point_processor.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static DataPointProcessorReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "CkBkb2xpdHRsZS90aW1lc2VyaWVzL2RhdGFwb2ludHMvY2xpZW50L2RhdGFf",
            "cG9pbnRfcHJvY2Vzc29yLnByb3RvEiVkb2xpdHRsZS50aW1lc2VyaWVzLmRh",
            "dGFwb2ludHMuY2xpZW50GhFzeXN0ZW0vZ3VpZC5wcm90bxobZ29vZ2xlL3By",
            "b3RvYnVmL2VtcHR5LnByb3RvGi5kb2xpdHRsZS90aW1lc2VyaWVzL2RhdGF0",
            "eXBlcy9kYXRhX3BvaW50LnByb3RvImsKEERhdGFQb2ludE1lc3NhZ2USGgoC",
            "aWQYASABKAsyDi5kb2xpdHRsZS5ndWlkEjsKCWRhdGFQb2ludBgCIAEoCzIo",
            "LmRvbGl0dGxlLnRpbWVzZXJpZXMuZGF0YXR5cGVzLkRhdGFQb2ludDJ0ChJE",
            "YXRhUG9pbnRQcm9jZXNzb3ISXgoHUHJvY2VzcxI3LmRvbGl0dGxlLnRpbWVz",
            "ZXJpZXMuZGF0YXBvaW50cy5jbGllbnQuRGF0YVBvaW50TWVzc2FnZRoWLmdv",
            "b2dsZS5wcm90b2J1Zi5FbXB0eSIAKAFCNaoCMkRvbGl0dGxlLlRpbWVTZXJp",
            "ZXMuUnVudGltZS5EYXRhUG9pbnRzLkdycGMuQ2xpZW50YgZwcm90bzM="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::System.Protobuf.GuidReflection.Descriptor, global::Google.Protobuf.WellKnownTypes.EmptyReflection.Descriptor, global::Dolittle.TimeSeries.DataTypes.Protobuf.DataPointReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Dolittle.TimeSeries.Runtime.DataPoints.Grpc.Client.DataPointMessage), global::Dolittle.TimeSeries.Runtime.DataPoints.Grpc.Client.DataPointMessage.Parser, new[]{ "Id", "DataPoint" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class DataPointMessage : pb::IMessage<DataPointMessage> {
    private static readonly pb::MessageParser<DataPointMessage> _parser = new pb::MessageParser<DataPointMessage>(() => new DataPointMessage());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<DataPointMessage> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Dolittle.TimeSeries.Runtime.DataPoints.Grpc.Client.DataPointProcessorReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public DataPointMessage() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public DataPointMessage(DataPointMessage other) : this() {
      id_ = other.id_ != null ? other.id_.Clone() : null;
      dataPoint_ = other.dataPoint_ != null ? other.dataPoint_.Clone() : null;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public DataPointMessage Clone() {
      return new DataPointMessage(this);
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

    /// <summary>Field number for the "dataPoint" field.</summary>
    public const int DataPointFieldNumber = 2;
    private global::Dolittle.TimeSeries.DataTypes.Protobuf.DataPoint dataPoint_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Dolittle.TimeSeries.DataTypes.Protobuf.DataPoint DataPoint {
      get { return dataPoint_; }
      set {
        dataPoint_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as DataPointMessage);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(DataPointMessage other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (!object.Equals(Id, other.Id)) return false;
      if (!object.Equals(DataPoint, other.DataPoint)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (id_ != null) hash ^= Id.GetHashCode();
      if (dataPoint_ != null) hash ^= DataPoint.GetHashCode();
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
      if (dataPoint_ != null) {
        output.WriteRawTag(18);
        output.WriteMessage(DataPoint);
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
      if (dataPoint_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(DataPoint);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(DataPointMessage other) {
      if (other == null) {
        return;
      }
      if (other.id_ != null) {
        if (id_ == null) {
          Id = new global::System.Protobuf.guid();
        }
        Id.MergeFrom(other.Id);
      }
      if (other.dataPoint_ != null) {
        if (dataPoint_ == null) {
          DataPoint = new global::Dolittle.TimeSeries.DataTypes.Protobuf.DataPoint();
        }
        DataPoint.MergeFrom(other.DataPoint);
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
          case 18: {
            if (dataPoint_ == null) {
              DataPoint = new global::Dolittle.TimeSeries.DataTypes.Protobuf.DataPoint();
            }
            input.ReadMessage(DataPoint);
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
