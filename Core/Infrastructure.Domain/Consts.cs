using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Domain
{
    public static class Consts
    {
        public enum Gender
        {
            Male,
            Female
        }
        public enum ServiceName {
            CMS,
            Offer,
            Authntication,
            CWCore,
            Gallery,
            Hotel,
            Notification
        }
        public static readonly string StaticPassword = "StaticPassword";

        public static class RideRequestStatus
        {
            public static readonly string PENDING = "Pending";
            public static readonly string CANCELLED = "Cancelled";
            public static readonly string FINISHED = "Finished";
            public static readonly string INPROGRESS = "InProgress";
        }
    }
}
