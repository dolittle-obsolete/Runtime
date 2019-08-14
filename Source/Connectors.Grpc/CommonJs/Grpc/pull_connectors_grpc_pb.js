// GENERATED CODE -- DO NOT EDIT!

// Original file comments:
// ---------------------------------------------------------------------------------------------
//  Copyright (c) Dolittle. All rights reserved.
//  Licensed under the MIT License. See LICENSE in the project root for license information.
// --------------------------------------------------------------------------------------------
'use strict';
var grpc = require('grpc');
var pull_connector_get_data_pb = require('./pull_connector_get_data_pb.js');
var pull_connector_data_pb = require('./pull_connector_data_pb.js');

function serialize_dolittle_timeseries_connectors_PullConnectorData(arg) {
  if (!(arg instanceof pull_connector_data_pb.PullConnectorData)) {
    throw new Error('Expected argument of type dolittle.timeseries.connectors.PullConnectorData');
  }
  return Buffer.from(arg.serializeBinary());
}

function deserialize_dolittle_timeseries_connectors_PullConnectorData(buffer_arg) {
  return pull_connector_data_pb.PullConnectorData.deserializeBinary(new Uint8Array(buffer_arg));
}

function serialize_dolittle_timeseries_connectors_PullConnectorGetData(arg) {
  if (!(arg instanceof pull_connector_get_data_pb.PullConnectorGetData)) {
    throw new Error('Expected argument of type dolittle.timeseries.connectors.PullConnectorGetData');
  }
  return Buffer.from(arg.serializeBinary());
}

function deserialize_dolittle_timeseries_connectors_PullConnectorGetData(buffer_arg) {
  return pull_connector_get_data_pb.PullConnectorGetData.deserializeBinary(new Uint8Array(buffer_arg));
}


// Represents the service for working with quantum tunnel
var PullConnectorsService = exports.PullConnectorsService = {
  register: {
    path: '/dolittle.timeseries.connectors.PullConnectors/Register',
    requestStream: true,
    responseStream: true,
    requestType: pull_connector_get_data_pb.PullConnectorGetData,
    responseType: pull_connector_data_pb.PullConnectorData,
    requestSerialize: serialize_dolittle_timeseries_connectors_PullConnectorGetData,
    requestDeserialize: deserialize_dolittle_timeseries_connectors_PullConnectorGetData,
    responseSerialize: serialize_dolittle_timeseries_connectors_PullConnectorData,
    responseDeserialize: deserialize_dolittle_timeseries_connectors_PullConnectorData,
  },
};

exports.PullConnectorsClient = grpc.makeGenericClientConstructor(PullConnectorsService);
