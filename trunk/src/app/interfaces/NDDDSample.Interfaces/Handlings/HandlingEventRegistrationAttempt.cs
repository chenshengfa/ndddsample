﻿namespace NDDDSample.Interfaces.Handlings
{
    #region Usings

    using System;
    using Domain.JavaRelated;
    using Domain.Model.Cargos;
    using Domain.Model.Handlings;
    using Domain.Model.Locations;
    using Domain.Model.Voyages;

    #endregion

    /// <summary>
    /// This is a simple transfer object for passing incoming handling event
    /// registration attempts to proper the registration procedure.
    ///
    // It is used as a message queue element. 
    /// </summary>
    [Serializable]
    public sealed class HandlingEventRegistrationAttempt
    {
        private readonly DateTime registrationTime;
        private readonly DateTime completionTime;
        private readonly TrackingId trackingId;
        private readonly VoyageNumber voyageNumber;
        private readonly HandlingEvent.HandlingType type;
        private readonly UnLocode unLocode;

        public HandlingEventRegistrationAttempt(DateTime registrationDate,
                                                DateTime completionDate,
                                                TrackingId trackingId,
                                                VoyageNumber voyageNumber,
                                                HandlingEvent.HandlingType type,
                                                UnLocode unLocode)
        {
            registrationTime = registrationDate;
            completionTime = completionDate;
            this.trackingId = trackingId;
            this.voyageNumber = voyageNumber;
            this.type = type;
            this.unLocode = unLocode;
        }

        public DateTime getCompletionTime()
        {
            //TODO: atrosin revise new Date(completionTime.getTime())
            return completionTime;
        }

        public TrackingId getTrackingId()
        {
            return trackingId;
        }

        public VoyageNumber getVoyageNumber()
        {
            return voyageNumber;
        }

        public HandlingEvent.HandlingType getType()
        {
            return type;
        }

        public UnLocode getUnLocode()
        {
            return unLocode;
        }

        public DateTime getRegistrationTime()
        {
            return registrationTime;
        }


        public override string ToString()
        {
            return ToStringBuilder.reflectionToString(this, ToStringStyle.MULTI_LINE_STYLE);
        }
    }
}