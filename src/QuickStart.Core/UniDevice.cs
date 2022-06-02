using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace QuickStart.Core
{
    class UniDevice
    {
        #region API Define
        public enum eUniApiReturnCode
        {
            Success = 0,

            ConnectionBase = 0,
            NotConnected = ConnectionBase + 1,
            AlreadyConnected = ConnectionBase + 2,
            Disconnected = ConnectionBase + 3,
            Disconnecting = ConnectionBase + 4,
            FailedCommunication = ConnectionBase + 5,
            InvalidMessage = ConnectionBase + 6,
            InvalidSequenceNumber = ConnectionBase + 7,
            InvalidCommunicationFormat = ConnectionBase + 8,
            InvalidNetworkId = ConnectionBase + 9,

            OperationBase = 127,
            InvalidAxisNumber = OperationBase + 1,
            OperationTimeout = OperationBase + 2,
            NotOperation = OperationBase + 3,
            FailedOperation = OperationBase + 4,
            InvalidAddress = OperationBase + 5,
            InvalidDataCount = OperationBase + 6,
            InvalidDataValue = OperationBase + 7,
            AlreadyOperation = OperationBase + 8,
            AlreadySet = OperationBase + 9,
            InvalidCommand = OperationBase + 17,
            SameSequenceNumber = OperationBase + 18,
            NotConfiguration = OperationBase + 33,
            NotDriveReady = OperationBase + 34,
            NotServoOn = OperationBase + 35,
            NotSet = OperationBase + 36,
            FailedErase = OperationBase + 49,
            FailedWrite = OperationBase + 50,
            FailedRead = OperationBase + 51,

            MotionBase = 200,
            InvalidTargetPosition = MotionBase,
            RadiusTooSmall = MotionBase + 1,

            HomingBase = 300,
            HomingFailed = HomingBase + 1,
            HomingInvalidAxisNumber = HomingBase + 2,
            HomingInvalidStepNumber = HomingBase + 3,
            HomingAbort = HomingBase + 4,
            HomingDataEmpty = HomingBase + 5,
            HomingDataFull = HomingBase + 6,
            HomingStepFailed = HomingBase + 10,
            HomingOffsetFailed = HomingBase + 11,
            HomingDetectLimitNegative = HomingBase + 12,
            HomingDetectLimitPositive = HomingBase + 13,
            HomingSleep = HomingBase + 20,
            HomingMoving = HomingBase + 21,
            HomingMovedDelay = HomingBase + 22,
            HomingMoveHomeNegative = HomingBase + 50,
            HomingMoveHomePositive = HomingBase + 51,

            ApiBase = 1000,
            InvalidArgument = ApiBase + 0,
            InvalidDirectory = ApiBase + 1,
            FailedLogic = ApiBase + 2,
            NoData = ApiBase + 3,
            DataOverflow = ApiBase + 4,
            ArgumentNullPointer = ApiBase + 5,
            Environment = ApiBase + 6,
            NotSupported = ApiBase + 7,

            System = 10000,
        }

        public int NetID { get; protected set; } = 1;
        #endregion

        #region API Import
        [DllImport("EMotionUniDevice.dll", CallingConvention = CallingConvention.Cdecl)]
        protected static extern int eUniConnect(int netId, int port);
        #endregion

        public async Task<object> Connect(dynamic port)
        {
            int returnCode = (int)eUniApiReturnCode.Success;
            int netId = 1;

            try
            {
                returnCode = eUniConnect(netId, port);
            }
            catch (Exception ex)
            {
                returnCode = -1;
            }

            return returnCode;
        }
    }
}
