/*           
* Author                             : Metehan PATACI
* Date                               : 05/12/2020 7:21:11 PM
* Description     		     :               
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorMainScreen.ConsoleCommandMng.Model.Commands
{
    public enum SampeConsoleCommandNames
    {
        //Platform
        PlatformApplyHoldTrain,
        PlatformApplySkipTrain,
        PlatformChangeWaitingDuration,
        PlatformApplyCancelSkipTrain,
        PlatformApplyCancelHoldTrain,
        PlatformApplyStationResetDwellTime,
        //PlatformApplyBerthAtBack,
        //PlatformApplyBerthAtFront,
        PlatformBerthing,

        //Train
        TrainApplyHoldNextStation,
        TrainCancelHoldNextStation,
        TrainApplySkipAllStations,
        TrainApplySkipNextStation,
        TrainStopNextStation,
        TrainStopTrainWithServiceBrake,
        TrainChangePerformanceLevel,
        TrainApplyDefaultPerformanceLevel,
        TrainApplyCancelAutomaticHold,
        TrainStandByMode,
        TrainWakeUpWithDepartureTest,
        TrainWakeUpWithoutDepartureTest,
        TrainCancelStop,
        TrainApplyCancelSkipNextStation,
        TrainApplyCancelSkipAllStations,
        TrainApplyEmergencyBrake,
        TrainReleaseEmergencyBrake,
        TrainStopAllTrainWithServiceBrake,
        TrainApplyEmergencyBrakeToAllTrains,
        TrainRestartAllTrains,
        TrainEmergencyHandleBlock,
        TrainEmergencyHandleUnblock,
        TrainOpenDoors,
        TrainCloseDoors,
        TrainRemove,
        TrainDetailWindow,
        TrainChangeTripNo,
        TrainLocationHighlight,
        TrainCancelStopNextStation,
        TrainOnewayControl,
        TrainShuttleOperation,
        TrainAdjustBerthingPoint,
        TrainCancelAdjustBerthingPoint,
        //Switch
        SwitchBlockSwitch,
        SwitchCancelBlockSwitch,
        SwitchBlockSwitchRoute,
        SwitchCancelBlockSwitchRoute,
        SwitchArrangement,
        SwitchArrangementDiverged,
        SwitchArrangementNormal,
        SwitchFailureNormalization,
        SwitchExceptionalMoveNormal,
        SwitchExceptionalMoveReverse,
        SwitchDetailWindow,

        //Track
        TrackCreateZOPRequest,
        TrackCancelZOPRequest,
        TrackCreateBlockBlock,
        TrackCancelBlockBlock,
        TrackRemoveTrainReportingFailure,
        TrackAllocateRoute,
        TrackDeallocateRoute, 
        TrackAllocateRecovery,
        TrackDeallocateRecovery,
        TrackExceptionalRouteCancel,
        TrackCreateZOPBypass,
        TrackCancelZOPBypass,
        TrackTSRUpdate,
        TrackTSRSet,
        TrackDefaultTSR,

        TrackTSRWindow,
        TrackDetailWindow,


        // Route
        RouteCancelRescueRouteCoordination,
        RouteArrangement,
        RouteCancelRouteRequest,
        RouteCancelMandatoryRoute,
        RouteManeuverRouteArrangement,
        RouteRescueRouteCoordination,

        CancelTrackBlockBlocking,

        // Area
        AreaTakeOCCControl,
        AreaTakeLocalControl,
        AreaTakeBOCCControl,

        // Virtual Signal
        VirtualSignalClose,
        VirtualSignalOpen,
        VirtualSignalBlockRequest,
        VirtualSignalCancelBlockRequest,


        //Pesb
        PESBNormalization,

        //Cesb
        CESBNormalization,

        NumOfATSConsoleCommandNames

    }
}
